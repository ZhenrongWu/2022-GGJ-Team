using UnityEngine;

public class BoardGroupController : MonoBehaviour
{
    [SerializeField]             private string _keyCodeUp, _keyCodeDown, _keyCodeChagedColor;
    [Space(10)] [SerializeField] private float  _moveSpeed = 15f;
    [Space(10)] [SerializeField] private string _backgroundName;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        ChangedColor();
    }

    private void ChangedColor()
    {
        if (Input.GetKeyDown(_keyCodeChagedColor))
        {
            ColorScript colorScript = GameObject.Find(_backgroundName).transform.GetComponent<ColorScript>();
            colorScript.IsChangedColor = !colorScript.IsChangedColor;
        }
    }

    private void Move()
    {
        if (Input.GetKeyDown(_keyCodeUp))
        {
            _rigidbody2D.velocity    = Vector2.up * _moveSpeed;
        }
        else if (Input.GetKeyDown(_keyCodeDown))
        {
            _rigidbody2D.velocity    = Vector2.down * _moveSpeed;
        }
    }
}