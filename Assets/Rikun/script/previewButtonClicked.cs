using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class previewButtonClicked : MonoBehaviour,IPointerEnterHandler
{
    [SerializeField]
    private Button btn;
    [SerializeField]
    private GameObject button;
    public static bool isactive;
    void Start()
    {
        btn = btn.GetComponent<Button>();
        btn.onClick.AddListener((() => MainMenuMananger.introducepreviewClick=true));
        btn.onClick.AddListener((() => MainMenuMananger.canPlayClickedSound=true));
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        MainMenuMananger.canPlaySeletedSound = true;
    }
    void Update()
    {
        button.SetActive(isactive);
    }
}
