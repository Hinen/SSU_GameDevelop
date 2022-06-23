using System;
using UnityEngine;

public class PlayerUnit : UnitBase {
	private enum PlayerState {
		IDLE,
		WALK,
		JUMP
	}
	
	[SerializeField]
	private Rigidbody2D _rigidbody2D;
	
	[SerializeField]
	private Animator _animator;

	private PlayerState _state = PlayerState.IDLE;
	private PlayerState State {
		get {
			return _state;
		}
		set {
			if (_state != value) {
				if (value == PlayerState.IDLE)
					_animator.SetTrigger("IDLE");
				else if (value == PlayerState.WALK)
					_animator.SetTrigger("WALK");
				else if (value == PlayerState.JUMP)
					_animator.SetTrigger("JUMP");
			}
			
			_state = value;
		}
	}
	
	private Scene_Game _scene;

	public void Start() {
		_scene = Scene_Game.Get<Scene_Game>();
	}
	
	public void Update() {
		UpdateState();
	}

	private void UpdateState() {
		if (State == PlayerState.JUMP) {
			if (_rigidbody2D.velocity.y == 0f) {
				if (_rigidbody2D.velocity.x == 0f)
					State = PlayerState.IDLE;
				else
					State = PlayerState.WALK;
			}
		}
		else if (State == PlayerState.WALK) {
			if (_rigidbody2D.velocity.x == 0f)
				State = PlayerState.IDLE;
		}
		else if (State == PlayerState.IDLE) {
			if (_rigidbody2D.velocity.x != 0f)
				State = PlayerState.WALK;
		}
	}
	
	public void Move(Vector2 dir) {
		gameObject.transform.localScale = new Vector3(dir.x, 1f, 1f);
		
		if (_rigidbody2D.velocity.x >= 0 && dir.x > 0 ||
		    _rigidbody2D.velocity.x <= 0 && dir.x < 0) {
			if (Math.Abs(_rigidbody2D.velocity.x) > Constants.Player.MAX_MOVE_VELOCITY)
				return;
		}
		
		_rigidbody2D.AddForce(dir * Constants.Player.MOVE_SPEED);
	}

	public void Jump() {
		if (_rigidbody2D.velocity.y != 0f)
			return;

		State = PlayerState.JUMP;
		SoundManager.Get().PlayFX(Constants.Sound.FX.JUMP);
		
		_rigidbody2D.AddForce(Vector2.up * Constants.Player.JUMP_POWER, ForceMode2D.Impulse);
	}
	
	public void OnTriggerEnter2D(Collider2D collider2D) {
		var cloudObject = collider2D.GetComponentInParent<CloudObject>();
		if (cloudObject == null)
			return;
		
		if (cloudObject.ScoreFlag == CloudObject.CloudScoreFlag.CAN_NOT_GET_SCORE)
			return;

		_scene.AddScore(cloudObject.ScoreFlag == CloudObject.CloudScoreFlag.CAN_GET_SCORE_5 ? 5 : 1);
		cloudObject.SetScoreFlag(CloudObject.CloudScoreFlag.CAN_NOT_GET_SCORE);
	}
}
