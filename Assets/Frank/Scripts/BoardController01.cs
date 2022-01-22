using UnityEngine;

public class BoardController01 : MonoBehaviour
{
    [SerializeField]             private string               _keyCodeUp, _keyCodeDown, _keyCodeChagedColor;
    [Space(10)] [SerializeField] private float                _moveSpeed;
    [Space(10)] [SerializeField] private SpriteRenderer       _shieldSpriteRender;
    [Space(10)] [SerializeField] private BackgroundController _backgroundController;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        SetShield();
    }

    private void SetShield()
    {
        if (Input.GetKeyDown(_keyCodeChagedColor) && _backgroundController.JudgeChangedColorCD())
        {
            _shieldSpriteRender.enabled = !_shieldSpriteRender.enabled;
        }
    }

    private void Move()
    {
        if (Input.GetKey(_keyCodeUp))
        {
            _rigidbody2D.velocity = Vector2.up * _moveSpeed;
        }
        else if (Input.GetKey(_keyCodeDown))
        {
            _rigidbody2D.velocity = Vector2.down * _moveSpeed;
        }
        else
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Ball" && !_shieldSpriteRender.enabled)
        {
            Destroy(gameObject);
        }
    }
}