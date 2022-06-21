using UnityEngine;

public class PlayerUnit : UnitBase {
	[SerializeField]
	private Rigidbody2D _rigidbody2D;
	
	public void Jump() {
		_rigidbody2D.AddForce(Vector3.up * Constants.Player.JUMP_POWER, ForceMode2D.Impulse);
	}
}
