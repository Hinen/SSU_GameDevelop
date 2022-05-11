using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class SpeedUpSkillHandler : PlayerSkillHandler {
	public SpeedUpSkillHandler(PlayerUnit playerUnit) : base(playerUnit) {
		
	}
	
	public override void Update() {
        
	}
	
	public override void UseSkill() {
		_playerUnit.SetMoveSpeed(Constants.Player.PLAYER_SPEED_UP_MOVE_SPEED);
        
		Timer.Get().RegistTimer(5f, () => {
			if (_playerUnit != null)
				_playerUnit.SetMoveSpeed(Constants.Player.PLAYER_DEFAULT_MOVE_SPEED);
		});
	}
}
