using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _posX;
    [SerializeField] private float _posY;

    private Rigidbody2D _rigidbody2D;

    private bool _isServe;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _rigidbody2D.isKinematic = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isServe)
        {
            _rigidbody2D.isKinematic = false;

            Vector2 pos = new Vector2(Random.Range(-_posX, -1), Random.Range(-_posY, _posY));
            _rigidbody2D.AddForce(pos * _force, ForceMode2D.Force);

            _isServe = true;
        }

        if (_rigidbody2D.velocity != Vector2.zero)
        {
            float velocityX = Mathf.Clamp(_rigidbody2D.velocity.x, -30, 30);
            float velocityY = Mathf.Clamp(_rigidbody2D.velocity.y, -30, 30);

            _rigidbody2D.velocity = new Vector2(velocityX, velocityY);
        }
    }
}