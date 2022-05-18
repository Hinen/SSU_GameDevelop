using UnityEngine;

public class CoolTimeSkillPlayerUnit : PlayerUnit {
    [SerializeField]
    private PlayerCoolTimeBar _playerCoolTimeBar;
    
    public override void UseSkill() {
	    if (_playerCoolTimeBar.CoolTime > 0f)
		    return;

        _playerCoolTimeBar.CoolTime = _playerCoolTimeBar.MaxCoolTime;
        
        base.UseSkill();
    }
}
