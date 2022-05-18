using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerBarBase : MonoBehaviour {
    [SerializeField]
    private Image _barImage;

    private float _maxValue { get; set; }
    private float _value { get; set; }

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

            _barImage.fillAmount = GetBarFillAmount();
            gameObject.SetActive(IsActiveBar());
        }
    }
    
    protected abstract float GetBarFillAmount();
    protected abstract bool IsActiveBar();

    public void Init(float maxValue) {
        _maxValue = maxValue;
    }
}
