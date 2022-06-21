using UnityEngine;

public class InputManager : MonoBehaviour {
    private Scene_Game _scene;
    
    public void Start() {
        _scene = Scene_Game.Get<Scene_Game>();
    }
    
    public void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
            _scene.PlayerUnit.Jump();
    }
}
