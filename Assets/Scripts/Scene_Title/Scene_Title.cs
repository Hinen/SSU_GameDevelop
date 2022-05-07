using UnityEngine.SceneManagement;

public class Scene_Title : SceneBase {
	public void OnClickTest() {
		SceneManager.LoadScene("Scene_Game");
	}
}
