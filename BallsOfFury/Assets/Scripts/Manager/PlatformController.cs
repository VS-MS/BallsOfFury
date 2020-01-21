using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlatformController : MonoBehaviour
{

    [SerializeField]
    private Vector3 firstPlatformPosition;
    private Vector3 platformPosition;
    [SerializeField]
    private int ListSize;

    [Inject]
    PlatformBehaviour.Factory factoryPlatform;
    [Inject]
    CapsuleBehaviour.Factory factoryCapsule;

    public List<GameObject> PooledObjectsPlatform;
    public List<GameObject> PooledObjectsCapsule;

    private void Awake()
    {
        for (int i = 0; i < ListSize; i++)
        {
            var obj = factoryPlatform.Create();
            obj.gameObject.SetActive(false);
            PooledObjectsPlatform.Add(obj.gameObject);
        }

        for (int i = 0; i < ListSize; i++)
        {
            var obj = factoryCapsule.Create();
            obj.gameObject.SetActive(false);
            PooledObjectsCapsule.Add(obj.gameObject);
        }
    }
    public void Initialize()
    { 
        ObjCreate(PooledObjectsPlatform, firstPlatformPosition);
        platformPosition = firstPlatformPosition;

        for (int i = 0; i < ListSize - 1; i++)
        {
            if (Random.Range(0, 2) == 0)
            {
                platformPosition += new Vector3(1, 0, 0);
                ObjCreate(PooledObjectsPlatform, platformPosition);
                if (Random.Range(1, 101) <= 20)
                {
                    ObjCreate(PooledObjectsCapsule, platformPosition + new Vector3(0, 0.4f, 0));
                }
            }
            else
            {
                platformPosition += new Vector3(0, 0, 1);
                ObjCreate(PooledObjectsPlatform, platformPosition);
                if (Random.Range(1, 101) <= 20)
                {
                    ObjCreate(PooledObjectsCapsule, platformPosition + new Vector3(0, 0.4f, 0));
                }
            }
        }   
    }
    
    public void ObjCreate(List<GameObject> gameObjects, Vector3 position)
    {
        
        for (int i = 0; i < gameObjects.Count; i++)
        {
            if (!gameObjects[i].activeSelf)
            {
                gameObjects[i].transform.position = position;
                gameObjects[i].SetActive(true);
                break;
            }  
        }
        
    }

    public void DiactivateAllObj()
    {
        for (int i = 0; i < PooledObjectsPlatform.Count; i++)
        {
            PooledObjectsPlatform[i].SetActive(false);
        }

        for (int i = 0; i < PooledObjectsCapsule.Count; i++)
        {
            PooledObjectsCapsule[i].SetActive(false);
        }

    }

    public void SetNewPositionObj(GameObject platformObj)
    {
        if (Random.Range(0, 2) == 0)
        {
            platformPosition += new Vector3(1, 0, 0);
            platformObj.transform.position = platformPosition;
            if (Random.Range(1, 101) <= 20)
            {
                ObjCreate(PooledObjectsCapsule, platformPosition + new Vector3(0, 0.4f, 0));
            }    
        }
        else
        {
            platformPosition += new Vector3(0, 0, 1);
            platformObj.transform.position = platformPosition;
            if (Random.Range(1, 101) <= 20)
            {
                ObjCreate(PooledObjectsCapsule, platformPosition + new Vector3(0, 0.4f, 0));
            }   
        }
    }
}
