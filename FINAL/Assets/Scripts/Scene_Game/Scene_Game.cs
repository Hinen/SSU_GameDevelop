using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

	[Header("UI")]
	[SerializeField]
	private Text _scoreText;

	[Header("Manager")]
	[SerializeField]
	private PoolManager _poolManager;

	private readonly GameLevelManager _gameLevelManager = new GameLevelManager();
	public GameLevelManager GameLevelManager => _gameLevelManager;
	
	private readonly List<PoolingGameObject> _spawnedPoolingGameObjectList = new List<PoolingGameObject>();

	public void Start() {
		SoundManager.Get().PlayBGM(Constants.Sound.BGM.GAME);

		_gameLevelManager.Init();

		GameManager.Get().Score = 0;
	}

	public override void Update() {
		base.Update();
		
		_gameLevelManager.Update();
		
		CheckGameOver();
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

	public void AddScore(int score) {
		SoundManager.Get().PlayFX(Constants.Sound.FX.SCORE);
		
		GameManager.Get().Score += score;
		_scoreText.text = GameManager.Get().Score.ToString();
	}
	
	private void CheckGameOver() {
		var cameraPosY = GameCamera.transform.localPosition.y;
		var playerPosY = PlayerUnit.transform.localPosition.y;
		if (cameraPosY - playerPosY > (Constants.RESOLUTION_Y / 2) + 50f)
			GameOver();
	}

	private void GameOver() {
		SoundManager.Get().PlayFX(Constants.Sound.FX.CAT);
		
		SceneManager.LoadScene(Constants.SceneName.SCENE_RESULT);
	}
}
