using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : Singleton<BoardManager>
{
    // 게임판 생성 관리
    public Transform board;
    public GameObject cellPrefab;

    public Stack<List<Cell>> history;
    public List<Cell> cellList;
    public Cell[][] cellArr;

    void Start()
    {
        history = new Stack<List<Cell>>();
        cellList = new List<Cell>();


    }

    void InitCell()
    {
        Instantiate(cellPrefab);
    }
}
