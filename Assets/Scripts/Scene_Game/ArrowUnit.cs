using UnityEngine;

public class ArrowUnit : PoolingGameObject {
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
    }

    public void Update() {
        if (GamePosition.y <= -Constants.BACKGROUND_Y_DIFF / 2f) {
            PoolManager.Get().DeSpawn(this);
            return;
        }

        transform.Translate(new Vector2(0f, -Constants.Arrow.ARROW_MOVE_SPEED * Time.deltaTime));
    }

    private void SetRandomPosition() {
        transform.localPosition = new Vector3( 
            Random.Range(-Constants.RESOLUTION_X / 2, Constants.RESOLUTION_X / 2),
            Constants.RESOLUTION_Y / 2 + Constants.BACKGROUND_Y_DIFF,
            0f);
    }
}
