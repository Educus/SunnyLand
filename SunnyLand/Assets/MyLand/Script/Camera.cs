using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float moveSpeed;

    Vector3 selectVector = new Vector3 (0, 3, 0);

    void LateUpdate()
    {
        if (GameManager.stageNowLevel == GameManager.stageMaxLevel)
        {
            Vector3 destination = target.position + offset + selectVector;
            transform.position = Vector3.Lerp(transform.position, destination, moveSpeed * Time.deltaTime);
        }
        else
        {
            Vector3 destination = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, destination, moveSpeed * Time.deltaTime);
        }
    }
}
