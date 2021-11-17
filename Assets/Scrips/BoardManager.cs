using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoardManager : Singleton<BoardManager>
{
    // 게임판 생성 관리
    public Transform board;
    public GameObject cellPrefab;

    public Stack<List<string>> history;
    public List<string> cellList;
    public GameObject[][] cellArr;

    private int boardSize;

    void Start()
    {
        history = new Stack<List<string>>();
        cellList = new List<string>();

        InitCell();
    }

    void InitCell()
    {
        boardSize = GameManager.Instance.BoardSize;
        for (int i = 0; i < boardSize; i++)
        {
            ObjectPooler.TakeFromPool("Cell");
        }

        RefreshTextList();

        history.Push(GameManager.Instance.ListDeepCopy<string>(cellList));
    }

    public void RefreshTextList()
    {
        cellList = new List<string>(); 
        for(int i=0; i<board.childCount; i++)
        {
            cellList.Add(board.GetChild(i).gameObject.GetButtonText());
        }
    }

    public string CurrentOrder()
    {
        string result = "O";

        if (history.Count % 2 == 0)
            result = "X";

        return result;
    }

    public int CurrentRound()
    {
        int result = 0;

        result = history.Count;

        return result;
    }

    // History 마지막 CellList 값으로 게임판 초기화
    public void RefreshBoard()
    {
        List<string> recentBoard = history.Pop();
        
        // recentBoard.ForEach(button => Debug.Log(button.transform.GetChild(0).TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI a)));
        
        for(int i=0; i<board.childCount; i++)
        {
            GameObject tmpButton = board.GetChild(i).gameObject;
            tmpButton.SetButtonText(recentBoard[i]);
        }

        history.Push(recentBoard);
    }
}
