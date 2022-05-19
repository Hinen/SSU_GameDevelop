using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Title : SceneBase {
	public void Start() {
		SoundManager.Get().PlayBGM(Constants.Sound.BGM.TITLE);
	}

	public void OnClickGameStartButton() {
		SceneManager.LoadScene(Constants.SceneName.SCENE_SELECT_CHARACTER);
	}
	
	public void OnClickRankingButton() {
		SceneManager.LoadScene(Constants.SceneName.SCENE_RANKING);
	}

	public void OnClickQuitButton() {
		Application.Quit();
	}
}
