using UnityEngine;

public class BoardController_Test : MonoBehaviour
{
    public void UpdateMinimumPosition(Vector3 target, Vector3 Distance)
    {
        if (transform.localPosition.y < target.y)
            transform.localPosition = target;
        else
            transform.localPosition += Distance;
    }

    public void UpdateMaximumPosition(Vector3 target, Vector3 Distance)
    {
        if (transform.localPosition.y > target.y)
            transform.localPosition = target;
        else
            transform.localPosition += Distance;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Ball" && transform.tag == "Board")
        {
            transform.parent.parent.SendMessage("StagingBricks", this);
        }
    }
}