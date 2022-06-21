using UnityEditor;

[CustomPropertyDrawer(typeof(StringGameObjectDictionary))]
[CustomPropertyDrawer(typeof(StringPoolingGameObjectDictionary))]
[CustomPropertyDrawer(typeof(StringAudioSourceDictionary))]

public class AnySerializableDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer {}
