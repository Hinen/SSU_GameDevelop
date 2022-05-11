using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_SelectCharacter : SceneBase {
	public void OnClickCharacterButton(int index) {
		SceneManager.LoadScene(Constants.SceneName.SCENE_GAME);
	}
}
