using UnityEngine;

public class InputManager : MonoBehaviour {
	public void Update() {
		if (PlayerMoveButton.ClickDirection != PlayerMoveButton.Direction.NONE) {
			if (PlayerMoveButton.ClickDirection == PlayerMoveButton.Direction.LEFT)
				Scene_Game.Get().PlayerUnit.Move(Vector2.left);
			else if (PlayerMoveButton.ClickDirection == PlayerMoveButton.Direction.RIGHT)
				Scene_Game.Get().PlayerUnit.Move(Vector2.right);
		}
		else {
			if (Input.GetKey(KeyCode.LeftArrow))
				Scene_Game.Get().PlayerUnit.Move(Vector2.left);
			else if (Input.GetKey(KeyCode.RightArrow))
				Scene_Game.Get().PlayerUnit.Move(Vector2.right);
		}

		if (Input.GetKeyDown(KeyCode.Space))
			Scene_Game.Get().PlayerUnit.UseSkill();
	}
}
