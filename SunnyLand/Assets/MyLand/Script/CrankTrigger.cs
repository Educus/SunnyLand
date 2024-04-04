using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrankTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent CrankEvent;

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}
