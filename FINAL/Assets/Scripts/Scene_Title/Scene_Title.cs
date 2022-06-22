using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Title : SceneBase {
    [SerializeField]
    private SpriteRenderer[] _backgroundSpriteList;

    public void Start() {
        SoundManager.Get().PlayBGM(Constants.Sound.BGM.TITLE);
    }
    
    public override void Update() {
        base.Update();
        
        for (var i = 0; i < _backgroundSpriteList.Length; i++) {
            var background = _backgroundSpriteList[i];
            if (background.transform.localPosition.y >= Constants.RESOLUTION_Y * 2) {
                var nextBackground = _backgroundSpriteList[i == _backgroundSpriteList.Length - 1 ? 0 : i + 1];
                background.transform.localPosition = new Vector2(0f, nextBackground.transform.localPosition.y - Constants.RESOLUTION_Y);
            }
            else {
                background.transform.Translate(Vector3.up * Time.deltaTime * 100f / 4f);
            }
        }
    }

    public void OnClickGameStart() {
        SceneManager.LoadScene(Constants.SceneName.SCENE_GAME);
    }
    
    public void OnClickHowToPlay() {
        
    }
    
    public void OnClickGameQuit() {
        Application.Quit();
    }
}
