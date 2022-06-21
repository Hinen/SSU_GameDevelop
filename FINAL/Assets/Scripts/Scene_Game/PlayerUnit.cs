using System;
using UnityEngine;

public class PlayerUnit : UnitBase {
	[SerializeField]
	private Rigidbody2D _rigidbody2D;

	public void Move(Vector2 dir) {
		if (_rigidbody2D.velocity.x >= 0 && dir.x > 0 ||
		    _rigidbody2D.velocity.x <= 0 && dir.x < 0) {
			if (Math.Abs(_rigidbody2D.velocity.x) > Constants.Player.MAX_MOVE_VELOCITY)
				return;
		}
			
			
		_rigidbody2D.AddForce(dir * Constants.Player.MOVE_SPEED);
	}

	public void Jump() {
		_rigidbody2D.AddForce(Vector2.up * Constants.Player.JUMP_POWER, ForceMode2D.Impulse);
	}
}
