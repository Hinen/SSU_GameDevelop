using System;

public class GameLevelManager {
    private float _gameTimer;
    public float GameTimer => (float)Math.Round(_gameTimer, 1);

    private float _arrowTimer;
    
    public int Level {
        get {
            return 1 + (int)(_gameTimer / 5f);
        }
    }

    public float ArrowTime {
        get {
            return Math.Max(0.2f, 0.7f - (Level - 1) * 0.05f);
        }
    }

    private int _manyArrowCount;
    public int ArrowCount {
        get {
            return Math.Min(4, 1 + Level / 10);
        }
    }

    public GameLevelManager() {
        _gameTimer = 0f;
        _arrowTimer = 0f;
    }
    
    public void Update(float dt) {
        if (GameManager.Get().isGamePauseByStopTimeSkill)
            return;
        
        _gameTimer += dt;
        _arrowTimer += dt;

        if (_arrowTimer >= ArrowTime)
            SpawnArrow();
    }

    private void SpawnArrow() {
        var arrowCount = _manyArrowCount >= 5 ? ArrowCount : 1;
        _manyArrowCount = _manyArrowCount >= 5 ? 0 : _manyArrowCount + 1;
        
        for (var i = 0; i < arrowCount; i++)
            Scene_Game.Get().PoolManager.Spawn(PoolManager.PoolingKey.ARROW);

        _arrowTimer = 0f;
    }
}
