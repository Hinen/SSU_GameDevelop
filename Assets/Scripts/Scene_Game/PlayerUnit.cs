using UnityEngine;

public class PlayerUnit : MonoBehaviour {
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    
    private PlayerJumpManager _playerJumpManager = new PlayerJumpManager();
 
    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    
    public Vector2 GamePosition {
        get {
            return gameObject.transform.localPosition;
        }
        set {
            gameObject.transform.localPosition = value;
        }
    }

    public void Awake() {
        _playerJumpManager.Init(this);
    }
    
    public void Update() {
        _playerJumpManager.Update();
    }
    
    public void Move(Vector2 dir) {
        var moveTranslation = Constants.Player.PLAYER_MOVE_SPEED * dir * Time.deltaTime;
        var adjustValue = 150f;

        if (dir == Vector2.left) {
            if (GamePosition.x + moveTranslation.x <= -Constants.RESOLUTION_X / 2f + adjustValue)
                return;
        }
        else if (dir == Vector2.right) {
            if (GamePosition.x + moveTranslation.x >= Constants.RESOLUTION_X / 2f - adjustValue)
                return;
        }
        
        gameObject.transform.Translate(moveTranslation);
    }

    public void Jump() {
        _playerJumpManager.Jump();
    }

    public void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "Background")
            _playerJumpManager.JumpEnd();
    }
}
