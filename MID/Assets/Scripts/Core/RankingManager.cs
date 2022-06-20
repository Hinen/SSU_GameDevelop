using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using UnityEngine;

public class RankingManager : MonoBehaviour {
    private static RankingManager _instance;
    public static RankingManager Get() => _instance;

    public class RankingInfo {
        public string name;
        public float score;
        
        public RankingInfo(string name, float score) {
            this.name = name;
            this.score = score;
        }
    }

    private FirebaseApp _firebaseApp;
    private FirebaseAuth _firebaseAuth;
    private FirebaseUser _firebaseUser;
    private DatabaseReference _databaseReference;

    public bool IsInited => _firebaseApp != null && 
                             _firebaseUser != null &&
                             _databaseReference != null;
    
    public void Awake() {
        _instance = this;
        
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available) {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                _firebaseApp = FirebaseApp.DefaultInstance;
                _firebaseAuth = FirebaseAuth.DefaultInstance;
                _databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

                _firebaseAuth.SignInAnonymouslyAsync().ContinueWith(authTask => {
                    if (authTask.IsCanceled) {
                        Debug.LogError("SignInAnonymouslyAsync was canceled.");
                        return;
                    }
            
                    if (authTask.IsFaulted) {
                        Debug.LogError("SignInAnonymouslyAsync encountered an error: " + task.Exception);
                        return;
                    }

                    _firebaseUser = authTask.Result;
                    Debug.LogFormat("FireBase User signed in successfully: {0} ({1})", _firebaseUser.DisplayName, _firebaseUser.UserId);

                    GetMyRanking();
                });
            } else {
                Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}");
            }
        });

        DontDestroyOnLoad(this);
    }

    public void GetRankings(Action<List<RankingInfo>> callback) {
        List<RankingInfo> list = new List<RankingInfo>();
        
        if (!IsInited) {
            callback(list);
            return;
        }

        _databaseReference.Child("Ranking").GetValueAsync().ContinueWith(task => {
            if (task.IsCompleted) {
                var dataSnapShot = task.Result;
                if (dataSnapShot == null) {
                    callback(list);
                    return;
                }

                foreach (var data in dataSnapShot.Children) {
                    var info = (IDictionary)data.Value;
                    list.Add(new RankingInfo(info["name"].ToString(), float.Parse(info["score"].ToString())));

                    if (list.Count >= 100)
                        break;
                }

                list = list.OrderByDescending(x => x.score)
                           .Select(x => x)
                           .ToList();
                callback(list);
            }
            else if (task.IsFaulted) {
                callback(list);
            }
        });
    }

    private void GetMyRanking() {
        if (!IsInited)
            return;
        
        _databaseReference.Child("Ranking").Child(_firebaseUser.UserId).GetValueAsync().ContinueWith(task => {
            if (task.IsCompleted) {
                var dataSnapShot = task.Result;
                if (dataSnapShot == null)
                    return;

                foreach (var data in dataSnapShot.Children) {
                    if (data.Key == "score")
                        GameManager.Get().maxGameScore = (float)data.Value;
                }
            }
        });
    }

    public void InsertRanking(string name, float score) {
        if (!IsInited)
            return;
        
        string json = JsonUtility.ToJson(new RankingInfo(name, score));
        _databaseReference.Child("Ranking").Child(_firebaseUser.UserId).SetRawJsonValueAsync(json);
    }
}
