using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class CrankTrigger : MonoBehaviour
{
    // [SerializeField] UnityEvent CrankEvent;
    [SerializeField] Transform BridgeMain;
    [SerializeField] Transform bridge;

    Animator anim;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (anim.GetBool("TouchCrank") == false)
            {
                StartCoroutine(RotationBridge());
            }
            anim.SetBool("TouchCrank", true);
        }
    }
    
    IEnumerator RotationBridge()
    {
        Vector3 rotVec;
        int rot;
        
        if (bridge.rotation.z < 0)
        {
            rotVec = Vector3.forward * 90;
            rot = -4;
        }
        else
        {
            rotVec = Vector3.forward * -90;
            rot = 4;
        }
        bridge.position = BridgeMain.position;
        bridge.Rotate(rotVec);
        bridge.Translate(bridge.right * rot, Space.World);

        yield return null;
    }
}
