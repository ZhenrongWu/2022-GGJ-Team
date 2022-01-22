using UnityEngine;

public class ColorScript : MonoBehaviour
{
    [SerializeField] private Color _normalColor, _changedColor;

    private SpriteRenderer _spriteRenderer;

    private bool _isChangedColor;

    public bool IsChangedColor
    {
        get => _isChangedColor;
        set => _isChangedColor = value;
    }


    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
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
}