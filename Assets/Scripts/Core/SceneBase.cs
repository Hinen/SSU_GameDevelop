using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBase : MonoBehaviour {
	private static bool _isInited = false;
	
	public virtual void Awake() {
		if (!_isInited) {
			_isInited = true;

			if (!(this is Scene_Title))
				SceneManager.LoadScene("Scene_Title");
		}
	}
}
