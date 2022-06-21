using System;
using UnityEngine;

[Serializable]
public class StringGameObjectDictionary : SerializableDictionary<string, GameObject> { }

[Serializable]
public class StringPoolingGameObjectDictionary : SerializableDictionary<string, PoolingGameObject> { }

[Serializable]
public class StringAudioSourceDictionary : SerializableDictionary<string, AudioSource> { }