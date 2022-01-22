using System;
using System.Collections.Generic;
using UnityEngine;

public enum ToolkClass
{
    None,
    Recover,    // 恢復
    BlackHole,  // 黑洞
    Cannon,     // 加農砲
    Invincible, // 無敵

    Reserve,    // 保留
}

public class ToolkController : MonoBehaviour
{
    string[] Toolks;
    ToolkClass Toolk = ToolkClass.None;
    Dictionary<ToolkClass, Action> ToolkBehavior;

    private void Start()
    {
        ToolkBehavior = new Dictionary<ToolkClass, Action>((int)ToolkClass.Reserve - 1);
        Toolks = new string[(int)ToolkClass.Reserve -1];

        for (int i = 0; i < Toolks.Length; i++)
            Toolks[i] = ((ToolkClass)i).ToString();
    }

    public void SetToolkFeatures(ToolkClass state, Action action)
    {
        ToolkBehavior.Add(state, action);
    }

    /// <summary> 設定道具 </summary>
    public ToolkClass SetToolk()
    {
        // 隨機獲取道具
        int random = UnityEngine.Random.Range(0, 101);
        float percentage = 100 / Toolks.Length;
        for (int i = Toolks.Length; i > 0; i--)
        {
            if (random > (percentage * i))
            {
                Toolk = (ToolkClass)i;
                Debug.Log("目前擁有道具 => " + Toolk.ToString());
                return Toolk;
            }
        }

        Debug.LogError("未知錯誤");
        return ToolkClass.None;
    }
    /// <summary> 使用道具 </summary>
    public void UseToolk()
    {
        for(int i = 0; i < ToolkBehavior.Count; i++)
        {
            if(ToolkBehavior.ContainsKey(Toolk))
            {
                Debug.Log("執行  => " + Toolk.ToString());
                ToolkBehavior[Toolk].Invoke();
                Toolk = ToolkClass.None;
            }
        }
    }


}
