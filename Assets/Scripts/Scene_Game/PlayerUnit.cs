using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUnit : MonoBehaviour {
    public enum PlayerUnitType {
        JUMP = 0,
        SPEED_UP = 1,
        TIME_STOP = 2
    }
    
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;

    [SerializeField]
    private PlayerHPBar _playerHpBar;
    public PlayerHPBar PlayerHpBar => _playerHpBar;

    protected PlayerSkillHandler _playerSkillHandler;
    
    private float _moveSpeed = Constants.Player.PLAYER_DEFAULT_MOVE_SPEED;

    public Vector2 GamePosition {
        get {
            return gameObject.transform.localPosition;
        }
        set {
            gameObject.transform.localPosition = value;
        }
    }

    public virtual void Awake() {
        
    }
    
    public void Update() {
        _playerSkillHandler.Update();
    }
    
    public void Move(Vector2 dir) {
        var moveTranslation = _moveSpeed * dir * Time.deltaTime;
        
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

    public virtual void UseSkill() {
        _playerSkillHandler.UseSkill();
    }
    
    public void OnTriggerEnter2D(Collider2D col) {
        switch (col.gameObject.tag) {
            case "ArrowCollision":
                Attacked();
                break;
        }
    }

    public void OnCollisionEnter2D(Collision2D col) {
        _playerSkillHandler.OnCollisionEnter2D(col);
    }

    public void SetMoveSpeed(float value) {
        _moveSpeed = value;
    }

    private void Attacked() {
        if (_playerHpBar.Hp <= 0)
            return;
        
        SoundManager.Get().PlayFX(Constants.Sound.FX.ATTACKED);
        _playerHpBar.Hp -= 20;

        if (_playerHpBar.Hp <= 0)
            Dead();
    }

    private void Dead() {
        SceneManager.LoadScene(Constants.SceneName.SCENE_TITLE);
    }
}
