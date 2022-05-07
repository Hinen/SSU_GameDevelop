public class GameLevelManager {
    private float _gameTimer;
    private float _arrowTimer;
    
    public int Level {
        get {
            return 1;
        }
    }

    public float ArrowTime {
        get {
            if (Level == 1)
                return 0.5f;

            return 1f;
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
        Scene_Game.Get().PoolManager.Spawn(PoolManager.PoolingKey.ARROW);
        
        _arrowTimer = 0f;
    }
}
