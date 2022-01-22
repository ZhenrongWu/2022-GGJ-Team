using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class YesButtonClicked : MonoBehaviour,IPointerEnterHandler
{
    // Start is called before the first frame update
    [SerializeField]
    private Button btn;
    void Start()
    {
        btn = btn.GetComponent<Button>();
        btn.onClick.AddListener((() => MainMenuMananger.introduceCYesButtonClick=true));
        btn.onClick.AddListener((() => MainMenuMananger.canPlayClickedSound=true));
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        MainMenuMananger.canPlaySeletedSound = true;
    }
}
