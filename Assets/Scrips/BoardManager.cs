using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : Singleton<BoardManager>
{
    // 게임판 생성 관리
    public Transform board;
    public GameObject cellPrefab;

    public Stack<List<GameObject>> history;
    public List<GameObject> cellList;
    public GameObject[][] cellArr;

    private int boardSize;

    void Start()
    {
        history = new Stack<List<GameObject>>();
        cellList = new List<GameObject>();

        InitCell();
    }

    void InitCell()
    {
        boardSize = GameManager.Instance.BoardSize;
        for(int i=0; i<boardSize; i++)
        {
            // 초기 상태
            GameObject button = ObjectPooler.TakeFromPool("Cell");
            cellList.Add(button);
            history.Push(cellList);
        }
    }

    public string CurrentOrder()
    {
        string result = "O";

        if(history.Count % 2 ==0)
            result = "X";

        return result;
    }

    public int CurrentRound()
    {
        int result = 0;

        result = history.Count;

        return result;
    }
}
