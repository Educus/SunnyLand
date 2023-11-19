using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeadTrigger : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int jumpPower;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            rigid = collision.GetComponent<Rigidbody2D>();
            Destroy(target);
            rigid.velocity = new Vector3(rigid.velocity.x, 0);
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }
}
