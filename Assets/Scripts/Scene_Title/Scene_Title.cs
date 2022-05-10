using UnityEngine.SceneManagement;

public class Scene_Title : SceneBase {
	public void Start() {
		SoundManager.Get().PlayBGM(Constants.Sound.BGM_TITLE);
	}

	public void OnClickTest() {
		SceneManager.LoadScene("Scene_Game");
	}
}
