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

    private int cur=0;
    
    
    
    void Start()
    {
        startMenu.enabled = true;
        introduceCMenu.enabled = false;
        introduceMenu.enabled = false;
        tutorailiImage.GetComponent<Image>();
        tutorailiImage.sprite = tutoriaList[0];
    }
    
    private void Update()
    {
        Debug.Log(cur);
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
            SceneManager.LoadScene(0);
        }
        
        
    }
}


