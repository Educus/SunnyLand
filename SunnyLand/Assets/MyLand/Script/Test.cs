using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Test : MonoBehaviour
{
    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.Q))
        {
            ScoreManager.Instance.ScoreUpLoad();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ScoreManager.Instance.ScoreDownLoad();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
        }

    }
}

