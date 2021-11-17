using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour
{
    // 게임판의 사이즈가 정해지면 ObjectPool의 크기가 정해진다.

    // static ObjectPool 변수 생성 <- 오브젝트 관리

    // 동작 순서
    // 오브젝트풀 오브젝트가 생성될 때, 사이즈에 맞는 풀이 생성됨.
    // 셋팅되는 시점에서 SetActive(false) 사용하여 Disabled 이벤트 함수 호출하여
    // 풀로 집어넣는 함수 발동하게 함


    // 풀에서 꺼내오는 함수

    // 풀로 집언허는 함수

    // 풀에있는 오브젝트 전부 가져오는 함수

}
