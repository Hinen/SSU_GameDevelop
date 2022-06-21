using UnityEngine;

public class PoolingGameObject : MonoBehaviour {
    public Vector2 GamePosition {
        get {
            return gameObject.transform.localPosition;
        }
        set {
            gameObject.transform.localPosition = value;
        }
    }
    
    public string poolingKey { get; set; }

    public virtual void OnSpawned() {
        gameObject.SetActive(true);
    }

    public virtual void OnDeSpawned() {
        gameObject.SetActive(false);
    }
}
