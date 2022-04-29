using UnityEngine;

public class Scene_Game : MonoBehaviour {
	private static Scene_Game _instance;
	public static Scene_Game Get() { return _instance; }
	
	[Header("World")]
	[SerializeField]
	private PlayerUnit _playerUnitPrefab;
	private PlayerUnit _playerUnit;
	public PlayerUnit PlayerUnit => _playerUnit;
	
	[SerializeField]
	private GameObject _worldCanvas;
	
	public void Awake() {
		_instance = this;
		
		_playerUnit = Instantiate(_playerUnitPrefab, _worldCanvas.transform);
		_playerUnit.transform.localPosition = Vector3.zero;
	}
}
