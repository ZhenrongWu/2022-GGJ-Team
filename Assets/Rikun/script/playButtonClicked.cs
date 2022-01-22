using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playButtonClicked : MonoBehaviour
{

    [SerializeField]
    private Button btn;
    [SerializeField]
    private GameObject button;
    public static bool isactive;
    void Start()
    {
        btn = btn.GetComponent<Button>();
        btn.onClick.AddListener((() => MainMenuMananger.introducePlayClick=true));
    }

    // Update is called once per frame
    void Update()
    {
        button.SetActive(isactive);
    }
}
