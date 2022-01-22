using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoButtonClicked : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Button btn;
    void Start()
    {
        btn = btn.GetComponent<Button>();
        btn.onClick.AddListener((() => MainMenuMananger.introduceCNoButtonClick=true));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
