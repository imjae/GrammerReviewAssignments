using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    // static ObjectPool 변수 생성 <- 오브젝트 관리
    private static ObjectPooler _instance;
    public static ObjectPooler Instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    public Transform boardTransform;

    [Serializable]
    public class Pool
    {
        public string tag = "";
        public GameObject prefab = null;
        public int size = 0;
    }
    [SerializeField] Pool[] pools;
    readonly string INFO = " 오브젝트에 다음을 적으세요 \nvoid OnDisable()\n{\n" +
        "    ObjectPooler.ReturnToPool(gameObject);    // 한 객체에 한번만 \n" +
        "    CancelInvoke();    // Monobehaviour에 Invoke가 있다면 \n}";

    List<GameObject> spawnObjects;
    Dictionary<string, Queue<GameObject>> poolDictionary;


    public static GameObject TakeFromPool(string tag) => Instance._TakeFromPool(tag);

    public static T TakeFromPool<T>(string tag) where T : Component
	{
		GameObject obj = Instance._TakeFromPool(tag);
		if (obj.TryGetComponent(out T component))
			return component;
		else
		{
			obj.SetActive(false);
			throw new Exception($"Component not found");
		}
	}


    public static void ReturnToPool(GameObject obj)
    {
        if (!Instance.poolDictionary.ContainsKey(obj.name))
            throw new Exception($"Pool with tag {obj.name} doesn't exist.");

        Instance.poolDictionary[obj.name].Enqueue(obj);
    }

    GameObject _TakeFromPool(string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
            throw new Exception($"Pool with tag {tag} doesn't exist.");

        // 큐에 없으면 새로 추가
        Queue<GameObject> poolQueue = poolDictionary[tag];
        if (poolQueue.Count <= 0)
        {
            Pool pool = Array.Find(pools, x => x.tag == tag);
            var obj = CreateNewObject(pool.tag, pool.prefab);
        }

        // 큐에서 꺼내서 사용
        GameObject objectToSpawn = poolQueue.Dequeue();
        objectToSpawn.SetActive(true);

        return objectToSpawn;
    }

    void Awake()
    {
        _instance = this;

        spawnObjects = new List<GameObject>();
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        // 미리 생성
        foreach (Pool pool in pools)
        {
            poolDictionary.Add(pool.tag, new Queue<GameObject>());
            for (int i = 0; i < pool.size; i++)
            {
                var obj = CreateNewObject(pool.tag, pool.prefab);
            }

            // OnDisable에 ReturnToPool 구현여부와 중복구현 검사
            if (poolDictionary[pool.tag].Count <= 0)
                Debug.LogError($"{pool.tag}{INFO}");
            else if (poolDictionary[pool.tag].Count != pool.size)
                Debug.LogError($"{pool.tag}에 ReturnToPool이 중복됩니다");
        }
    }

    GameObject CreateNewObject(string tag, GameObject prefab)
    {
        GameObject obj;
        if(tag.Equals("Cell")) {
            obj = Instantiate(prefab, boardTransform);
        }
        else { 
            obj = Instantiate(prefab, transform);
        }
        obj.name = tag;
        obj.SetActive(false); // 비활성화시 ReturnToPool을 하므로 Enqueue가 됨

        return obj;
    }

    // 동작 순서
    // 오브젝트풀 오브젝트가 생성될 때, 사이즈에 맞는 풀이 생성됨.
    // 셋팅되는 시점에서 SetActive(false) 사용하여 Disabled 이벤트 함수 호출하여
    // 풀로 집어넣는 함수 발동하게 함
    // 풀에서 꺼내오는 함수
    // 풀로 집언허는 함수
    // 풀에있는 오브젝트 전부 가져오는 함수
}
