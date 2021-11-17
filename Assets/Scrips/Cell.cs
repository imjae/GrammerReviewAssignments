using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cell : MonoBehaviour, Poolable
{
    private bool _isSelected;

    // TODO has-a °ü°è
    private Coordinate _coord;
    private string _cellText;
    public bool IsSelected
    {
        get { return _isSelected; }
        set { _isSelected = value; }
    }

    public Coordinate Coord
    {
        get { return _coord; }
        set
        {
            _coord.X = value.X;
            _coord.Y = value.Y;
        }
    }
    public string CellText
    {
        get { return _cellText; }
        set
        {
            _cellText = value;
            Debug.Log(transform.GetChild(0).name);
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _cellText;
        }
    }

    private Button cellButton;
    void Start()
    {
        cellButton = GetComponent<Button>();

        cellButton.onClick.AddListener(() =>
        {
            Debug.Log(BoardManager.Instance.CurrentOrder());
            CellText = BoardManager.Instance.CurrentOrder();

            BoardManager.Instance.history.Push(BoardManager.Instance.cellList);
            GameManager.Instance.Round = BoardManager.Instance.history.Count;
        });
    }

    public void OnDisable()
    {
        ObjectPooler.ReturnToPool(gameObject);
    }
}
