using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float moveSpeed;

    void LateUpdate()
    {
        Vector3 destination= target.position + offset;
        transform.position = Vector3.Lerp(transform.position, destination, moveSpeed * Time.deltaTime);
    }
}
