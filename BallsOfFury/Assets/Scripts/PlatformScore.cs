using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScore : MonoBehaviour
{
    [SerializeField]
    private GameObject score;

    private void Start()
    {
        if(Random.Range(1, 100) <= 20)
        {
            score.SetActive(true);
        }
    }


}
