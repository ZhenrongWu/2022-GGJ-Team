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
}