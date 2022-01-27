using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float _force;

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
            transform.parent = null;

            _rigidbody2D.isKinematic = false;
            _rigidbody2D.AddForce(Vector2.right * _force, ForceMode2D.Force);

            _isServe = true;
        }
    }
}