using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellX : Cell
{
    // Start is called before the first frame update
    void Start()
    {
        CellText = "X";
    }

    public override void OnDisable()
    {
        ObjectPooler.ReturnToPool(gameObject);
    }
}
