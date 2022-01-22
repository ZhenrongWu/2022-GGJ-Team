using UnityEngine;

public class DetectScript : MonoBehaviour
{
    private bool _isDetect;
    public  bool IsDetect => _isDetect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Board") || other.CompareTag("Frame"))
        {
            _isDetect = true;
        }
        else
        {
            _isDetect = false;
        }
    }
}