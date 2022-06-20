using UnityEngine.SceneManagement;

public class Scene_SelectCharacter : SceneBase {
	public void OnClickCharacterButton(int index) {
		SoundManager.Get().PlayFX(Constants.Sound.FX.TOUCH);
		
		GameManager.Get().SelectCharacter(index);
		
		SceneManager.LoadScene(Constants.SceneName.SCENE_GAME);
	}
}
