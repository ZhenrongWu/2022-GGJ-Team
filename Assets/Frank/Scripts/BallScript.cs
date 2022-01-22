using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _posX;
    [SerializeField] private float _posY;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _rigidbody2D.isKinematic = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.isKinematic = false;

            Vector2 pos = new Vector2(Random.Range(1, _posX), Random.Range(-_posY, _posY));
            _rigidbody2D.AddForce(pos * _force, ForceMode2D.Force);
        }
    }
}