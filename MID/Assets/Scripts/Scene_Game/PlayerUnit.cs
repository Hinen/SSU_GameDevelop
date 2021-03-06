using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUnit : MonoBehaviour {
    public enum PlayerUnitType {
        JUMP = 0,
        SPEED_UP = 1,
        TIME_STOP = 2
    }

    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;

    [SerializeField]
    private PlayerHPBar _playerHpBar;

    protected PlayerSkillHandler _playerSkillHandler;
    
    private float _moveSpeed = Constants.Player.PLAYER_DEFAULT_MOVE_SPEED;

    private bool _isInvincible = false;

    public Vector2 GamePosition {
        get {
            return gameObject.transform.localPosition;
        }
        set {
            gameObject.transform.localPosition = value;
        }
    }

    public void Start() {
        StartCoroutine(Animation());
    }

    private IEnumerator Animation() {
        _spriteRenderer.transform.DORotate(new Vector3(0f, 0f, 5f), 0.3f);
        yield return new WaitForSeconds(0.5f);
        
        _spriteRenderer.transform.DORotate(new Vector3(0f, 0f, -5f), 0.3f);
        yield return new WaitForSeconds(0.5f);
        
        StartCoroutine(Animation());
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
                Attacked(col.GetComponentInParent<ArrowUnit>());
                break;
        }
    }

    public void OnCollisionEnter2D(Collision2D col) {
        _playerSkillHandler.OnCollisionEnter2D(col);
    }

    public void SetMoveSpeed(float value) {
        _moveSpeed = value;
    }

    private void Attacked(ArrowUnit arrowUnit) {
        if (_isInvincible)
            return;
        
        if (_playerHpBar.Hp <= 0)
            return;

        Scene_Game.Get().PoolManager.DeSpawn(arrowUnit);
        
        _isInvincible = true;
        Timer.Get().RegistTimer(0.3f, () => _isInvincible = false);

        Scene_Game.Get().AttackedEffect();
        StartCoroutine(HurtEffectCoroutine());

        _playerHpBar.Hp -= 20;
        if (_playerHpBar.Hp <= 0)
            Dead();
    }

    private void Dead() {
        GameManager.Get().gameScore = Scene_Game.Get().GetGameTime();
        
        SceneManager.LoadScene(Constants.SceneName.SCENE_GAME_END);
    }

    private IEnumerator HurtEffectCoroutine() {
        _spriteRenderer.material.DOColor(Color.red, 0.2f);
        yield return new WaitForSeconds(0.2f);
        
        _spriteRenderer.material.DOColor(Color.white, 0.2f);
        yield return new WaitForSeconds(0.2f);
    }
}
