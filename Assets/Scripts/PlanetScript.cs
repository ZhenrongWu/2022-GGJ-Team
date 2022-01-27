using System;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    [SerializeField] private HealthController _healthController;

    private event Action _onDecreaseHealth;

    private void Start()
    {
        _onDecreaseHealth += _healthController.OnDecreaseHealth;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Ball")
        {
            _onDecreaseHealth?.Invoke();
        }
    }
}