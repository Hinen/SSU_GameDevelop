using UnityEngine;

public class Scene_Game : SceneBase {
	[Header("World")]
	[SerializeField]
	private GameObject _worldCanvas;
	public GameObject WorldCanvas => _worldCanvas;

	[Header("Manager")]
	[SerializeField]
	private PoolManager _poolManager;
	public PoolManager PoolManager => _poolManager;

	private GameLevelManager _gameLevelManager = new GameLevelManager();
	
	public void Start() {
		SoundManager.Get().PlayBGM(Constants.Sound.BGM.GAME);

		_gameLevelManager.Init();
	}
}
