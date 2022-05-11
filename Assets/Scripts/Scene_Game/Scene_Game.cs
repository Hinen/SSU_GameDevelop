using UnityEngine;

public class Scene_Game : SceneBase {
	private static Scene_Game _instance;
	public static Scene_Game Get() => _instance;
	
	[Header("World")]
	[SerializeField]
	private PlayerUnit _playerUnitPrefab;
	private PlayerUnit _playerUnit;
	public PlayerUnit PlayerUnit => _playerUnit;
	
	[SerializeField]
	private GameObject _worldCanvas;

	public GameObject WorldCanvas => _worldCanvas;


	[Header("Manager")]
	[SerializeField]
	private PoolManager _poolManager;
	public PoolManager PoolManager =>_poolManager;
	
	private GameLevelManager _gameLevelManager = new GameLevelManager();
	
	public override void Awake() {
		base.Awake();
		
		_instance = this;
	}

	public void Start() {
		SoundManager.Get().PlayBGM(Constants.Sound.BGM_GAME);
		
		_playerUnit = Instantiate(_playerUnitPrefab, _worldCanvas.transform);
		_playerUnit.transform.localPosition = Vector3.zero;
	}

	public override void Update() {
		base.Update();
		
		_gameLevelManager.Update(Time.deltaTime);
	}

	public int GetLevel() {
		return _gameLevelManager.Level;
	}
}
