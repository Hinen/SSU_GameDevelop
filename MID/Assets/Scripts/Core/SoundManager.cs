using UnityEngine;

public class SoundManager : MonoBehaviour {
    private static SoundManager _instance;
    public static SoundManager Get() => _instance;

    [SerializeField]
    private AudioSource _bgmSource;
    
    [SerializeField]
    private StringAudioSourceDictionary _fxSourceDictionary;
    
    public void Awake() {
        _instance = this;
        
        DontDestroyOnLoad(this);
    }

    public void PlayBGM(string bgm) {
        if (_bgmSource.isPlaying) {
            if (_bgmSource.clip.name == bgm)
                return;
            
            _bgmSource.Stop();
        }

        _bgmSource.clip = Resources.Load<AudioClip>("Sounds/BGM/" + bgm);
        _bgmSource.Play();
    }

    public void PlayFX(string fx) {
        _fxSourceDictionary[fx]?.Play();
    }
}
