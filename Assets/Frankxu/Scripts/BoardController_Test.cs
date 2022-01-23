using System;
using UnityEngine;

public class BoardController_Test : MonoBehaviour
{
    private ShieldController01 _shieldController01;

    private void Start()
    {
        _shieldController01 = GetComponent<ShieldController01>();
    }

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
        if ((other.gameObject.name   == "Ball" && transform.tag == "Board")
            || (other.gameObject.tag == "XXX"  && transform.tag == "Board"))
        {
            if (!_shieldController01._shieldSpriteRender.enabled)
            {
                transform.parent.parent.SendMessage("StagingBricks", this);
            }
        }
    }
}