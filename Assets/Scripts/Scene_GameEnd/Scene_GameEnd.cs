using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_GameEnd : SceneBase {
	[SerializeField]
	private Text _gameScoreText;

	[SerializeField]
	private GameObject _rankingSubmitObj;
	
	[SerializeField]
	private InputField _rankingNameInputField;
	
	public void Start() {
		SoundManager.Get().PlayBGM(Constants.Sound.BGM.TITLE);

		_gameScoreText.text = GameManager.Get().gameScore.ToString();
		_rankingSubmitObj.SetActive(RankingManager.Get().IsInited && GameManager.Get().gameScore > GameManager.Get().maxGameScore);
	}

	public void OnClickContinueButton() {
		SoundManager.Get().PlayFX(Constants.Sound.FX.TOUCH);
		SceneManager.LoadScene(Constants.SceneName.SCENE_GAME);
	}
	
	public void OnClickQuitButton() {
		SoundManager.Get().PlayFX(Constants.Sound.FX.TOUCH);
		SceneManager.LoadScene(Constants.SceneName.SCENE_TITLE);
	}

	public void OnClickSubmitRanking() {
		SoundManager.Get().PlayFX(Constants.Sound.FX.TOUCH);
		
		GameManager.Get().maxGameScore = GameManager.Get().gameScore;
		RankingManager.Get().InsertRanking(_rankingNameInputField.text, GameManager.Get().gameScore);
		
		_rankingSubmitObj.SetActive(false);
	}
}
