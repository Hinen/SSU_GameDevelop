using UnityEngine;

public class PlayerHPBar : PlayerBarBase {
    [SerializeField]
    private float _maxHP;
    
    public float Hp {
        get {
            return Value;
        }
        set {
            Value = value;
        }
    }
    
     public void Awake() {
        Init(_maxHP);
    }
}
