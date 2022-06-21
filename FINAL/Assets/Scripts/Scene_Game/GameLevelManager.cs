using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameLevelManager {
	private Scene_Game _scene;

	private float _lastCloudSpawnPosX = 0f;
	private float _lastCloudSpawnCameraPosY = -50f;

	public void Init() {
		_scene = Scene_Game.Get<Scene_Game>();
		
		// 바닥 구름 4개
		for (var i = 0; i < 4; i++) {
			var cloud = _scene.Spawn(PoolManager.PoolingKey.CLOUD);
			
			cloud.GamePosition = new Vector3(-200f + i * 135f, -100f, 0f);	
		}
		
		var cloud1 = _scene.Spawn(PoolManager.PoolingKey.CLOUD);
		var cloud2 = _scene.Spawn(PoolManager.PoolingKey.CLOUD);
		var cloud3 = _scene.Spawn(PoolManager.PoolingKey.CLOUD);
		
		cloud1.GamePosition = new Vector3(-200f, 100f, 0f);
		cloud2.GamePosition = new Vector3(0f, 300f, 0f);
		cloud3.GamePosition = new Vector3(200f, 500f, 0f);
	}

	public void Update() {
		if (_scene.GameCamera.transform.localPosition.y - _lastCloudSpawnCameraPosY >= Constants.LevelDesign.CLOUD_SPAWN_TERM_Y)
			SpawnCloud();
	}

	public void AdjustGamePosition() {
		_lastCloudSpawnCameraPosY -= Constants.RESOLUTION_Y;
	}
	
	private void SpawnCloud() {
		_lastCloudSpawnCameraPosY = _scene.GameCamera.transform.localPosition.y;
		
		var cloud = _scene.Spawn(PoolManager.PoolingKey.CLOUD);
		if (cloud == null)
			return;

		var loopCount = 3;
		var maxX = (Constants.RESOLUTION_X / 2f) - 50f;
		
		for (int i = 1; i <= loopCount; i++) {
			var newPosX = _lastCloudSpawnPosX + Random.Range(-300f, 300f);

			if (newPosX < -maxX) {
				if (i == loopCount)
					_lastCloudSpawnPosX = -maxX;
					
				continue;
			}

			if (newPosX > maxX) {
				if (i == loopCount)
					_lastCloudSpawnPosX = maxX;
				
				continue;
			}

			_lastCloudSpawnPosX = newPosX;
			break;
		}
		
		
		cloud.GamePosition = new Vector3(_lastCloudSpawnPosX, _lastCloudSpawnCameraPosY + 550f, 0f);
	}
}
