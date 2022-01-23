using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class quitButtonClicked : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private Button btn;
    [SerializeField] private GameObject button;
    public static bool isactive;

    void Start()
    {
        btn = btn.GetComponent<Button>();
        btn.onClick.AddListener((() => quitMenuManager.quitClick = true));
        btn.onClick.AddListener((() => quitMenuManager.canPlayClickedSound = true));

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        quitMenuManager.canPlaySeletedSound = true;
    }

    void Update()
    {

    }
}
