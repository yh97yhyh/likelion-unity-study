using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    private static PoolManager _instance;
    public static PoolManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("PoolManager");
                _instance = go.AddComponent<PoolManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    // 프리팹 이름을 키로 사용하는 풀 딕셔너리
    private Dictionary<string, ObjectPool> pools = new Dictionary<string, ObjectPool>();

    void Start()
    {

    }

    void Update()
    {

    }

    public void CreatePool(GameObject prefab, int initialSize)
    {
        string key = prefab.name;
        if (!pools.ContainsKey(key))
        {
            pools.Add(key, new ObjectPool(prefab, initialSize, transform));
        }
    }

    public GameObject Get(GameObject prefab)
    {
        string key = prefab.name;
        if (!pools.ContainsKey(key))
        {
            CreatePool(prefab, 10);
        }
        return pools[key].GetObject();
    }

    public void Return(GameObject obj)
    {
        string key = obj.name.Replace("(Clone)", "");
        if (pools.ContainsKey(key))
        {
            pools[key].ReturnObject(obj);
        }
    }
}
