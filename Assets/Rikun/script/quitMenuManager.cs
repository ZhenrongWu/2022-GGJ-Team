using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quitMenuManager : MonoBehaviour
{
    public static bool quitClick;
    public static bool canPlaySeletedSound, canPlayClickedSound;
    
    [SerializeField]
    private GameObject audioMangener;

    
    // Start is called before the first frame update
    void Start()
    {
        audioMangener = GameObject.Find("AudioMananger");
        audioMangener.GetComponent<AudioMananger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (quitClick)
        {
            SceneManager.LoadScene("0");
        }
        sound();
    }

    private void sound()
    {
        if (canPlaySeletedSound)
        {
            audioMangener.GetComponent<AudioMananger>().playSelectedSound();
            canPlaySeletedSound = false;
        }

        if (canPlayClickedSound)
        {
            audioMangener.GetComponent<AudioMananger>().playclickedSound();
            canPlayClickedSound = false;
        }
    }
}
