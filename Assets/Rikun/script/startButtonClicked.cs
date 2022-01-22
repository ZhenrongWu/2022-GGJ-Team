using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startButtonClicked : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Button btn;
    void Start()
    {
        btn = btn.GetComponent<Button>();
        btn.onClick.AddListener((() => MainMenuMananger.startButtonClick=true));
    }

    // Update is called once per frame
}
