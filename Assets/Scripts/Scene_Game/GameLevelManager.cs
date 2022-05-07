using System;

public class GameLevelManager {
    private float _gameTimer;
    private float _arrowTimer;
    
    public int Level {
        get {
            return 1 + (int)(_gameTimer / 10f);
        }
    }

    public float ArrowTime {
        get {
            return Math.Max(0.3f, 1f - (Level - 1) * 0.1f);
        }
    }

    public int ArrowCount {
        get {
            return Math.Min(4, 1 + Level / 5);
        }
    }

    public GameLevelManager() {
        _gameTimer = 0f;
        _arrowTimer = 0f;
    }
    
    public void Update(float dt) {
        _gameTimer += dt;
        _arrowTimer += dt;

        if (_arrowTimer >= ArrowTime)
            SpawnArrow();
    }

    private void SpawnArrow() {
        for (var i = 0; i < ArrowCount; i++)
            Scene_Game.Get().PoolManager.Spawn(PoolManager.PoolingKey.ARROW);
        
        _arrowTimer = 0f;
    }
}
