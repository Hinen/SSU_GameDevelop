using System.Collections;
using DG.Tweening;
using EZCameraShake;
using UnityEngine;
using UnityEngine.UI;

public class Scene_Game : SceneBase {
	private static Scene_Game _instance;
	public static Scene_Game Get() => _instance;
	
	[Header("Player")]
	[SerializeField]
	private JumpPlayerUnit _jumpPlayerUnitPrefab;
	
	[SerializeField]
	private SpeedUpPlayerUnit _speedUpPlayerUnitPrefab;
	
	[SerializeField]
	private TimeStopPlayerUnit _timeStopPlayerUnitPrefab;
	
	private PlayerUnit _playerUnit;
	public PlayerUnit PlayerUnit => _playerUnit;
	
	[Header("World")]
	[SerializeField]
	private GameObject _worldCanvas;

	public GameObject WorldCanvas => _worldCanvas;

	[Header("UI")]
	[SerializeField]
	private Canvas _canvas;
	
	[SerializeField]
	private Image _damagedScreenImage;
	
	[SerializeField]
	private Image _timeStopScreenImagePrefab;
	private Image _timeStopScreenImage;
	public Image TimeStopScreenImage {
		get {
			if (_timeStopScreenImage == null)
				_timeStopScreenImage = Instantiate(_timeStopScreenImagePrefab, _canvas.transform);

			return _timeStopScreenImage;
		}
	}

	[Header("Manager")]
	[SerializeField]
	private PoolManager _poolManager;
	public PoolManager PoolManager =>_poolManager;
	
	private GameLevelManager _gameLevelManager = new GameLevelManager();
	private Coroutine _damagedScreenCoroutine;
	
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
				prefab = _timeStopPlayerUnitPrefab;
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

	public void AttackedEffect() {
		SoundManager.Get().PlayFX(Constants.Sound.FX.ATTACKED);
		CameraShaker.Instance.ShakeOnce(5f, 5f, 0.4f, 0.4f);

		if (_damagedScreenCoroutine != null) {
			DOTween.Kill(_damagedScreenImage);
			StopCoroutine(_damagedScreenCoroutine);
		}

		_damagedScreenCoroutine = StartCoroutine(DamagedScreenCoroutine());
	}

	private IEnumerator DamagedScreenCoroutine() {
		_damagedScreenImage.DOColor(Color.white, 0.2f);
		yield return new WaitForSeconds(0.2f);
		
		_damagedScreenImage.DOColor(new Color(1f, 1f, 1f, 0f), 1f);
		yield return new WaitForSeconds(1f);
		
		_damagedScreenCoroutine = null;
	}
}
