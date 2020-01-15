using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject target;

    private void Awake()
    {

    }

    private void Update()
    {
        Vector3 position = target.transform.position;
        position += new Vector3(-2 ,3 ,-2);
        this.transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime * 2);
    }
}
