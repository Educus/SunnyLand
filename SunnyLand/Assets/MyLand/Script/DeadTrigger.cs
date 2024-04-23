using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DeadTrigger : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float lender;
    [SerializeField] int jumpPower;
    [SerializeField] UnityEvent deathEffect;

    Collider2D colE;
    Rigidbody2D rigidE;

    private void Start()
    {
        colE = GetComponent<Collider2D>();
        rigidE = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        if ((transform.position.y - target.transform.position.y) != lender)
        {
            transform.position = new Vector2(target.transform.position.x, target.transform.position.y + lender);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            rigid = collision.GetComponent<Rigidbody2D>();
            rigid.velocity = new Vector3(rigid.velocity.x, 0);
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

            colE.enabled = false;
            rigidE.simulated = false;
            deathEffect.Invoke();
        }
    }
}
