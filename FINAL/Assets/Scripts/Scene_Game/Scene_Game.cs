using UnityEngine;

public class Scene_Game : SceneBase {
	[SerializeField]
	private GameObject _worldCanvas;
	public GameObject WorldCanvas => _worldCanvas;
	
	public void Start() {
		SoundManager.Get().PlayBGM(Constants.Sound.BGM.GAME);
	}
}
