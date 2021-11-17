using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
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

    void Awake()
    {

    }
}

