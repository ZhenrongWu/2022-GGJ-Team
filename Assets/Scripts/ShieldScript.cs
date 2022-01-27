using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    private SpriteRenderer _shieldSpriteRenderer;

    private void Start()
    {
        _shieldSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetShield()
    {
        _shieldSpriteRenderer.enabled = !_shieldSpriteRenderer.enabled;
    }
}