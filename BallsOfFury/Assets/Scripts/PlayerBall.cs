using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    [SerializeField]
    private float speed;

    //Если значение true двигаем прямо,
    //если false двигаем направо
    public bool Direction;
    private Rigidbody playerRigidbody;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(Direction)
        {
            playerRigidbody.AddForce(Vector3.forward * speed * Time.fixedDeltaTime);
        }
        else
        {
            playerRigidbody.AddForce(Vector3.right * speed * Time.fixedDeltaTime);
        }
        
    }
}
