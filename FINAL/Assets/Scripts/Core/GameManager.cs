using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager _instance;
    public static GameManager Get() => _instance;
    
    public float Score { get; set; }
    
    public void Awake() {
        _instance = this;
        
        DontDestroyOnLoad(this);
    }
}
