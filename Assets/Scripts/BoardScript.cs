using UnityEngine;

public class BoardScript : MonoBehaviour
{
    public void UpdateMinimumPosition(Vector3 target, Vector3 distance)
    {
        if (transform.localPosition.y < target.y)
        {
            transform.localPosition = target;
        }
        else
        {
            transform.localPosition += distance;
        }
    }

    public void UpdateMaximumPosition(Vector3 target, Vector3 distance)
    {
        if (transform.localPosition.y > target.y)
        {
            transform.localPosition = target;
        }
        else
        {
            transform.localPosition += distance;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Ball" && transform.CompareTag("Board"))
        {
            transform.parent.parent.SendMessage("TurnOffBoard", this);
        }
    }
}