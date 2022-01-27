using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    [SerializeField] private Color                _normalColor, _changedColor;
    [SerializeField] private BoardGroupController _boardGroupController;

    private SpriteRenderer _spriteRenderer;

    private bool _isChangedColor;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_boardGroupController.HavePressKeyCodeChange)
        {
            _isChangedColor = !_isChangedColor;

            SetColor();
        }
    }

    private void SetColor()
    {
        _spriteRenderer.color = _isChangedColor ? _spriteRenderer.color = _changedColor : _normalColor;
    }
}