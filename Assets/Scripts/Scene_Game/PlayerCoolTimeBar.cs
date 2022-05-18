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
        Value = 0f;
    }

    public void Update() {
        if (Value > 0f)
            Value -= Time.deltaTime;
    }

    protected override float GetBarFillAmount() {
        return (_maxCoolTime - Value) / _maxCoolTime;
    }
    
    protected override bool IsActiveBar() {
        return Value > 0f;
    }
}
