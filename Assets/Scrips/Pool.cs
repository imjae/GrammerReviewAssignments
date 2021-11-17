using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Poolable
{
    // SetActive(false) 됐을 때 풀로 돌려줘야한다.
    void OnDisable();
}
