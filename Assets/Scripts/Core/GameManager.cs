using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager _instance;
    public static GameManager Get() => _instance;

    private PlayerUnit.PlayerUnitType _selectedPlayerUnitType;
    public PlayerUnit.PlayerUnitType SelectedPlayerUnitType => _selectedPlayerUnitType;

    public void Awake() {
        _instance = this;
        
        DontDestroyOnLoad(this);
    }

    public void SelectCharacter(int index) {
        _selectedPlayerUnitType = (PlayerUnit.PlayerUnitType)index;
    }
}
