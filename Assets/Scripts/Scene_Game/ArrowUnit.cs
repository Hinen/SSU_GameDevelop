using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ArrowUnit : PoolingGameObject {
    private float _speed;

    private float MinSpeed {
        get {
            var level = Scene_Game.Get().GetLevel();
            return Math.Min(1200f, 500f + (level - 1) * 60f);
        }
    }

    private float MaxSpeed {
        get {
            var level = Scene_Game.Get().GetLevel();
            return Math.Min(1600f, 800f + (level - 1) * 80f);
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
        if (GamePosition.y <= -Constants.BACKGROUND_Y_DIFF / 2f) {
            Scene_Game.Get().PoolManager.DeSpawn(this);
            return;
        }

        transform.Translate(new Vector2(0f, -_speed * Time.deltaTime));
    }

    private void SetRandomPosition() {
        var rangeX = Constants.RESOLUTION_X / 2 - 40f;
        
        transform.localPosition = new Vector3( 
            Random.Range(-rangeX, rangeX),
            Constants.RESOLUTION_Y / 2 + Constants.BACKGROUND_Y_DIFF,
            0f);
    }

    private void SetSpeed() {
        _speed = Random.Range(MinSpeed, MaxSpeed);
    }
}
