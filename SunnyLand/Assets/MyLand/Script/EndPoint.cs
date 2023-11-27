using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndPoint : MonoBehaviour
{
    [SerializeField] UnityEvent OnArrivePlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            OnArrivePlayer.Invoke();
            PlayerController player = collision.GetComponent<PlayerController>();
            player.OnClear();
        }
    }
}
