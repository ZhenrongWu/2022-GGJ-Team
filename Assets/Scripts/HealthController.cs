using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3;

    [Header("UI")] [SerializeField] private Image[] _imgHearts;

    private float _currHealth;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();

        _currHealth = _maxHealth;
    }

    private void Update()
    {
        if (_currHealth == 0)
        {
            _gameManager.GameOver();
        }
    }

    public void OnDecreaseHealth()
    {
        SetValue();
        DisplayUI();
    }

    private void DisplayUI()
    {
        for (int i = 0; i < _imgHearts.Length; i++)
        {
            if (i < _currHealth)
            {
                _imgHearts[i].enabled = true;
            }
            else
            {
                _imgHearts[i].enabled = false;
            }
        }
    }

    private void SetValue()
    {
        if (_currHealth <= 0)
        {
            _currHealth = 0;
        }

        _currHealth--;
    }
}