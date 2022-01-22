using UnityEngine;

public class BoardScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Ball")
        {
            gameObject.SetActive(false);
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}