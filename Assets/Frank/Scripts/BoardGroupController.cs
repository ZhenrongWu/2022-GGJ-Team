using UnityEngine;

public class BoardGroupController : MonoBehaviour
{
    [SerializeField]             private string _keyCodeUp, _keyCodeDown, _keyCodeChagedColor;
    [Space(10)] [SerializeField] private float  _moveSpeed;
    [Space(10)] [SerializeField] private string _backgroundName;

    private Rigidbody2D _rigidbody2D;

    private bool _isUp;
    private bool _isDown;

    public bool IsUp   => _isUp;
    public bool IsDown => _isDown;

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
        if (Input.GetKey(_keyCodeUp))
        {
            _rigidbody2D.velocity = Vector2.up * _moveSpeed;

            _isUp   = true;
            _isDown = false;
        }
        else if (Input.GetKey(_keyCodeDown))
        {
            _rigidbody2D.velocity = Vector2.down * _moveSpeed;

            _isUp   = false;
            _isDown = true;
        }
        else
        {
            _rigidbody2D.velocity = Vector2.zero;

            _isUp   = false;
            _isDown = false;
        }
    }
}