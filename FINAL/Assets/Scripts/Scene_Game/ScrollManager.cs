using UnityEngine;

public class ScrollManager : MonoBehaviour {
    [SerializeField]
    private SpriteRenderer[] _backgroundSpriteList;
    
    private Scene_Game _scene;

    public void Start() {
        _scene = Scene_Game.Get<Scene_Game>();
    }

    public void LateUpdate() {
        _scene.GameCamera.transform.Translate(Vector3.up * Time.deltaTime * _scene.GameLevelManager.ScrollSpeed);

        for (var i = 0; i < _backgroundSpriteList.Length; i++) {
            var background = _backgroundSpriteList[i];
            if (background.transform.localPosition.y >= Constants.RESOLUTION_Y * 2) {
                var nextBackground = _backgroundSpriteList[i == _backgroundSpriteList.Length - 1 ? 0 : i + 1];
                background.transform.localPosition = new Vector2(0f, nextBackground.transform.localPosition.y - Constants.RESOLUTION_Y);
            }
            else {
                background.transform.Translate(Vector3.up * Time.deltaTime * _scene.GameLevelManager.ScrollSpeed / 4f);
            }
        }
        
        var cameraPosY = _scene.GameCamera.transform.localPosition.y;
        if (cameraPosY >= Constants.RESOLUTION_Y)
            _scene.AdjustGamePosition();
    }
}
