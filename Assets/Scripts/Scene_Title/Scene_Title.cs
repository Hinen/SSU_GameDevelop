using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Title : SceneBase {
	public void Start() {
		SoundManager.Get().PlayBGM(Constants.Sound.BGM_TITLE);
	}

	public void OnClickGameStartButton() {
		SceneManager.LoadScene("Scene_Game");
	}

	public void OnClickQuitButton() {
		Application.Quit();
	}
}
