using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolSystem : MonoBehaviour
{
    [System.Serializable]
    public struct Pool
    {
        public GameObject poolPrefab;
        public string poolName;
        public int poolSize;
    }

    public static ObjectPoolSystem Instance;
    public List<Pool> poolList;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public void Awake()
    {
        Instance = this;
        AllocatePool();
    }
    
    public void AllocatePool()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in poolList)
        {
            Queue<GameObject> poolQueue = new Queue<GameObject>();
            for (int i = 0; i < pool.poolSize; i++)
            {
                var instanceGO = Instantiate(pool.poolPrefab);
                instanceGO.SetActive(false);
                poolQueue.Enqueue(instanceGO);
            }

            poolDictionary.Add(pool.poolName, poolQueue);
        }
    }

    public void ReturnToPool(GameObject obj, string poolName)
    {
        obj.SetActive(false);
        poolDictionary[poolName].Enqueue(obj);
    }

    public IEnumerator ReturnToPoolAfterSeconds(float seconds, GameObject targetObject, string poolName)
    {
        yield return new WaitForSeconds(seconds);
        ReturnToPool(targetObject, poolName);
    }

    public GameObject SpawnFromPool(string name, Vector3 position)
    {
        GameObject spawnGO = poolDictionary[name].Dequeue();

        spawnGO.SetActive(true);
        spawnGO.transform.position = position;

        //poolDictionary[name].Enqueue(spawnGO);

        return spawnGO;
    }
}
