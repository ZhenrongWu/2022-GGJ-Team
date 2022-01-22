using System;
using System.Collections.Generic;
using UnityEngine;

public enum ToolkClass
{
    None,
    Recover,    // ��_
    BlackHole,  // �¬}
    Cannon,     // �[�A��
    Invincible, // �L��

    Reserve,    // �O�d
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

    /// <summary> �]�w�D�� </summary>
    public ToolkClass SetToolk()
    {
        // �H������D��
        int random = UnityEngine.Random.Range(0, 101);
        float percentage = 100 / Toolks.Length;
        for (int i = Toolks.Length; i > 0; i--)
        {
            if (random > (percentage * i))
            {
                Toolk = (ToolkClass)i;
                Debug.Log("�ثe�֦��D�� => " + Toolk.ToString());
                return Toolk;
            }
        }

        Debug.LogError("�������~");
        return ToolkClass.None;
    }
    /// <summary> �ϥιD�� </summary>
    public void UseToolk()
    {
        for(int i = 0; i < ToolkBehavior.Count; i++)
        {
            if(ToolkBehavior.ContainsKey(Toolk))
            {
                Debug.Log("����  => " + Toolk.ToString());
                ToolkBehavior[Toolk].Invoke();
                Toolk = ToolkClass.None;
            }
        }
    }


}
