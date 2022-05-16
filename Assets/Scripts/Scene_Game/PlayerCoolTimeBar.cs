using UnityEngine;

public class PlayerCoolTimeBar : PlayerBarBase {
    [SerializeField]
    private float _maxCoolTime;

    public float MaxCoolTime => _maxCoolTime;

    public float CoolTime {
        get {
            return Value;
        }
        set {
            Value = value;
        }
    }
    
    public void Awake() {
        Init(_maxCoolTime);
    }
}
