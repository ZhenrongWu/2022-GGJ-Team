using UnityEngine;

public class BoardController : MonoBehaviour
{
    [SerializeField]             private string _keyCodeUp, _keyCodeDown;
    [Space(10)] [SerializeField] private float  _moveSpeed;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
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
        if (other.gameObject.name == "Ball")
        {
            Destroy(gameObject);
        }
    }
}