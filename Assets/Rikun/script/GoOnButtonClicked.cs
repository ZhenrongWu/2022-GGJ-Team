using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoOnButtonClicked : MonoBehaviour
{
    [SerializeField]
    private Button btn;
    void Start()
    {
        btn = btn.GetComponent<Button>();
        btn.onClick.AddListener((() => MainMenuMananger.introduceGoOnClick=true));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
