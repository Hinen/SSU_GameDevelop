using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerBarBase : MonoBehaviour {
    [SerializeField]
    private Image _barImage;

    protected float _maxValue { get; set; }
    protected float _value { get; set; }

    protected float Value {
        get {
            return _value;
        }
        set {
            _value = value;
            
            if (_value > _maxValue)
                _value = _maxValue;

            if (_value < 0)
                _value = 0;
            
            _barImage.fillAmount = _value / _maxValue;
            gameObject.SetActive(_value != _maxValue);
        }
    }

    public void Init(float maxValue) {
        _maxValue = maxValue;
        Value = maxValue;
    }
}
