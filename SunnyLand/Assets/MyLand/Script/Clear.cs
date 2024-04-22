using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clear : MonoBehaviour
{
    [SerializeField] UnityEvent ClearPlayer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKey(KeyCode.UpArrow))
        {
            PlayerController.playing = false;
            ClearPlayer.Invoke();
        }

    }
}
