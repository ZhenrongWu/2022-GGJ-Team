using System.Collections;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] GameObject SightObj;
    [SerializeField] GameObject CannonPrefab;
    [SerializeField] int PlayerID;

    private void Start()
    {
       // GameManager.Instance.RegisterToolkFeatures(PlayerID, ToolClass.BlackHole, OpenCannonEvent);
    }

    /// <summary> 加農砲瞄準線 </summary>
    private void Cannon_lineOfSight(bool action)
    {
        // 加農砲準線開啟或關閉
        SightObj.SetActive(action);
    }

    /// <summary> 啟動加農砲 </summary>
    private void OpenCannonEvent()
    {
        CannonPrefab.transform.position = SightObj.transform.position;
        CannonPrefab.gameObject.SetActive(true);
    }
}
