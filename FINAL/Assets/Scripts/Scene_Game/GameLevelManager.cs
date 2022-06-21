using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelManager {
	public void Init() {
		for (var i = 0; i < 4; i++) {
			var cloud = Scene_Game.Get<Scene_Game>().PoolManager.Spawn(PoolManager.PoolingKey.CLOUD);
			
			cloud.GamePosition = new Vector3(-2f + i * 1.35f, -3f, 0f);	
		}
	}
}
