using System;
using System.Collections.Generic;
using UnityEngine;

public enum ToolClass
{
    None,
    Recover,    // 恢復
   // BlackHole,  // 黑洞
   // Cannon,     // 加農砲
    Invincible, // 無敵

    Reserve,    // 保留
}

public class ToolkController : MonoBehaviour
{
    string[] Toolks;
    ToolClass Toolk = ToolClass.None;
    Dictionary<ToolClass, Action> ToolkBehavior;

    private void Awake()
    {
        ToolkBehavior = new Dictionary<ToolClass, Action>((int)ToolClass.Reserve - 1);
        Toolks = new string[(int)ToolClass.Reserve -1];

        for (int i = 1; i < Toolks.Length; i++)
            Toolks[i - 1] = ((ToolClass)i).ToString();
    }

    public void SetToolkFeatures(ToolClass state, Action action)
    {
        Debug.Log(state);
        ToolkBehavior.Add(state, action);
    }

    /// <summary> 設定道具 </summary>
    public ToolClass SetToolk()
    {
        // 隨機獲取道具
        int random = UnityEngine.Random.Range(0, 99);
        float percentage = 100 / Toolks.Length;
        for (int i = Toolks.Length; i > 0; i--)
        {
            if (random > (percentage * i))
            {
                Toolk = (ToolClass)i;
                Debug.Log("目前擁有道具 => " + Toolk.ToString());
                return Toolk;
            }
        }

        Debug.LogError("未知錯誤");
        return ToolClass.None;
    }
    /// <summary> 使用道具 </summary>
    public void UseToolk()
    {
        Debug.LogError(ToolkBehavior.Count);
        for(int i = 0; i < ToolkBehavior.Count; i++)
        {
            if(i == (int)Toolk)
            {
                ToolkBehavior[Toolk].Invoke();
                Toolk = ToolClass.None;
            }
        }
    }


}
