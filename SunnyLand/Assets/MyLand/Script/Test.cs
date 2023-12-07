using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(isTest());
        
    }

    IEnumerator isTest()
    {
        while(true)
        {
            Debug.Log("?");
            yield return new WaitForSeconds(1.0f);
            Debug.Log("??");
        }

    }
}

