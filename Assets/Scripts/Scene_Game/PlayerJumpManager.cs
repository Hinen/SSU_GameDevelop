using UnityEngine;
public class PlayerJumpManager {
	private PlayerUnit _playerUnit;
	
	private bool _isJumping;
	private float _jumpTimer;
	private float _jumpHeight;

	public void Init(PlayerUnit playerUnit) {
		_playerUnit = playerUnit;
		
		_isJumping = false;
		_jumpTimer = 0f;
		_jumpHeight = 0f;
	}

	public void Update() {
		if (!_isJumping)
			return;

		_jumpTimer += Time.deltaTime;
		
		if (_jumpTimer >= Constants.Player.PLAYER_JUMP_UP_TIME) {
			if (_playerUnit.Rigidbody2D.constraints != RigidbodyConstraints2D.None)
				_playerUnit.Rigidbody2D.constraints = RigidbodyConstraints2D.None;
			
			return;
		}

		var addY = (_jumpTimer * _jumpTimer) * 5f + _jumpTimer * 10f + 3f;

		if (_jumpHeight < Constants.Player.PLAYER_JUMP_MAX_HEIGHT) {
			_jumpHeight += addY;
			_playerUnit.GamePosition = new Vector2(_playerUnit.GamePosition.x, 
			                                       _playerUnit.GamePosition.y + addY);
		}
	}

	public void Jump() {
		if (_isJumping)
			return;
		
		_isJumping = true;
		_jumpTimer = 0f;
		_jumpHeight = 0f;

		_playerUnit.Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
	}

	public void JumpEnd() {
		_isJumping = false;
		_jumpTimer = 0f;
		_jumpHeight = 0f;
	}
}
