using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showWinMessage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Canvas winMessageBox;
    
    
    void Start()
    {
        winMessageBox.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        winMessageBox.GetComponent<Canvas>().enabled = show_player_health.AnyOneDie;
    }
}
