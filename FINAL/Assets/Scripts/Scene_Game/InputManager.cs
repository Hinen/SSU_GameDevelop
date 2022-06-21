using UnityEngine;

public class InputManager : MonoBehaviour {
    private Scene_Game _scene;
    
    public void Start() {
        _scene = Scene_Game.Get<Scene_Game>();
    }
    
    public void Update() {
        if (Input.GetKey(KeyCode.LeftArrow))
            _scene.PlayerUnit.Move(Vector2.left);
        else if (Input.GetKey(KeyCode.RightArrow))
            _scene.PlayerUnit.Move(Vector2.right);
        
        if (Input.GetKeyDown(KeyCode.Space))
            _scene.PlayerUnit.Jump();
    }
}
