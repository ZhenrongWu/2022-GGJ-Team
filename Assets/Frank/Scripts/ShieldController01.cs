using UnityEngine;

public class ShieldController01 : MonoBehaviour
{
    [SerializeField]             private string               _keyCodeChagedColor;
    [Space(10)] [SerializeField] private SpriteRenderer       _shieldSpriteRender;
    [Space(10)] [SerializeField] private BackgroundController _backgroundController;

    private void Update()
    {
        SetShield();
    }

    private void SetShield()
    {
        if (Input.GetKeyDown(_keyCodeChagedColor) && _backgroundController.JudgeChangedColorCD())
        {
            _shieldSpriteRender.enabled = !_shieldSpriteRender.enabled;
        }
    } 
}