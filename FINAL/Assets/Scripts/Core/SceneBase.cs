using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBase : MonoBehaviour {
	private static SceneBase _instance;

	public static T Get<T>() where T : SceneBase => (T)_instance;
	
	private static bool _isInited = false;

	private int _lastDeviceWidth;
	private int _lastDeviceHeight;

	public virtual void Awake() {
		_instance = this;
		
		if (!_isInited) {
			_isInited = true;

			if (!(this is Scene_Init))
				SceneManager.LoadScene(Constants.SceneName.SCENE_INIT);
			
			Screen.SetResolution(Constants.RESOLUTION_X, Constants.RESOLUTION_Y, false);
		}

		CheckResolution();
	}

	public virtual void Update() {
		CheckResolution();
	}

	private void CheckResolution() {
		var deviceWidth = Screen.width;
		var deviceHeight = Screen.height;

		if (deviceWidth == _lastDeviceWidth && 
		    deviceHeight == _lastDeviceHeight)
			return;

		if ((float)Constants.RESOLUTION_X / Constants.RESOLUTION_Y < (float)deviceWidth / deviceHeight) {
			var newWidth = ((float)Constants.RESOLUTION_X / Constants.RESOLUTION_Y) / ((float)deviceWidth / deviceHeight);
			
			foreach (var camera in Camera.allCameras)
				camera.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f);
		}
		else {
			var newHeight = ((float)deviceWidth / deviceHeight) / ((float)Constants.RESOLUTION_X / Constants.RESOLUTION_Y);
			
			foreach (var camera in Camera.allCameras)
				camera.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight);
		}

		_lastDeviceWidth = deviceWidth;
		_lastDeviceHeight = deviceHeight;
	}
}
