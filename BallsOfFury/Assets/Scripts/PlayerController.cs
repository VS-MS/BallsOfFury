using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [Inject]
    private PlayerBall player;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            player.Direction = !player.Direction;
        }
            
    }

}
