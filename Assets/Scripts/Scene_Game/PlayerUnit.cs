using UnityEngine;

public class PlayerUnit : MonoBehaviour {
    public void Move(Vector2 dir) {
        gameObject.transform.Translate(Constants.PLAYER_MOVE_SPEED * dir * Time.deltaTime);
    }
}
