using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] bool checkRight;   // 이미지 방향이 오른쪽이면 체크
    [SerializeField] float moveSpeed;
    [SerializeField] bool fly;
    [SerializeField] bool jump;
    [SerializeField] float jumpPower;
    [SerializeField] bool walk;
    [SerializeField] int cycle;
    [SerializeField] Vector3[] position;
    [SerializeField] float spritePivot;

    SpriteRenderer spr;
    Rigidbody2D rigid;
    Collider2D col;
    Vector3 originPosition;
    bool isReverse;
    bool moveCheck;
    bool moveTrue;
    bool isGrounded;
    bool isLive = true;
    int index;
    int delayTime;

    Animator anim;

    Vector3 destination => originPosition + position[index];

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;


        originPosition = transform.position;
        index = 0;
        isReverse = false;

        if(walk == true && cycle == 0 || fly == true)
        {
            StartCoroutine(enemyNotCycle());
        }
        else if (jump == true)
        {
            StartCoroutine(enemyJump());
        }
        else if (walk == true)
        {
            StartCoroutine (enemyWalk());
        }
    }
    private void Update()
    {
        if (!isLive)
            return;

        if (fly == true) // 날기
        {
            // 플레이어 위치마다 방향 전환
            filp(new Vector2(target.position.x, 0));
        }
        else
        {
            isGrounded = Physics2D.OverlapBox(transform.position - new Vector3 (0, spritePivot), new Vector2(0.85f, 0.05f), 0, 136);
            anim?.SetBool("IsGrounded", isGrounded);
            anim?.SetFloat("VelocityY", rigid.velocity.y);

            if (isGrounded == true && moveCheck == false)
            {
                moveTrue = false;
                rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
            else
            {
                rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
                moveTrue = true;
            }

            if(isReverse ? transform.position.x >= destination.x : transform.position.x <= destination.x)
            {
                index += (isReverse ? -1 : 1);
                if (index == (isReverse ? 0 : position.Length - 1)) isReverse = !isReverse;
            }

            if(moveCheck == true && isGrounded == true)   filp(destination);
        }

       
        void filp(Vector2 nextTarget)
        {
            float nextPosition = nextTarget.x - transform.position.x;
            if (checkRight == false && nextPosition <= 0 || checkRight == true && nextPosition >= 0) spr.flipX = false;
            else if (checkRight == false && nextPosition >= 0 || checkRight == true && nextPosition <= 0) spr.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        if (fly != true)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireCube(transform.position - new Vector3(0, spritePivot), new Vector2(0.85f, 0.05f));
        }

        if (position == null) return;

        Gizmos.color = Color.red;

        Vector3 pivot = Application.isPlaying ? originPosition : transform.position;

        for(int i = 0; i < position.Length - 1; i++)
        {
            Vector3 start = pivot + position[i];
            Vector3 end = pivot + position[i + 1];
            Gizmos.DrawLine(start, end);
        }

    }
    
    public void OnDeathTrigger()
    {
        isLive = false;
        col.enabled = false;
        if(fly != true)
            rigid.simulated = false;

        anim?.SetTrigger("deathEffect");
    }

    void OnDead()
    {
        Destroy(gameObject);
    }

    IEnumerator enemyNotCycle()
    {
        while (isLive)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
            if (transform.position == destination)
            {
                index += (isReverse ? -1 : 1);
                if (index == (isReverse ? 0 : position.Length - 1)) isReverse = !isReverse;
            }
            if(walk == true && cycle == 0)
            {
                moveCheck = true;
                isGrounded = true;
            }
            yield return null;
        }
    }

    IEnumerator enemyJump()
    {
        while (isLive)
        {
            moveCheck = true;
            yield return new WaitWhile(() => moveTrue == true);
            rigid.AddForce(new Vector2((isReverse ? 1 : -1), 2) * jumpPower, ForceMode2D.Impulse);
            anim.SetTrigger("Jump");
            yield return new WaitForSeconds(0.3f);
            moveCheck = false;

            delayTime = Random.Range(2, cycle);
            yield return new WaitForSeconds(delayTime);
        }

    }

    IEnumerator enemyWalk()
    {
        float count = 0;
        bool walking = true;
        
        while(isLive)
        {
            count += Time.deltaTime;
            if (count >= delayTime)
            {
                walking = !walking;
                count = 0;
                delayTime = Random.Range(2, cycle);
            }

            if (walking == true)
            {
                moveCheck = true;
                if(!moveTrue) yield return new WaitWhile(() => moveTrue == true);
                transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
            }
            else
            {
                moveCheck = false;
                if (moveTrue) yield return new WaitWhile(() => moveTrue == true);
            }

            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            PlayerController player = collision.collider.GetComponent<PlayerController>();
            player.OnDead();
        }
    }

}
