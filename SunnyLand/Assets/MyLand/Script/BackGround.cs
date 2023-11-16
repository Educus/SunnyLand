using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // 1-0.85 2-0.6-18.48,36.96f
    [SerializeField] Transform target;
    [SerializeField] float offset;
    [SerializeField] int countGround;
    [SerializeField] float speed;

    Vector3 targetVector1;
    Vector3 targetVector2;
    float offsetGround;

    private void Start()
    {
        targetVector1 = target.position;
        offsetGround = offset * countGround;
    }

    void LateUpdate()
    {
        targetVector2 = target.position;
        Vector3 targetVector = targetVector2 - targetVector1;
        
        transform.position += new Vector3(targetVector.x * speed, targetVector.y, 0);
        float groundOffset = targetVector2.x - transform.position.x;
        
        if (Mathf.Abs(groundOffset) > (offsetGround / 2))
        {
            Vector3 moveGround = (groundOffset > 0) ? new Vector2(offsetGround, 0) : new Vector2(-offsetGround, 0);
            transform.position += moveGround;
        }
        targetVector1 = targetVector2;
    }
}
