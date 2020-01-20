using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Creator : MonoBehaviour
{
    [Inject]
    PlatformBehaviour.Factory factoryPlatform;
    [Inject]
    CapsuleBehaviour.Factory factoryCapsule;

    public List<GameObject> PooledObjectsPlatform;
    public List<GameObject> PooledObjectsCapsule;

    private void Awake()
    {
        for(int i = 0; i< 10; i++)
        {
            var obj = factoryPlatform.Create();
            obj.GetComponentInParent<Transform>().position = new Vector3(0,i,0);
            PooledObjectsPlatform.Add(obj.gameObject);
        }

        for (int i = 0; i < 10; i++)
        {
            var obj = factoryCapsule.Create();
            obj.GetComponentInParent<Transform>().position = new Vector3(2, i, 0);
            PooledObjectsPlatform.Add(obj.gameObject);
        }
    }
}