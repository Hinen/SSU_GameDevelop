using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_GameEnd : SceneBase {
	public void Start() {
		SoundManager.Get().PlayBGM(Constants.Sound.BGM.TITLE);
	}

	public void OnClickContinueButton() {
		SceneManager.LoadScene(Constants.SceneName.SCENE_GAME);
	}
	
	public void OnClickQuitButton() {
		SceneManager.LoadScene(Constants.SceneName.SCENE_TITLE);
	}
}
