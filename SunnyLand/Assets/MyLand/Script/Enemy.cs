using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] bool walk;
    [SerializeField] bool fly;
    [SerializeField] float moveSpeed;
    [SerializeField] bool jump;
    [SerializeField] float jumpPower;
    [SerializeField] Vector3[] position;

    SpriteRenderer spr;
    Vector3 originPosition;
    bool isReverse;
    int index;

    Vector3 destination => originPosition + position[index];

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();

        originPosition = transform.position;
        index = 0;
        isReverse = false;
    }
    private void Update()
    {
        if (walk == true || fly == true)
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
                if ((transform.position.x - target.position.x) > 0) spr.flipX = false;
                else if ((transform.position.x - target.position.x) < 0) spr.flipX = true;
            }
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
}
