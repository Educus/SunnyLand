using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float moveSpeed;
    [SerializeField] bool walk;
    [SerializeField] int cycle;
    [SerializeField] bool jump;
    [SerializeField] float jumpPower;
    [SerializeField] bool fly;
    [SerializeField] Vector3[] position;

    SpriteRenderer spr;
    Rigidbody2D rigid;
    Vector3 originPosition;
    bool isReverse;
    int index;
    int delayTime;

    Vector3 destination => originPosition + position[index];

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();

        originPosition = transform.position;
        index = 0;
        isReverse = false;

        if (jump == true)
        {
            StartCoroutine(enemyJump());
        }
    }
    private void Update()
    {
        if ((walk == true && cycle == 0)|| fly == true) // 사이클 없이 걷기 or 날기
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
            if (transform.position == destination)
            {
                index += (isReverse ? -1 : 1);
                if (index == (isReverse ? 0 : position.Length - 1)) isReverse = !isReverse;
            }

            if (fly == true)
            {
                // fly몹일때 플레이어 위치마다 방향 전환
                filp(new Vector2(target.position.x, 0));
            }
        }
        else if(walk == true || jump == true)
        {
            
            Debug.Log(isReverse);
            if (jump == true)
            {
                // StartCoroutine(enemyJump());
            }
            else if(walk == true)
            {
                //rigid.velocity = new Vector2(moveSpeed/*뭔데 슈바*/,rigid.velocity.y);
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
            if(isReverse ? transform.position.x >= destination.x : transform.position.x <= destination.x)
            {
                index += (isReverse ? -1 : 1);
                if (index == (isReverse ? 0 : position.Length - 1)) isReverse = !isReverse;
            }

            filp(destination);
        }

       
        void filp(Vector2 nextTarget)
        {
            if ((nextTarget.x - transform.position.x) < 0) spr.flipX = false;
            else if ((nextTarget.x - transform.position.x) > 0) spr.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
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
    
    IEnumerator enemyJump()
    {
        rigid.AddForce(new Vector2((isReverse ? -1 : 1),1) * jumpPower, ForceMode2D.Impulse);
        Debug.Log("?");
        delayTime = Random.Range(0, cycle);
        yield return new WaitForSeconds(3.0f);
        Debug.Log("??");

    }
    
}
