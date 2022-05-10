using UnityEngine;

public class SoundManager : MonoBehaviour {
    private static SoundManager _instance;
    public static SoundManager Get() => _instance;

    [SerializeField]
    private AudioSource _bgmSource;
    
    public void Awake() {
        _instance = this;
        
        DontDestroyOnLoad(this);
    }

    public void PlayBGM(string bgm) {
        _bgmSource.clip = Resources.Load<AudioClip>("Sounds/BGM/" + bgm);
        _bgmSource.Play();
    }
}
