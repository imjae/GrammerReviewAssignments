using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    public Button returnButton;
    public Button historyDebugButton;

    public delegate void Return2RefreshHistory();

    void Start()
    {
        Return2RefreshHistory ReturnHistoryNotRefresh = new Return2RefreshHistory(ReturnButtonClickEvent);

        Return2RefreshHistory ReturnHistoryDoRefresh = new Return2RefreshHistory(ReturnButtonClickEvent);
        ReturnHistoryDoRefresh += new Return2RefreshHistory(RefreshBoardEvent);

        returnButton.onClick.AddListener(() =>
        {
            // ReturnHistoryDoRefresh();
            // 콜백함수 테스트
            CallBackTest(CallBackTestFunction);
        });
        historyDebugButton.onClick.AddListener(() =>
        {
            GameManager.Instance.DebugHistory<string>(BoardManager.Instance.history);
        });
    }

    void ReturnButtonClickEvent()
    {
        if (BoardManager.Instance.history.Count > 1)
        {
            BoardManager.Instance.history.Pop();
            GameManager.Instance.Round = BoardManager.Instance.history.Count;
        }
    }

    void RefreshBoardEvent()
    {
        BoardManager.Instance.RefreshBoard();
    }


    void CallBackTest(Action action)
    {
        action();
    }


    Action CallBackTestFunction = () =>
    {
        if (BoardManager.Instance.history.Count > 1)
        {
            BoardManager.Instance.history.Pop();
            GameManager.Instance.Round = BoardManager.Instance.history.Count;
        }
        BoardManager.Instance.RefreshBoard();
    };
}
