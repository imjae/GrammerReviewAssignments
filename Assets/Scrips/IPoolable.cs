using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    // SetActive(false) ���� �� Ǯ�� ��������Ѵ�.
    void OnDisable();
}
