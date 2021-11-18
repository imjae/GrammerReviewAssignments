using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellO : Cell
{
    // Start is called before the first frame update
    void Start()
    {
        CellText = "O";
    }

    public override void OnDisable()
    {
        ObjectPooler.ReturnToPool(gameObject);
    }
}
