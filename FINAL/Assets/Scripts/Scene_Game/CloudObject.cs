using System;
using UnityEngine;

public class CloudObject : PoolingGameObject {
    public enum CloudScoreFlag {
        CAN_NOT_GET_SCORE,
        CAN_GET_SCORE_1,
        CAN_GET_SCORE_5,
    }

    private CloudScoreFlag _scoreFlag;
    public CloudScoreFlag ScoreFlag => _scoreFlag;

    public override void OnSpawned() {
        base.OnSpawned();

        InitScoreFlag();
    }

    protected virtual void InitScoreFlag() {
        SetScoreFlag(CloudScoreFlag.CAN_GET_SCORE_1);   
    }
    
    public void Update() {
        if (GamePosition.y <= -Constants.RESOLUTION_Y)
            Scene_Game.Get<Scene_Game>().DeSpawn(this);
    }

    public void SetScoreFlag(CloudScoreFlag scoreFlag) {
        _scoreFlag = scoreFlag;
    }
}
