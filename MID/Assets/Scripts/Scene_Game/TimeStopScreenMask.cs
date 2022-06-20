using UnityEngine;
using UnityEngine.UI;

public class TimeStopScreenMask : MonoBehaviour {
    [SerializeField]
    private Image _screenImage;

    public void Update() {
        transform.position = Scene_Game.Get().PlayerUnit.transform.position;
        _screenImage.transform.localPosition = -transform.localPosition;
    }
}
