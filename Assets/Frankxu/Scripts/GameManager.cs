using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _Instantiate;
    public static GameManager Instantiate
    {
        set
        {
            if (_Instantiate == null)
                _Instantiate = FindObjectOfType<GameManager>();
            else
                Destroy(_Instantiate);
        }
        get
        {
            return _Instantiate;
        }
    }

    public GameObject[] Boards;
    public ToolkController[] Toolks;

    /// <summary> 設定道具的實際功能 </summary>
    /// <param name="ToolkState">道具狀態</param>
    /// <param name="action">要表現的行為</param>
    public void RegisterToolkFeatures(int PlayerID , ToolkClass ToolkState, Action action)
    {
        Toolks[PlayerID].SetToolkFeatures(ToolkState, action);
    }

    /// <summary>取得道具</summary>
    /// <param name="PlayerID">使用道具的玩家</param>
    /// <param name="player"></param>
    public void SetToolk(int PlayerID, GameObject player)
    {
        ToolkClass StateToolk = Toolks[PlayerID].SetToolk();

        // 檢查是否要啟用瞄準線
        switch (StateToolk)
        {
                // 黑洞
            case ToolkClass.BlackHole:
               // player.SendMessage("XXXX", true);  // 啟動瞄準線
                break;
                // 加農砲
            case ToolkClass.Cannon:
                // player.SendMessage("XXXX", true);  // 啟動瞄準線
                break;
            default:
                // player.SendMessage("XXXX", false);  // 關閉黑洞瞄準線
                // player.SendMessage("XXXX", false);  // 關閉加農砲瞄準線
                break;
        }
    }

    /// <summary>使用道具</summary>
    /// <param name="PlayerID">使用道具的玩家</param>
    public void UseToolk(int PlayerID, GameObject player)
    {
        // player.SendMessage("XXXX", false);  // 關閉黑洞瞄準線
        // player.SendMessage("XXXX", false);  // 關閉加農砲瞄準線
        Toolks[PlayerID].UseToolk();
    }
}
