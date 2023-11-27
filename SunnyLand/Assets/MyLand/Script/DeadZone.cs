using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeadZone : MonoBehaviour
{
    [SerializeField] UnityEvent OnDeadPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
        if(collision.tag == "Player")
            OnDeadPlayer.Invoke();
    }
}
