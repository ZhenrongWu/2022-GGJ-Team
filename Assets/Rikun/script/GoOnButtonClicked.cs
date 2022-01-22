using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GoOnButtonClicked : MonoBehaviour,IPointerEnterHandler
{
    [SerializeField]
    private Button btn;
    void Start()
    {
        btn = btn.GetComponent<Button>();
        btn.onClick.AddListener((() => MainMenuMananger.introduceGoOnClick=true));
        btn.onClick.AddListener((() => MainMenuMananger.canPlayClickedSound=true));
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        MainMenuMananger.canPlaySeletedSound = true;
    }
}
