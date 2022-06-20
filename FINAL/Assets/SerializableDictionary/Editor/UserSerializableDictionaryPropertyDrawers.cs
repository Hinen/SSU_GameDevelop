using UnityEditor;

[CustomPropertyDrawer(typeof(StringGameObjectDictionary))]
[CustomPropertyDrawer(typeof(StringAudioSourceDictionary))]

public class AnySerializableDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer {}
