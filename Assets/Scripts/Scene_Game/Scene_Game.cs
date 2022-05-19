using UnityEngine;

public class Scene_Game : SceneBase {
	private static Scene_Game _instance;
	public static Scene_Game Get() => _instance;
	
	[Header("World")]
	[SerializeField]
	private JumpPlayerUnit _jumpPlayerUnitPrefab;
	
	[SerializeField]
	private SpeedUpPlayerUnit _speedUpPlayerUnitPrefab;
	
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
		_instance = this;
		
		base.Awake();
	}

	public void Start() {
		SoundManager.Get().PlayBGM(Constants.Sound.BGM.GAME);
		
		CreateUnit();
	}

	private void CreateUnit() {
		PlayerUnit prefab = _jumpPlayerUnitPrefab;

		switch (GameManager.Get().SelectedPlayerUnitType) {
			case PlayerUnit.PlayerUnitType.JUMP:
				prefab = _jumpPlayerUnitPrefab;
				break;
			case PlayerUnit.PlayerUnitType.SPEED_UP:
				prefab = _speedUpPlayerUnitPrefab;
				break;
			case PlayerUnit.PlayerUnitType.TIME_STOP:
				//prefab = _jumpPlayerUnitPrefab;
				break;
		}

		_playerUnit = Instantiate(prefab, _worldCanvas.transform);
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
