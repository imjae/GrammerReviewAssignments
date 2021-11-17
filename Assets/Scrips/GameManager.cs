using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public TextMeshProUGUI roundText;

    public int _round;
    public int _boarSize;
    private string _order;

    public int BoardSize
    {
        get { return _boarSize; }
        // 여기서 게임판을 다시그리는 로직이 들어가야함
        set { _boarSize = value; }
    }

    public string Order
    {
        get { return _order; }
        set { _order = value; }
    }

    public int Round
    {
        get { return _round; }
        set
        {
            _round = value;
            roundText.SetText($"ROUND : {BoardManager.Instance.history.Count}");
        }
    }


    void Awake()
    {

    }
}

