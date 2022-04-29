using UnityEngine;

public class PlayerUnit : MonoBehaviour {
    public Vector2 GamePosition => gameObject.transform.localPosition;
    
    public void Move(Vector2 dir) {
        var moveTranslation = Constants.PLAYER_MOVE_SPEED * dir * Time.deltaTime;
        var adjustValue = 150f;

        if (dir == Vector2.left) {
            if (GamePosition.x + moveTranslation.x <= -Constants.RESOLUTION_X / 2f + adjustValue)
                return;
        }
        else if (dir == Vector2.right) {
            if (GamePosition.x + moveTranslation.x >= Constants.RESOLUTION_X / 2f - adjustValue)
                return;
        }
        
        gameObject.transform.Translate(moveTranslation);
    }
}
