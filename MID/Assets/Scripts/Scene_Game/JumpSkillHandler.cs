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
		if (_playerJumpManager.Jump())
			SoundManager.Get().PlayFX(Constants.Sound.FX.JUMP);
	}
	
	public override void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "Background")
			_playerJumpManager.JumpEnd();
	}
}
