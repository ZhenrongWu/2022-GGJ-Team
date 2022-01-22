using System.Collections.Generic;
using UnityEngine;

public class BoardGroupController_Test : MonoBehaviour
{
    [SerializeField] KeyCode keyCodeUp, keyCodeDown, keyCodeChagedColor, keySkill;
    [Space(10), SerializeField] float moveSpeed = 5;

    [SerializeField] List<BoardController_Test> UpGround;
    [SerializeField] List<BoardController_Test> DownGround;
    private Transform DestroyBricks = null;
    List<Vector3> UpPos;
    List<Vector3> DonwPos;

    private void Start()
    {
        SetAllPos(UpGround,ref UpPos);
        SetAllPos(DownGround,ref DonwPos);
    }

    public void SetAllPos(List<BoardController_Test> ground, ref List<Vector3> pos)
    {
        pos = new List<Vector3>(ground.Count);
        for (int i = 0; i < ground.Count; i++)
        {
            pos.Add(ground[i].transform.localPosition);
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
        Position = transform.position + Distance;
        Position.y = Mathf.Clamp(Position.y, CalculateTheMinimum(), CalculateTheMaximum());

        if(Position.y == CalculateTheMinimum())
        {
            int Poscount = UpPos.Count;
            for (int i = UpGround.Count -1; i > -1; i--)
            {
                Poscount--;
                if(UpGround[i].transform.localPosition != UpPos[Poscount])
                    UpGround[i].UpdateMinimumPosition(UpPos[Poscount], Distance);
            }
            Poscount = DonwPos.Count;
            for (int i = DownGround.Count - 1; i > -1; i--)
            {
                Poscount--;
                if (DownGround[i].transform.localPosition != DonwPos[Poscount])
                    DownGround[i].UpdateMinimumPosition(DonwPos[Poscount], Distance);
            }
        }
        else if(Position.y == CalculateTheMaximum())
        {
            int Poscount = -1;
            for (int i = 0; i < UpGround.Count; i++)
            {
                Poscount++;
                if (UpGround[i].transform.localPosition != UpPos[Poscount])
                    UpGround[i].UpdateMaximumPosition(UpPos[Poscount], Distance);
            }
            Poscount = -1;
            for (int i = 0; i < UpGround.Count; i++)
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
        return -0.7f - (D * 1.35f);
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
        return 2.05f + (D * 1.35f);
    }
}