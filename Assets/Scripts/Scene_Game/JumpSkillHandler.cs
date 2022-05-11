using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSkillHandler : PlayerSkillHandler {
	private PlayerJumpManager _playerJumpManager = new PlayerJumpManager();

	public JumpSkillHandler(PlayerUnit playerUnit) : base(playerUnit) {
		_playerJumpManager.Init(playerUnit);
	}

	public override void Update() {
		_playerJumpManager.Update();
	}

	public override void UseSkill() {
		_playerJumpManager.Jump();
	}
	
	public override void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "Background")
			_playerJumpManager.JumpEnd();
	}
}
