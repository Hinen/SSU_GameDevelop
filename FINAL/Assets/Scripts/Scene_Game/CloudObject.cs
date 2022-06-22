using System;

public class CloudObject : PoolingGameObject {
    public enum Flag {
        CAN_NOT_GET_SCORE,
        CAN_GET_SCORE
    }

    private Flag _flag;

    public override void OnSpawned() {
        base.OnSpawned();

        _flag = Flag.CAN_GET_SCORE;
    }
    
    public void Update() {
        if (GamePosition.y <= -Constants.RESOLUTION_Y)
            Scene_Game.Get<Scene_Game>().DeSpawn(this);
    }

    public void SetFlag(Flag flag) {
        _flag = flag;
    }
}
