using UnityEngine;
using UnityEngine.UI;

public class ColorController : MonoBehaviour
{
    [SerializeField]                   private Color      _normalColor, _changedColor;
    [Header("Input")] [SerializeField] private string     _keyCodeChagedColor;
    [Header("UI")] [SerializeField]    private Image      _imgChangedColorCD;
    [SerializeField]                   private float      _maxChangedColorCD;
    [Header("Other")] [SerializeField] private GameObject _boardGroup;

    private SpriteRenderer    _spriteRenderer;
    // private BoardController[] _boardControllers;

    private bool           _isChangedColor;
    private float          _currChangedColorCD;
    private float          _lastChangedColorCDTime;
    private SpriteRenderer _boardSpriteRenderer;

    private void Start()
    {
        _spriteRenderer   = GetComponent<SpriteRenderer>();
        // _boardControllers = _boardGroup.GetComponentsInChildren<BoardController>();

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

        // foreach (var boardController in _boardControllers)
        // {
        //     _boardSpriteRenderer = boardController.GetComponent<SpriteRenderer>();
        //     _boardSpriteRenderer.color = _isChangedColor
        //         ? _boardSpriteRenderer.color = _normalColor
        //         : _changedColor;
        // }
    }

    private void PressKeyCodeChangedColor()
    {
        if (Input.GetKeyDown(_keyCodeChagedColor) && _currChangedColorCD >= _maxChangedColorCD)
        {
            _isChangedColor = !_isChangedColor;

            DecreaseCurrChangedColorCD();
        }
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