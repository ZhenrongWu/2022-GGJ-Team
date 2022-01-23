using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuMananger:MonoBehaviour
{
    [Header("Allmenu")]
    [SerializeField]
    private Canvas startMenu,introduceCMenu,introduceMenu;
    
    [SerializeField]
    private List<Sprite> tutoriaList= new List<Sprite>();
    
    [SerializeField]
    private Image tutorailiImage;
    public static bool startButtonClick,introduceCYesButtonClick,introduceCNoButtonClick,introducePlayClick
        ,introduceGoOnClick,introducepreviewClick;
       
    [SerializeField]
    private List<Sprite> muteIcon = new List<Sprite>();
    [SerializeField]
    private Image muteImage;
    
    public static bool canPlaySeletedSound,canPlayClickedSound,ismute;
    private bool cur_ismute;
    private int cur=0;
    private GameObject audioMangener;
    
    
    void Start()
    {
        startMenu.enabled = true;
        introduceCMenu.enabled = false;
        introduceMenu.enabled = false;
        tutorailiImage.GetComponent<Image>();
        tutorailiImage.sprite = tutoriaList[0];
        audioMangener = GameObject.Find("AudioMananger");
        audioMangener.GetComponent<AudioMananger>();
    }
    
    private void Update()
    {
        Debug.Log(cur_ismute);
        buttonAll();



    }

    private void playClicked()
    {
        audioMangener.GetComponent<AudioMananger>().playclickedSound();
    }

    private void playSelected()
    {
      audioMangener.GetComponent<AudioMananger>().playSelectedSound();  
    }

    private void pressMute()
    {
        audioMangener.GetComponent<AudioMananger>().mute(cur_ismute);
        muteImage.GetComponent<Image>().sprite = (cur_ismute ? muteIcon[1] : muteIcon[0]);
    }
    
    
    private void buttonAll()
    {
        if (startButtonClick)
        {
            startMenu.enabled = false;
            introduceCMenu.enabled = true;
        }

        if (introduceCYesButtonClick)
        {
            introduceCMenu.enabled = false;
            introduceMenu.enabled = true;

        }

        if (introduceGoOnClick)
        {
            cur+=1;
            tutorailiImage.sprite = tutoriaList[cur];
            if (cur == tutoriaList.Count-1)
            {
                playButtonClicked.isactive = true;
            }
            else
            {
                playButtonClicked.isactive = false;
            }
            if (cur != 0)
            {
                previewButtonClicked.isactive = true;
            }
            else
            {
                previewButtonClicked.isactive = false;
            }

            introduceGoOnClick = false;
        }
        if (introducepreviewClick)
        {
            cur-=1;
            tutorailiImage.sprite = tutoriaList[cur];
            if (cur != tutoriaList.Count-1)
            {
                playButtonClicked.isactive = false;
            }
            else
            {
                playButtonClicked.isactive = true;
            }
            if (cur == 0)
            {
                previewButtonClicked.isactive = false;
            }
            else
            {
                previewButtonClicked.isactive = true;
            }

            introducepreviewClick = false;
        }

        if (introducePlayClick||introduceCNoButtonClick)
        {
            SceneManager.LoadScene("FrankScene");
            Debug.Log(1);
        }
        if (canPlayClickedSound)
        {
            playClicked();
            canPlayClickedSound = false;
        }

        if (canPlaySeletedSound)
        {
            playSelected();
            canPlaySeletedSound = false;
        }

        if (ismute)
        {
            cur_ismute = !cur_ismute;
            pressMute();
            ismute = false;
        }
    }   
}


