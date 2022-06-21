using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudObject : PoolingGameObject {
	public Vector2 GamePosition {
		get {
			return gameObject.transform.localPosition;
		}
		set {
			gameObject.transform.localPosition = value;
		}
	}
}
