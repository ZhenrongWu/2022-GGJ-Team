using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3;

    [Header("UI")] [SerializeField] private Image[] _imgHearts;

    private float _currHealth;

    private void Start()
    {
        _currHealth = _maxHealth;
    }

    public void OnDecreaseHealth()
    {
        SetHealthValue();
        SetHealthUI();
    }

    private void SetHealthUI()
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

    private void SetHealthValue()
    {
        if (_currHealth == 0)
        {
            // GameOver
            return;
        }

        if (_currHealth <= 0)
        {
            _currHealth = 0;
        }

        _currHealth--;
    }
}