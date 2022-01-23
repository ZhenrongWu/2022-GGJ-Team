using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleController : MonoBehaviour
{
    [SerializeField] GameObject SightObj;
    [SerializeField] GameObject BlackHolePrefab;
    Vector3 Pos;
    [SerializeField] float Scope;
    [SerializeField] int PlayerID;
    [SerializeField] float SyStemTime = 5;
    float time = 5;

    private void Start()
    {
        Pos = SightObj.transform.position;
        //GameManager.Instance.RegisterToolkFeatures(PlayerID, ToolClass.BlackHole, OpenBlackHoleEvent);
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if(time < 0)
        {
            time = SyStemTime;
            Vector3 _Pos = Pos;
            float X = Random.Range(0, Scope);
            _Pos.y -= Scope;
            _Pos.y += X;

            BlackHolePrefab.transform.position = _Pos;
        }
    }

    private void SetHoleEvent()
    {
        time = SyStemTime;
        BlackHolePrefab.transform.position = SightObj.transform.position;
    }

    /// <summary> 黑洞瞄準線 </summary>
    private void BlackHole_lineOfSight(bool action)
    {
        // 黑洞瞄準線開啟或關閉
        SightObj.SetActive(action);
    }

    /// <summary> 啟動黑洞 </summary>
    private void OpenBlackHoleEvent()
    {
        BlackHolePrefab.transform.position = SightObj.transform.position;
        BlackHolePrefab.gameObject.SetActive(true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(SightObj.transform.position + new Vector3(0, Scope, 0),
            SightObj.transform.position - new Vector3(0, Scope, 0));
    }
}
