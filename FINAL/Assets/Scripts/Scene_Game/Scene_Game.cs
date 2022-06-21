using System.Collections.Generic;
using UnityEngine;

public class Scene_Game : SceneBase {
	[Header("Camera")]
	[SerializeField]
	private Camera _gameCamera;
	public Camera GameCamera => _gameCamera;
	
	[Header("Player")]
	[SerializeField]
	private PlayerUnit _playerUnit;
	public PlayerUnit PlayerUnit => _playerUnit;
	
	[Header("World")]
	[SerializeField]
	private GameObject _worldCanvas;
	public GameObject WorldCanvas => _worldCanvas;

	[Header("Manager")]
	[SerializeField]
	private PoolManager _poolManager;

	private GameLevelManager _gameLevelManager = new GameLevelManager();
	public GameLevelManager GameLevelManager => _gameLevelManager;
	
	private List<PoolingGameObject> _spawnedPoolingGameObjectList = new List<PoolingGameObject>();

	public void Start() {
		SoundManager.Get().PlayBGM(Constants.Sound.BGM.GAME);

		_gameLevelManager.Init();
	}

	public override void Update() {
		base.Update();
		
		_gameLevelManager.Update();
	}

	public PoolingGameObject Spawn(string key) { 
		var obj = _poolManager.Spawn(key);
		if (obj != null)
			_spawnedPoolingGameObjectList.Add(obj);
		
		return obj;
	}

	public void DeSpawn(PoolingGameObject obj) {
		if (obj == null)
			return;
		
		_poolManager.DeSpawn(obj);
		_spawnedPoolingGameObjectList.Remove(obj);
	}
	
	public void AdjustGamePosition() {
		GameCamera.transform.localPosition = Vector3.zero;
		
		//
		PlayerUnit.transform.Translate(new Vector3(0f, -Constants.RESOLUTION_Y, 0f));
        
		foreach (var obj in _spawnedPoolingGameObjectList) {
			if (obj == null)
				continue;
            
			obj.transform.Translate(new Vector3(0f, -Constants.RESOLUTION_Y, 0f));
		}
		
		//
		_gameLevelManager.AdjustGamePosition();
	}
}
