using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Poolable
{
    // SetActive(false) ���� �� Ǯ�� ��������Ѵ�.
    void OnDisable();
}
