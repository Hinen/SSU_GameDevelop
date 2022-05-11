using UnityEngine;

public class PlayerSkillHandler {
    protected PlayerUnit _playerUnit;

    public PlayerSkillHandler(PlayerUnit playerUnit) {
        _playerUnit = playerUnit;
    }

    public virtual void Update() {
        
    }
    
    public virtual void UseSkill() {
        
    }

    public virtual void OnCollisionEnter2D(Collision2D col) {
        
    }
}
