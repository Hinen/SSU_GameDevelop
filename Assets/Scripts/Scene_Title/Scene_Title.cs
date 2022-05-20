using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Title : SceneBase {
	[SerializeField]
	private Animator _titleAnimator;

	private static bool _isAlreadyPlayedAnimation;
	
	public void Start() {
		SoundManager.Get().PlayBGM(Constants.Sound.BGM.TITLE);

		if (!_isAlreadyPlayedAnimation) {
			_titleAnimator.SetTrigger("Start");
			_isAlreadyPlayedAnimation = true;
		}
		else {
			_titleAnimator.SetTrigger("Loop");
		}
	}

	public void OnClickGameStartButton() {
		SoundManager.Get().PlayFX(Constants.Sound.FX.TOUCH);
		SceneManager.LoadScene(Constants.SceneName.SCENE_SELECT_CHARACTER);
	}
	
	public void OnClickRankingButton() {
		SoundManager.Get().PlayFX(Constants.Sound.FX.TOUCH);
		SceneManager.LoadScene(Constants.SceneName.SCENE_RANKING);
	}

	public void OnClickQuitButton() {
		Application.Quit();
	}
}
