using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] int type;
    [SerializeField] float speed1;
    [SerializeField] float speed2;

    Vector3 targetVector1;
    Vector3 targetVector2;

    private void Start()
    {
        targetVector1 = target.position;
    }

    void Update()
    {
        targetVector2 = target.position;
        Vector3 targetVector = targetVector2 - targetVector1;
        
        if(type == 1)   // back
        {
            transform.position += new Vector3(targetVector.x * speed1, targetVector.y, 0);

        }
        else if(type == 2)  // middle
        {
            transform.position += new Vector3(targetVector.x * speed2, targetVector.y, 0);
            float middleGround = targetVector2.x - transform.position.x;
            if(Mathf.Abs(middleGround) > 18.48)
            {
                Vector3 moveMiddle = (middleGround > 0) ? new Vector2(36.96f, 0) : new Vector2(-36.96f, 0);
                transform.position += moveMiddle;
            }
        }
        targetVector1 = targetVector2;
        
    }
}
