using System;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    [SerializeField] private BoardGroupController _boardGroupController;

    private ColorScript _colorScript;

    private void Start()
    {
        _colorScript = GetComponent<ColorScript>();
    }

    private void Update()
    {
        if (_boardGroupController.HavePressKeyCodeChagedColor)
        {
            ChangedColor();
        }
    }

    private void ChangedColor()
    {
        _colorScript.IsChangedColor = !_colorScript.IsChangedColor;
    }
}