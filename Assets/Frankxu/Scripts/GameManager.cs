using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _Instance;
    public static GameManager Instance
    {
        get
        {
            return _Instance;
        }
    }

    private void Awake()
    {
        if (_Instance == null)
            _Instance = this;
    }

    public GameObject[]      Boards;
    public ToolkController[] Toolks;
    public GameObject[]      BlackHoles;
    public GameObject[]      Cannons;
    public Image[] SkillImage;
    public Sprite[] SkillSp;
    public bool              BlackHoleState = true;
    public float             BlackHoleTime;

    private void Update()
    {
        if (BlackHoleState)
        {
            BlackHoleTime -= Time.deltaTime;
            if(BlackHoleTime < 0)
            {
                BlackHoleTime = 0.5f;
                BlackHoleState = false;
            }
        }
    }

    /// <summary> 設定道具的實際功能 </summary>
    /// <param name="ToolkState">道具狀態</param>
    /// <param name="action">要表現的行為</param>
    public void RegisterToolkFeatures(int PlayerID , ToolClass ToolkState, Action action)
    {
        Toolks[PlayerID].SetToolkFeatures(ToolkState, action); SetImage(PlayerID, ToolkState);
    }

    /// <summary>取得道具</summary>
    /// <param name="PlayerID">使用道具的玩家</param>
    /// <param name="player"></param>
    public void SetToolk(int PlayerID, GameObject player)
    {
        ToolClass StateToolk = Toolks[PlayerID].SetToolk();
        SetImage(PlayerID, StateToolk);
        // 檢查是否要啟用瞄準線
        //switch (StateToolk)
        //{
        //        // 黑洞
        //    //case ToolClass.BlackHole:
        //    //    BlackHoles[PlayerID].SendMessage("BlackHole_lineOfSight", true);  // 啟動瞄準線
        //    //    break;
        //        // 加農砲
        //    //case ToolClass.Cannon:
        //    //    Cannons[PlayerID].SendMessage("Cannon_lineOfSight", true);  // 啟動瞄準線
        //    //    break;
        //    default:
        //        BlackHoles[PlayerID].SendMessage("BlackHole_lineOfSight", false);  // 關閉黑洞瞄準線
        //        //Cannons[PlayerID].SendMessage("Cannon_lineOfSight", false);        // 關閉加農砲瞄準線
        //        break;
        //}
    }

    /// <summary>使用道具</summary>
    /// <param name="PlayerID">使用道具的玩家</param>
    public void UseToolk(int PlayerID, GameObject player)
    {
        BlackHoles[PlayerID].SendMessage("BlackHole_lineOfSight", false);  // 關閉黑洞瞄準線
        //Cannons[PlayerID].SendMessage("Cannon_lineOfSight", false);        // 關閉加農砲瞄準線
        Toolks[PlayerID].UseToolk();
        GameManager.Instance.SetImage(PlayerID, ToolClass.None);
    }

    private void SetImage(int PlayerID, ToolClass Class)
    {
        switch(Class)
        {
            //case ToolClass.BlackHole:
            //    SkillImage[PlayerID].sprite = SkillSp[1];
            //    break;
            case ToolClass.Invincible:
                SkillImage[PlayerID].sprite = SkillSp[2];
                break;
            case ToolClass.Recover:
                SkillImage[PlayerID].sprite = SkillSp[0];
                break;
        }
    }
}
