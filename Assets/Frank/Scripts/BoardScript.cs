using UnityEngine;

public class BoardScript : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private BoardGroupController _boardGroupController;
    private DetectScript[]       _detectScripts;
    private Rigidbody2D          _rigidbody2D;

    private void Start()
    {
        _rigidbody2D          = GetComponent<Rigidbody2D>();
        _boardGroupController = GetComponentInParent<BoardGroupController>();
        _detectScripts        = GetComponentsInChildren<DetectScript>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        foreach (var detectScript in _detectScripts)
        {
            if (_boardGroupController.IsUp && detectScript.IsDetect)
            {
                _rigidbody2D.velocity = Vector2.up * _moveSpeed;
            }
            else if (_boardGroupController.IsDown && detectScript.IsDetect)
            {
                _rigidbody2D.velocity = Vector2.down * _moveSpeed;
            }
            else
            {
                _rigidbody2D.velocity = Vector2.zero * _moveSpeed;
            }
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