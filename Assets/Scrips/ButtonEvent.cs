using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    public Button returnButton;
    public Button historyDebugButton;
    // Start is called before the first frame update
    void Start()
    {
        returnButton.onClick.AddListener(() =>
        {
            ReturnButtonEvent();
        });
        historyDebugButton.onClick.AddListener(() =>
        {
            GameManager.Instance.DebugHistory<string>(BoardManager.Instance.history);
        });
    }

    void ReturnButtonEvent()
    {
        BoardManager.Instance.history.Pop();


        GameManager.Instance.Round = BoardManager.Instance.history.Count;
        BoardManager.Instance.RefreshBoard();
    }
}
