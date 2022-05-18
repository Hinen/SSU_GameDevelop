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
        Value = _maxHP;
     }

     protected override float GetBarFillAmount() { 
         return Value / _maxHP;
     }
    
     protected override bool IsActiveBar() {
         return Value != _maxHP;
     }
}
