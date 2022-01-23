using System.Collections;
using UnityEngine;

public class CannonObject : MonoBehaviour
{
    public float Speed = 3;

    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * Speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Board")
        {
            collision.gameObject.SetActive(false);
            transform.gameObject.SetActive(false);
        }
        else if(collision.transform.tag == "Black")
        {
            transform.gameObject.SetActive(false);
        }
    }
}