using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class ObjectPoolItem
    {
        public int AmountToPool;
        public GameObject ObjectToPool;
        public bool ShouldExpand;
    }
    //public static ObjectPooler SharedInstance;
    public List<GameObject> PooledObjects;
    public List<ObjectPoolItem> ItemsToPool;

    void Awake()
    {
        PooledObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in ItemsToPool)
        {
            for (int i = 0; i < item.AmountToPool; i++)
            {
                GameObject obj = Instantiate(item.ObjectToPool);
                obj.SetActive(false);
                PooledObjects.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(string tag)
    {
        for (int i = 0; i < PooledObjects.Count; i++)
        {
            if (!PooledObjects[i].activeInHierarchy && PooledObjects[i].tag == tag)
            {
                return PooledObjects[i];
            }
        }
        foreach (ObjectPoolItem item in ItemsToPool)
        {
            if (item.ObjectToPool.tag == tag)
            {
                if (item.ShouldExpand)
                {
                    GameObject obj = Instantiate(item.ObjectToPool);
                    obj.SetActive(false);
                    PooledObjects.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }

    public void DiactivateAllItem()
    {
        Debug.Log(PooledObjects.Count);
        for (int i = 0; i < PooledObjects.Count; i++)
        {
            PooledObjects[i].SetActive(false);
            Debug.Log("wwww");
        }
    }
}
