using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_Result : SceneBase {
    [SerializeField]
    private Text _scoreText;
    
    public void Start() {
        SoundManager.Get().PlayBGM(Constants.Sound.BGM.TITLE);
        SoundManager.Get().PlayFX(Constants.Sound.FX.CAT);

        _scoreText.text = GameManager.Get().Score.ToString();
    }

    public void OnClickScreen() {
        SceneManager.LoadScene(Constants.SceneName.SCENE_GAME);
    }
}
