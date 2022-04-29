using UnityEngine;

public class Scene_Game : MonoBehaviour {
	[Header("World")]
	[SerializeField]
	private PlayerUnit _playerUnitPrefab;
	private PlayerUnit _playerUnit;
	public PlayerUnit PlayerUnit => _playerUnit;
	
	[SerializeField]
	private GameObject _worldCanvas;
	
	public void Awake() {
		_playerUnit = Instantiate(_playerUnitPrefab, _worldCanvas.transform);
		_playerUnit.transform.localPosition = Vector3.zero;
	}
}
