using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMananger : MonoBehaviour
{

    [SerializeField]
    private AudioSource background, selected, clicked;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSelectedSound()
    {
        selected.Play();
    }

    public void playclickedSound()
    {
        clicked.Play();
    }
    
}