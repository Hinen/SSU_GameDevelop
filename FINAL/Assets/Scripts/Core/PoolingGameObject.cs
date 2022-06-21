using UnityEngine;

public class PoolingGameObject : MonoBehaviour {
    public string poolingKey { get; set; }

    public virtual void OnSpawned() {
        gameObject.SetActive(true);
    }

    public virtual void OnDeSpawned() {
        gameObject.SetActive(false);
    }
}
