using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour {
    [SerializeField]
    private Image _hpBarImage;
    
    private int _hp;
    
    public int Hp {
        get {
            return _hp;
        }
        set {
            _hp = value;
            
            if (_hp > Constants.Player.PLAYER_MAX_HP)
                _hp = Constants.Player.PLAYER_MAX_HP;

            if (_hp < 0)
                _hp = 0;
            
            _hpBarImage.fillAmount = (float)_hp / Constants.Player.PLAYER_MAX_HP;
            gameObject.SetActive(_hp != Constants.Player.PLAYER_MAX_HP);
        }
    }
    
    public void Awake() {
        Hp = 100;
    }
}
