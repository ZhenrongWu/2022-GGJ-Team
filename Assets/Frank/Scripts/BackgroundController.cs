using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    [SerializeField]                   private Color  _normalColor, _changedColor;
    [Header("UI")] [SerializeField]    private Image  _imgChangedColorCD;
    [SerializeField]                   private float  _maxChangedColorCD;
    [Header("Input")] [SerializeField] private string _keyCodeChagedColor;

    private SpriteRenderer _spriteRenderer;

    private bool  _isChangedColor;
    public  bool  IsChangedColor => _isChangedColor;
    private float _currChangedColorCD;
    private float _lastChangedColorCDTime;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _currChangedColorCD = _maxChangedColorCD;
    }

    private void Update()
    {
        PressKeyCodeChangedColor();
        SetChangedColor();
        DisplayImgChangedColorCD();
        IncreaseCurrChangedColorCD();
    }

    private void SetChangedColor()
    {
        _spriteRenderer.color = _isChangedColor ? _spriteRenderer.color = _changedColor : _normalColor;
    }

    private void PressKeyCodeChangedColor()
    {
        if (Input.GetKeyDown(_keyCodeChagedColor) && JudgeChangedColorCD())
        {
            _isChangedColor = !_isChangedColor;

            DecreaseCurrChangedColorCD();
        }
    }

    public bool JudgeChangedColorCD()
    {
        return _currChangedColorCD >= _maxChangedColorCD;
    }

    private void DisplayImgChangedColorCD()
    {
        float currChangedColorRatio = _currChangedColorCD / _maxChangedColorCD;
        _imgChangedColorCD.fillAmount = Mathf.Lerp(_imgChangedColorCD.fillAmount, currChangedColorRatio, .1f);
    }

    private void DecreaseCurrChangedColorCD()
    {
        _currChangedColorCD--;
        _lastChangedColorCDTime = Time.time;
    }

    private void IncreaseCurrChangedColorCD()
    {
        if (_lastChangedColorCDTime + .5f < Time.time && _currChangedColorCD < _maxChangedColorCD)
        {
            _currChangedColorCD += Time.deltaTime;
            _currChangedColorCD =  Mathf.Clamp(_currChangedColorCD, 0, _maxChangedColorCD);
        }
    }
}