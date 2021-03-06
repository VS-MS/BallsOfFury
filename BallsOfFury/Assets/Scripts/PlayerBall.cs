﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerBall : MonoBehaviour
{
    [SerializeField, Header("Скорость движения шара")]
    private float speed;

    //Флаг направления, если значение true двигаем прямо,
    //если false двигаем направо
    [HideInInspector]
    public bool Direction;
    private Rigidbody playerRigidbody;

    [Inject]
    private GameController gameController;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Проверяем, если игрок сорвался с платформы, перестаем его толкать,
        if(GetPlatform() && gameController.IsGame)
        {
            if (Direction)
            {
                playerRigidbody.velocity = Vector3.forward * speed;
            }
            else
            {
                playerRigidbody.velocity = Vector3.right * speed;
            }
        }
        
    }
    //Стреляем лучем под ноги и смотрим там наличие платформы.
    //Если платформа есть, возврашаем true
    //если платформа не нашлась, возврашаем false
    private bool GetPlatform()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, -Vector3.up * hit.distance, Color.yellow);
            return true;
        }
        else
        {
            Debug.DrawRay(transform.position, -Vector3.up * 1000, Color.white);
            return false;
        }
    }

    public void SetVelocity(Vector3 vectorVelosity)
    {
        this.GetComponent<Rigidbody>().velocity = vectorVelosity;
    }

    public void SetAngularVelocity(Vector3 vectorVelosity)
    {
        this.GetComponent<Rigidbody>().angularVelocity = vectorVelosity;
    }
}
