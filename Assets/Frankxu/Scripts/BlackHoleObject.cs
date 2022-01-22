using System.Collections;
using UnityEngine;

namespace Assets.Frankxu.Scripts
{
  
    public class BlackHoleObject : MonoBehaviour
    {
        public BlackHoleObject BlackHoleObjects;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (GameManager.Instance.BlackHoleState == false)
            {
                GameManager.Instance.BlackHoleState = true;
                GameManager.Instance.BlackHoleTime = 0.5f;
                collision.transform.position = BlackHoleObjects.transform.position;
                Vector2 velocity = collision.GetComponent<Rigidbody2D>().velocity;
                velocity.x = -velocity.x;
                velocity.y = -velocity.y;
                collision.GetComponent<Rigidbody2D>().velocity = velocity;
            }
        }
    }
}