using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {
	[Header("Pooling Target")]
	[SerializeField]
	private StringPoolingGameObjectDictionary _poolingTarget;

	private Dictionary<string, Queue<PoolingGameObject>> _pool = new Dictionary<string, Queue<PoolingGameObject>>();

	private static PoolManager _instance;
	public static PoolManager Get() {
		return _instance;
	}

	public void Awake() {
		_instance = this;
	}
	
	public PoolingGameObject Spawn(string key) {
		if (!_poolingTarget.ContainsKey(key))
			return null;

		if (!_pool.ContainsKey(key))
			_pool[key] = new Queue<PoolingGameObject>();
		
		var obj = _pool[key].Dequeue();
		if (obj == null)
			obj = Instantiate(_poolingTarget[key]);

		obj.OnSpawned();
		return obj;
	}

	public void DeSpawn(PoolingGameObject obj) {
		var key = obj.poolingKey;
		if (!_poolingTarget.ContainsKey(key))
			return;
		
		if (!_pool.ContainsKey(key))
			_pool[key] = new Queue<PoolingGameObject>();
		
		_pool[key].Enqueue(obj);
		obj.OnDeSpawned();
	}
}
