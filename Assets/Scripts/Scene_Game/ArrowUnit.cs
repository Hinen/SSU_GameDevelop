using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ArrowUnit : PoolingGameObject {
    [SerializeField]
    private PolygonCollider2D _collider2D;
    
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

        _collider2D.enabled = true;
        
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
        transform.localPosition = new Vector3( 
            Random.Range(-Constants.BACKGROUND_X_RANGE, Constants.BACKGROUND_X_RANGE),
            Constants.RESOLUTION_Y / 2 + Constants.BACKGROUND_Y_DIFF,
            0f);
    }

    private void SetSpeed() {
        _speed = Random.Range(MinSpeed, MaxSpeed);
    }

    public void AttackToPlayer() {
        _collider2D.enabled = false;
    }
}
