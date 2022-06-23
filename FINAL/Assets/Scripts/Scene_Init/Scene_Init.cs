using UnityEngine.SceneManagement;

public class Scene_Init : SceneBase {
    public override void Awake() {
        base.Awake();

        SceneManager.LoadScene(Constants.SceneName.SCENE_TITLE);
    }
}
