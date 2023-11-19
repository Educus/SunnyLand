using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] bool walk;
    [SerializeField] bool fly;
    [SerializeField] bool jump;
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3[] position;

    SpriteRenderer spr;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if((transform.position.x - target.position.x) > 0) spr.flipX = false;
        else if((transform.position.x - target.position.x) < 0) spr.flipX = true;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        for(int i = 0; i < position.Length - 2; i++)
        {
            Gizmos.DrawLine(position[i], position[i + 1]);
        }
    }
    /*
    private void a OnDrawGizmos()
    {
        if (position == null) return;

        Vector3 pivot = Application.isPlaying ? originPosition : transform.position;

        for (int i = 0; i < position.Length - 1; i++)
        {
            Vector3 start = pivot + position[i];
            Vector3 end = pivot + position[i + 1];
            Gizmos.DrawLine(start, end);
        }
    }
    */
}
