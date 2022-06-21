using System;

public class CloudObject : PoolingGameObject {
    public void Update() {
        if (GamePosition.y <= -Constants.RESOLUTION_Y)
            Scene_Game.Get<Scene_Game>().DeSpawn(this);
    }
}
