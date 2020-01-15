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
        //Проверяем, упал ли шарик с платформы по его коорлинатам Y
        //Если он начал падать, нужно остановить камеру, иначе она пройдет сквозь поатформу,
        //что вызовет артефакты изображения
        if(target.transform.position.y > 0)
        {
            Vector3 position = target.transform.position;
            position += new Vector3(-2, 3, -2);
            this.transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime * 2);
        }
        
    }
}
