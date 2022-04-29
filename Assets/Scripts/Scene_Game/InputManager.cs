using UnityEngine;

public class InputManager : MonoBehaviour {
	public void Update() {
		if (Input.GetKey(KeyCode.LeftArrow))
			Scene_Game.Get().PlayerUnit.Move(Vector2.left);
		else if (Input.GetKey(KeyCode.RightArrow))
			Scene_Game.Get().PlayerUnit.Move(Vector2.right);
	}
}
