using System.Collections.Generic;
using UnityEngine;

public class BoardGroupController_Test : MonoBehaviour
{
    [SerializeField]            string keyCodeUp, keyCodeDown, keyCodeChagedColor, keySkill;
    [Space(10), SerializeField] float  moveSpeed = 5;
    [SerializeField]            int    PlayerId;

    [SerializeField] List<BoardController_Test> UpGround;
    [SerializeField] List<BoardController_Test> DownGround;
    private          Transform                  DestroyBricks = null;
    private          bool                       IsUpGround;
    List<Vector3>                               UpPos;
    List<Vector3>                               DonwPos;
    float                                       InvincibleTime = 5;
    bool                                        IsInvincible   = false;


    private void Start()
    {
        SetAllPos(UpGround,   ref UpPos);
        SetAllPos(DownGround, ref DonwPos);
        GameManager.Instance.RegisterToolkFeatures(PlayerId, ToolClass.Recover,    Recover);
        GameManager.Instance.RegisterToolkFeatures(PlayerId, ToolClass.Invincible, Invincible);
    }

    public void SetAllPos(List<BoardController_Test> ground, ref List<Vector3> pos)
    {
        pos = new List<Vector3>(ground.Count);
        for (int i = 0; i < ground.Count; i++)
        {
            pos.Add(ground[i].transform.localPosition);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyCodeChagedColor))
        {
        }

        // ¨Ï¥ÎÁä½L
        if (Input.GetKeyDown(keySkill))
            // GameManager.Instance.SetToolk(PlayerId, gameObject);

            if (IsInvincible)
            {
                InvincibleTime -= Time.deltaTime;
                if (InvincibleTime < 0)
                {
                    IsInvincible = false;
                    for (int i = 0; i < UpGround.Count; i++)
                    {
                        UpGround[i].tag = "Board";
                    }

                    for (int i = 0; i < DownGround.Count; i++)
                    {
                        DownGround[i].tag = "Board";
                    }
                }
            }
    }

    private void FixedUpdate()
    {
        Vector3 Distance = Vector2.zero;
        Vector3 Position = Vector2.zero;
        if (Input.GetKey(keyCodeUp))
        {
            Distance = Vector2.up * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(keyCodeDown))
        {
            Distance = Vector2.down * moveSpeed * Time.deltaTime;
        }

        Position   = transform.position + Distance;
        Position.y = Mathf.Clamp(Position.y, -0.05f, 4.5f);

        if (Position.y == -0.05f)
        {
            int Poscount = UpPos.Count;
            for (int i = UpGround.Count - 1; i > -1; i--)
            {
                Poscount--;
                if (UpGround[i].transform.localPosition != UpPos[Poscount])
                    UpGround[i].UpdateMinimumPosition(UpPos[Poscount], Distance);
            }

            Poscount = DonwPos.Count;
            for (int i = DownGround.Count - 1; i > -1; i--)
            {
                Poscount--;
                if (DownGround[i].transform.localPosition != DonwPos[Poscount])
                    DownGround[i].UpdateMinimumPosition(DonwPos[Poscount], Distance);
                Debug.Log(DonwPos[Poscount] + "  Poscount = > " + Poscount);
            }
        }
        else if (Position.y == 4.5f)
        {
            int Poscount = -1;
            for (int i = 0; i < UpGround.Count; i++)
            {
                Poscount++;
                if (UpGround[i].transform.localPosition != UpPos[Poscount])
                    UpGround[i].UpdateMaximumPosition(UpPos[Poscount], Distance);
            }

            Poscount = -1;
            for (int i = 0; i < DownGround.Count; i++)
            {
                Poscount++;
                if (DownGround[i].transform.localPosition != DonwPos[Poscount])
                    DownGround[i].UpdateMaximumPosition(DonwPos[Poscount], Distance);
            }
        }

        transform.position = Position;
    }

    private float CalculateTheMinimum()
    {
        int RemainingBricks = UpGround.Count;

        if (DownGround.Count > RemainingBricks)
            RemainingBricks = DownGround.Count;

        int MAX = 6;

        int D = MAX - RemainingBricks;
        if (DownGround.Count <= 0 && UpGround.Count <= 0)
            D = 5;
        return -0.05f - (D * 1.35f);
    }

    private float CalculateTheMaximum()
    {
        int RemainingBricks = UpGround.Count;

        if (DownGround.Count > RemainingBricks)
            RemainingBricks = DownGround.Count;

        int MAX = 6;

        int D = MAX - RemainingBricks;
        if (DownGround.Count <= 0 && UpGround.Count <= 0)
            D = 5;
        return 4.5f + (D * 1.35f);
    }

    public void StagingBricks(BoardController_Test _DestroyBricks)
    {
        _DestroyBricks.gameObject.SetActive(false);
        DestroyBricks = _DestroyBricks.transform;
        RemoveItem(ref UpGround,   _DestroyBricks, true);
        RemoveItem(ref DownGround, _DestroyBricks, false);
    }

    private void RemoveItem(ref List<BoardController_Test> UpGround, BoardController_Test _DestroyBricks,
        bool                                               _IsUpGround)
    {
        for (int i = 0; i < UpGround.Count; i++)
        {
            if (UpGround[i] == _DestroyBricks)
            {
                UpGround.Remove(_DestroyBricks.GetComponent<BoardController_Test>());
                IsUpGround = _IsUpGround;
            }
        }
    }

    /// <summary> «ì´_¿j¶ô </summary>
    private void Recover()
    {
        DestroyBricks.gameObject.SetActive(true);
        if (IsUpGround)
        {
            UpGround.Clear();
            Transform Up = transform.GetChild(0);
            for (int i = 0; i < 6; i++)
            {
                if (Up.GetChild(i).gameObject.activeInHierarchy)
                {
                    UpGround.Add(Up.GetChild(i).GetComponent<BoardController_Test>());
                    Up.GetChild(i).transform.localPosition = UpPos[i];
                }
            }
        }
        else
        {
            DownGround.Clear();
            Transform Down = transform.GetChild(1);
            for (int i = 0; i < 6; i++)
            {
                if (Down.GetChild(i).gameObject.activeInHierarchy)
                {
                    DownGround.Add(Down.GetChild(i).GetComponent<BoardController_Test>());
                    Down.GetChild(i).transform.localPosition = DonwPos[i];
                }
            }
        }
    }

    /// <summary> µL¼Äª¬ºA </summary>
    private void Invincible()
    {
        Debug.Log("µL¼Äª¬ºA    5s");

        for (int i = 0; i < UpGround.Count; i++)
        {
            UpGround[i].tag = "Untagged";
        }

        for (int i = 0; i < DownGround.Count; i++)
        {
            DownGround[i].tag = "Untagged";
        }

        InvincibleTime = 5;
        IsInvincible   = true;
    }
}