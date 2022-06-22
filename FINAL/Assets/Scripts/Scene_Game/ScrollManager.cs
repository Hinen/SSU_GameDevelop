using UnityEngine;

public class ScrollManager : MonoBehaviour {
    private Scene_Game _scene;

    public void Start() {
        _scene = Scene_Game.Get<Scene_Game>();
    }

    public void LateUpdate() {
        _scene.GameCamera.transform.Translate(Vector3.up * Time.deltaTime * _scene.GameLevelManager.ScrollSpeed);

        var cameraPosY = _scene.GameCamera.transform.localPosition.y;
        if (cameraPosY >= Constants.RESOLUTION_Y)
            _scene.AdjustGamePosition();
    }
}
