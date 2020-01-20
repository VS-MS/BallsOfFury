using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField]
    private Vector3 firstPlatformPosition;
    private Vector3 platformPosition;
    private void Start()
    {
        ObjCreate("Platform", firstPlatformPosition);
        platformPosition = firstPlatformPosition;

        for (int i = 0; i < 10; i++)
        {
            //bullet = ObjectPooler.SharedInstance.GetPooledObject("Platform");
            if(Random.Range(0,2) == 0)
            {
                platformPosition += new Vector3(1, 0, 0);
                ObjCreate("Platform", platformPosition);
                if (Random.Range(1, 101) <= 20)
                {
                    ObjCreate("Capsule", platformPosition);
                }
            }
            else
            {
                platformPosition += new Vector3(0, 0, 1);
                ObjCreate("Platform", platformPosition);
                if (Random.Range(1, 101) <= 20)
                {
                    ObjCreate("Capsule", platformPosition);
                }
            }
            
        }
    }
    public void Initialize()
    {
        
    }

    public void ObjCreate(string tag, Vector3 position)
    {
        GameObject gameObject = ObjectPooler.SharedInstance.GetPooledObject(tag);
        gameObject.transform.position = position;
        gameObject.SetActive(true);
    }
}
