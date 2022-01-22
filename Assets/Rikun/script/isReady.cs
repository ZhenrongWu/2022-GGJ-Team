using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class isReady : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text readyText;

    // Update is called once per frame
    private void Start()
    {
        readyText.GetComponent<Text>();
        readyText.enabled = true;
    }

    void Update()
    {
        if (Input.GetKey("f") && Input.GetKey(","))
        {
            readyText.enabled = false;
        }
    }
}
