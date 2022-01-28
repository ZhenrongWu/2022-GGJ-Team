using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardGroupController : MonoBehaviour
{
    [SerializeField] private string _keyCodeUp, _keyCodeDown, _keyCodeChange;
    [SerializeField] private float  _moveSpeed;
    [SerializeField] private float  _minPos, _maxPos;

    [SerializeField] List<BoardScript> _firstStoryBoardScripts;
    [SerializeField] List<BoardScript> _secondStoryBoardScripts;

    [Header("Change")] [SerializeField] private ShieldScript[] _shieldScripts;
    [SerializeField]                    private bool           _haveShield;
    [SerializeField]                    private Image          _imgChangedColorCD;
    [SerializeField]                    private float          _maxChangedColorCD;

    private List<Vector3> _firstStoryBoardPos;
    private List<Vector3> _secondStoryBoardPos;
    private float         _currChangedColorCD;
    private float         _reloadChangedColorCDTime;
    private bool          _havePressKeyCodeChange;
    public  bool          HavePressKeyCodeChange => _havePressKeyCodeChange;

    private void Start()
    {
        SetAllPos(_secondStoryBoardScripts, ref _secondStoryBoardPos);
        SetAllPos(_firstStoryBoardScripts,  ref _firstStoryBoardPos);

        _currChangedColorCD = _maxChangedColorCD;
    }

    private void SetAllPos(List<BoardScript> board, ref List<Vector3> pos)
    {
        pos = new List<Vector3>(board.Count);
        for (int i = 0; i < board.Count; i++)
        {
            pos.Add(board[i].transform.localPosition);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(_keyCodeChange) && _currChangedColorCD >= _maxChangedColorCD)
        {
            _havePressKeyCodeChange = true;

            Shield();
            ConsumeChangedColorCD();
        }
        else
        {
            _havePressKeyCodeChange = false;
        }

        RestoreChangedColorCD();
        DisplayChangedColorCDUI();
    }

    private void ConsumeChangedColorCD()
    {
        _currChangedColorCD--;
        _reloadChangedColorCDTime = Time.time;
    }

    private void RestoreChangedColorCD()
    {
        if (_reloadChangedColorCDTime + .5f < Time.time && _currChangedColorCD < _maxChangedColorCD)
        {
            _currChangedColorCD += Time.deltaTime;
            _currChangedColorCD =  Mathf.Clamp(_currChangedColorCD, 0, _maxChangedColorCD);
        }
    }

    private void DisplayChangedColorCDUI()
    {
        float currChangedColorRatio = _currChangedColorCD / _maxChangedColorCD;
        _imgChangedColorCD.fillAmount = Mathf.Lerp(_imgChangedColorCD.fillAmount, currChangedColorRatio, .1f);
    }

    private void Shield()
    {
        _haveShield = !_haveShield;

        foreach (var shieldScript in _shieldScripts)
        {
            shieldScript.SetShield();
        }

        Invincible();
    }

    private void Invincible()
    {
        if (_haveShield)
        {
            ChangeTag(_firstStoryBoardScripts,  "Untagged");
            ChangeTag(_secondStoryBoardScripts, "Untagged");
        }
        else
        {
            ChangeTag(_firstStoryBoardScripts,  "Board");
            ChangeTag(_secondStoryBoardScripts, "Board");
        }
    }

    private void ChangeTag(List<BoardScript> boardScripts, string tagName)
    {
        for (int i = 0; i < boardScripts.Count; i++)
        {
            boardScripts[i].tag = tagName;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 distance = Vector2.zero;
        Vector3 position = Vector2.zero;

        if (Input.GetKey(_keyCodeUp))
        {
            distance = Vector2.up * _moveSpeed * Time.fixedDeltaTime;
        }
        else if (Input.GetKey(_keyCodeDown))
        {
            distance = Vector2.down * _moveSpeed * Time.fixedDeltaTime;
        }

        position   = transform.position + distance;
        position.y = Mathf.Clamp(position.y, _minPos, _maxPos);

        if (position.y == _minPos)
        {
            CalculateMinimumPosition(distance);
        }
        else if (position.y == _maxPos)
        {
            CalculateMaximumPosition(distance);
        }

        transform.position = position;
    }

    private void CalculateMaximumPosition(Vector3 distance)
    {
        int index = -1;
        for (int i = 0; i < _firstStoryBoardScripts.Count; i++)
        {
            index++;
            if (_firstStoryBoardScripts[i].transform.localPosition != _firstStoryBoardPos[index])
                _firstStoryBoardScripts[i].UpdateMaximumPosition(_firstStoryBoardPos[index], distance);
        }

        index = -1;
        for (int i = 0; i < _secondStoryBoardScripts.Count; i++)
        {
            index++;
            if (_secondStoryBoardScripts[i].transform.localPosition != _secondStoryBoardPos[index])
                _secondStoryBoardScripts[i].UpdateMaximumPosition(_secondStoryBoardPos[index], distance);
        }
    }

    private void CalculateMinimumPosition(Vector3 distance)
    {
        int index = _firstStoryBoardPos.Count;
        for (int i = _firstStoryBoardScripts.Count - 1; i > -1; i--)
        {
            index--;
            if (_firstStoryBoardScripts[i].transform.localPosition != _firstStoryBoardPos[index])
                _firstStoryBoardScripts[i].UpdateMinimumPosition(_firstStoryBoardPos[index], distance);
        }

        index = _secondStoryBoardPos.Count;
        for (int i = _secondStoryBoardScripts.Count - 1; i > -1; i--)
        {
            index--;
            if (_secondStoryBoardScripts[i].transform.localPosition != _secondStoryBoardPos[index])
                _secondStoryBoardScripts[i].UpdateMinimumPosition(_secondStoryBoardPos[index], distance);
        }
    }

    /// <summary>
    /// SendMessage
    /// </summary>
    /// <param name="board"></param>
    public void TurnOffBoard(BoardScript board)
    {
        board.gameObject.SetActive(false);

        RemoveBoard(ref _firstStoryBoardScripts,  board);
        RemoveBoard(ref _secondStoryBoardScripts, board);
    }

    private void RemoveBoard(ref List<BoardScript> boardScripts, BoardScript board)
    {
        for (int i = 0; i < boardScripts.Count; i++)
        {
            if (boardScripts[i] == board)
            {
                boardScripts.Remove(board);
            }
        }
    }
}