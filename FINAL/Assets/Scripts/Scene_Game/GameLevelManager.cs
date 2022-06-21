using UnityEngine;

public class GameLevelManager {
	public void Init() {
		for (var i = 0; i < 4; i++) {
			var cloud = Scene_Game.Get<Scene_Game>().Spawn(PoolManager.PoolingKey.CLOUD);
			
			cloud.GamePosition = new Vector3(-200f + i * 135f, -100f, 0f);	
		}
	}
}
