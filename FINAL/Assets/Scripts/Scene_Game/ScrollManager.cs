using UnityEngine;

public class ScrollManager : MonoBehaviour {
    [SerializeField]
    private Camera _gameCamera;

    public void Update() {
        _gameCamera.transform.Translate(Vector3.up * Time.deltaTime * 100f);

        if (_gameCamera.transform.localPosition.y >= Constants.RESOLUTION_Y)
            AdjustGamePosition();
    }

    private void AdjustGamePosition() {
        var scene = Scene_Game.Get<Scene_Game>();
        
        _gameCamera.transform.localPosition = Vector3.zero;
        
        //
        scene.Player.transform.Translate(new Vector3(0f, -Constants.RESOLUTION_Y, 0f));
        
        foreach (var obj in scene.SpawnedPoolingGameObjectList) {
            if (obj == null)
                continue;
            
            obj.transform.Translate(new Vector3(0f, -Constants.RESOLUTION_Y, 0f));
        }
    }
}
