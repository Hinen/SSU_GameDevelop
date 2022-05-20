using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ArrowUnit : PoolingGameObject {
    private float _speed;

    private float MinSpeed {
        get {
            var level = Scene_Game.Get().GetLevel();
            return Math.Min(900f, 400f + (level - 1) * 30f);
        }
    }

    private float MaxSpeed {
        get {
            var level = Scene_Game.Get().GetLevel();
            return Math.Min(1500f, 500f + (level - 1) * 50f);
        }
    }
    
    public Vector2 GamePosition {
        get {
            return gameObject.transform.localPosition;
        }
        set {
            gameObject.transform.localPosition = value;
        }
    }
    
    public override void OnSpawned() {
        base.OnSpawned();
        
        SetRandomPosition();
        SetSpeed();
    }

    public void Update() {
        if (GameManager.Get().isGamePauseByStopTimeSkill)
            return;
        
        if (GamePosition.y <= -Constants.BACKGROUND_Y_DIFF - 10f) {
            Scene_Game.Get().PoolManager.DeSpawn(this);
            return;
        }

        transform.Translate(new Vector2(0f, -_speed * Time.deltaTime));
    }

    private void SetRandomPosition() {
        var isSpawnPlayerPosX = Random.Range(0f, 1f) > 0.8f;
        var x = isSpawnPlayerPosX
                    ? Scene_Game.Get().PlayerUnit.GamePosition.x
                    : Random.Range(-Constants.BACKGROUND_X_RANGE, Constants.BACKGROUND_X_RANGE);
        
        transform.localPosition = new Vector3(x, Constants.RESOLUTION_Y / 2 + Constants.BACKGROUND_Y_DIFF, 0f);
    }

    private void SetSpeed() {
        _speed = Random.Range(MinSpeed, MaxSpeed);
    }
}
