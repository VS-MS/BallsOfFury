using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerBall : MonoBehaviour
{
    [SerializeField]
    private float speed;

    //Если значение true двигаем прямо,
    //если false двигаем направо
    public bool Direction;
    private Rigidbody playerRigidbody;

    [Inject]
    private GameController gameController;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        gameController.Play();
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


    /*
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
    */
}
