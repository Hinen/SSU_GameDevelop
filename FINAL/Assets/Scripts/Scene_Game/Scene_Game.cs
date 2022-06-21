using System.Collections.Generic;
using UnityEngine;

public class Scene_Game : SceneBase {
	[Header("Player")]
	[SerializeField]
	private GameObject _player;
	public GameObject Player => _player;
	
	[Header("World")]
	[SerializeField]
	private GameObject _worldCanvas;
	public GameObject WorldCanvas => _worldCanvas;

	[Header("Manager")]
	[SerializeField]
	private PoolManager _poolManager;

	private GameLevelManager _gameLevelManager = new GameLevelManager();
	
	private List<PoolingGameObject> _spawnedPoolingGameObjectList = new List<PoolingGameObject>();
	public List<PoolingGameObject> SpawnedPoolingGameObjectList => _spawnedPoolingGameObjectList;
	
	public void Start() {
		SoundManager.Get().PlayBGM(Constants.Sound.BGM.GAME);

		_gameLevelManager.Init();
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
}
