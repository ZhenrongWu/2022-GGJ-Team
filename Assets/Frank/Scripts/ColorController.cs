using UnityEngine;

public class ColorController : MonoBehaviour
{
    [SerializeField] private Color _normalColor, _changedColor;

    [Header("Input")] [SerializeField] private string _keyCodeChagedColor;

    private SpriteRenderer _spriteRenderer;

    private bool _isChangedColor;
    private bool _havePressKeyCodeChagedColor;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        PressKeyCodeChangedColor();
        SetChangedColor();
    }

    private void SetChangedColor()
    {
        if (_isChangedColor)
        {
            _spriteRenderer.color = _changedColor;
        }
        else
        {
            _spriteRenderer.color = _normalColor;
        }
    }

    private void PressKeyCodeChangedColor()
    {
        if (Input.GetKeyDown(_keyCodeChagedColor))
        {
            _isChangedColor = !_isChangedColor;
        }
    }
}