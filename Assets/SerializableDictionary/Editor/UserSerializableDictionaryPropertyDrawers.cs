using UnityEditor;

[CustomPropertyDrawer(typeof(StringGameObjectDictionary))]
[CustomPropertyDrawer(typeof(StringPoolingGameObjectDictionary))]

public class AnySerializableDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer {}
