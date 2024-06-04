using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float MoveSpeed;
    [SerializeField] float jumpPower;
    [SerializeField] UnityEvent OnDeadPlayer;

    Rigidbody2D rigid;
    SpriteRenderer spritRender;
    Animator anim;
    Collider2D col;
    bool isGrounded;
    static public bool playing = true; 

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spritRender = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }
    void Update()
    {
        if(playing)
        { 
            Move();
            Jump();
            GroundCheck();
        }
        
        void Move()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            if (x == -1) spritRender.flipX = true;
            else if (x == 1) spritRender.flipX = false;
            
            anim.SetInteger("VelocityX",(int)x);
            anim.SetFloat("VelocityY",rigid.velocity.y);

            rigid.velocity = new Vector2(x * MoveSpeed, rigid.velocity.y);
        }
        
        void Jump()
        {
            if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                anim.SetTrigger("Jump");
                rigid.velocity = new Vector2(rigid.velocity.x, 0);
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
        }

        void GroundCheck()
        {
            int layer = 136;
            isGrounded = Physics2D.OverlapBox(transform.position, new Vector2(0.85f, 0.05f),0, layer);
            
            if (isGrounded) anim.SetBool("IsGrounded", true);
            else anim.SetBool("IsGrounded", false);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(transform.position, new Vector2(0.85f,0.05f));
    }

    public void OnDead()
    {
        col.enabled = false;
        rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        playing = false;
        anim.SetTrigger("Hurt");

        OnDeadPlayer.Invoke();
        Invoke(nameof(OnHealing), 1.8f);
    }
    public void OnHealing()
    {
        col.enabled = true;
        playing = true;
        anim.SetTrigger("Healing");
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;

    }
    public void OnClear()
    {
        rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        playing = false;
        anim.SetTrigger("Clear");
    }
}
