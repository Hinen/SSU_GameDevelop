using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveButton : MonoBehaviour, 
                                IPointerDownHandler,
                                IPointerUpHandler,
                                IPointerExitHandler {
    public enum Direction {
        NONE,
        LEFT,
        RIGHT
    }

    [SerializeField]
    private Direction _direction;

    public static Direction _clickDirection = Direction.NONE;
    public static Direction ClickDirection => _clickDirection;

    public void OnPointerDown(PointerEventData pointerEventData) {
        _clickDirection = _direction;
    }

    public void OnPointerUp(PointerEventData pointerEventData) {
        ClickEnd();
    }

    public void OnPointerExit(PointerEventData pointerEventData) {
        ClickEnd();
    }

    private void ClickEnd() {
        if (_clickDirection == _direction)
            _clickDirection = Direction.NONE;
    }
}
