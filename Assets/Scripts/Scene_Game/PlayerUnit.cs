using UnityEngine;
using UnityEngine.UI;
public class PlayerUnit : MonoBehaviour {
    public enum PlayerUnitType {
        JUMP = 0,
        SPEED_UP = 1,
        TIME_STOP = 2
    }

    [SerializeField]
    private Sprite[] _playerSprites;
    
    [SerializeField]
    private SpriteRenderer _playerSpriteRenderer;
    
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    
    private PlayerSkillHandler _playerSkillHandler;
 
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
        _playerSpriteRenderer.sprite = _playerSprites[(int)GameManager.Get().SelectedPlayerUnitType];
        
        switch (GameManager.Get().SelectedPlayerUnitType) {
            case PlayerUnitType.JUMP:
                _playerSkillHandler = new JumpSkillHandler(this);
                break;
            case PlayerUnitType.SPEED_UP:
                _playerSkillHandler = new PlayerSkillHandler(this);
                break;
            case PlayerUnitType.TIME_STOP:
                _playerSkillHandler = new PlayerSkillHandler(this);
                break;
        }
    }
    
    public void Update() {
        _playerSkillHandler.Update();
    }
    
    public void Move(Vector2 dir) {
        var moveTranslation = Constants.Player.PLAYER_MOVE_SPEED * dir * Time.deltaTime;
        
        if (dir == Vector2.left) {
            if (GamePosition.x + moveTranslation.x <= -Constants.BACKGROUND_X_RANGE)
                return;
        }
        else if (dir == Vector2.right) {
            if (GamePosition.x + moveTranslation.x >= Constants.BACKGROUND_X_RANGE)
                return;
        }
        
        gameObject.transform.Translate(moveTranslation);
    }

    public void UseSkill() {
        _playerSkillHandler.UseSkill();
    }

    public void OnCollisionEnter2D(Collision2D col) {
        _playerSkillHandler.OnCollisionEnter2D(col);
    }
}
