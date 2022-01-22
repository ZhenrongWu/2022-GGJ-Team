using UnityEngine;

public class BoardGroupController : MonoBehaviour
{
    [SerializeField] private string _keyCodeChagedColor;

    private bool _havePressKeyCodeChagedColor;
    public  bool HavePressKeyCodeChagedColor => _havePressKeyCodeChagedColor;

    private void Update()
    {
        _havePressKeyCodeChagedColor = Input.GetKeyDown(_keyCodeChagedColor) ? true : false;
    }
}