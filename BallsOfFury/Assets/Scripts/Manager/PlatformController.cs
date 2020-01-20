using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlatformController : MonoBehaviour
{
    [SerializeField]
    private Vector3 firstPlatformPosition;
    private Vector3 platformPosition;
    [Inject]
    private ObjectPooler objectPooler;

    public GameObject Panel;
    public GameObject Capsule;

    public List<GameObject> PooledPanels;
    public List<GameObject> PooledCapsule;

    private void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = Instantiate(Panel);
            obj.SetActive(false);
            PooledPanels.Add(obj);
        }
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = Instantiate(Capsule);
            obj.SetActive(false);
            PooledCapsule.Add(obj);
        }
    }
    public void Initialize()
    {
        ObjCreate("Platform", firstPlatformPosition);
        platformPosition = firstPlatformPosition;

        for (int i = 0; i < 10; i++)
        {
            if (Random.Range(0, 2) == 0)
            {
                platformPosition += new Vector3(1, 0, 0);
                ObjCreate("Platform", platformPosition);
                if (Random.Range(1, 101) <= 20)
                {
                    ObjCreate("Capsule", platformPosition + new Vector3(0, 0.4f, 0));
                }
            }
            else
            {
                platformPosition += new Vector3(0, 0, 1);
                ObjCreate("Platform", platformPosition);
                if (Random.Range(1, 101) <= 20)
                {
                    ObjCreate("Capsule", platformPosition + new Vector3(0, 0.4f, 0));
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
    public void ObjCreate(string tag, Vector3 position)
    {
        GameObject gameObject = objectPooler.GetPooledObject(tag);
        gameObject.transform.position = position;
        gameObject.SetActive(true);
    }
}
