using System.Collections;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using UnityEngine;

public class RankingManager : MonoBehaviour {
    private static RankingManager _instance;
    public static RankingManager Get() => _instance;

    private class User {
        public string name;
        public int score;
        
        public User(string name, int score) {
            this.name = name;
            this.score = score;
        }
    }

    private FirebaseApp _firebaseApp;
    private FirebaseAuth _firebaseAuth;
    private FirebaseUser _firebaseUser;
    private DatabaseReference _databaseReference;

    private bool IsInited => _firebaseApp != null && 
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
                });
            } else {
                Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}");
            }
        });

        DontDestroyOnLoad(this);
    }

    public void GetRankings() {
        if (!IsInited)
            return;

        _databaseReference.Child("Ranking").GetValueAsync().ContinueWith(task => {
            if (task.IsCompleted) {
                var dataSnapShot = task.Result;
                
                foreach (var data in dataSnapShot.Children) {
                    var info = (IDictionary)data.Value;
                    Debug.Log(info);   
                }
            }
            else if (task.IsFaulted) {
                Debug.LogError("err");
            }
        });
    }

    public void InsertRanking(string name, int score) {
        if (!IsInited)
            return;
        
        string json = JsonUtility.ToJson(new User(name, score));
        _databaseReference.Child("Ranking").Child(_firebaseUser.UserId).SetRawJsonValueAsync(json);
    }
}
