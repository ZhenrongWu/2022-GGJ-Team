using System;
using UnityEngine;

public class StabScript : MonoBehaviour
{
    [SerializeField] private HealthController _healthController;

    public event Action _onDecreaseHealth;

    private void Start()
    {
        _onDecreaseHealth += _healthController.OnDecreaseHealth;
    } 

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Ball")
        {
            _onDecreaseHealth?.Invoke();
        }
    }
}