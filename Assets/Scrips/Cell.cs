using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private bool _isSelected;

    // TODO has-a °ü°è
    private Coordinate _coord;

    public bool IsSelected
    {
        get { return _isSelected; }
        set { _isSelected = value; }
    }

    public Coordinate Coord
    {
        get { return _coord; }
        set { 
            _coord.X = value.X;
            _coord.Y = value.Y;
        }
    }
    void Start()
    {

    }
}
