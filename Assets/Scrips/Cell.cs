using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        set { 
            _cellText = value;
            transform.GetChild(0).GetComponent<Text>().text = _cellText;
        }
    }

    private Button cellButton;
    void Start()
    {
        cellButton = GetComponent<Button>();

        cellButton.onClick.AddListener(() =>
        {
            CellText = BoardManager.Instance.CurrentOrder();
        });
    }

    public void OnDisable()
    {
        ObjectPooler.ReturnToPool(gameObject);
    }
}
