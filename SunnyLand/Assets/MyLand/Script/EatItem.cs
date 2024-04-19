using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatItem : MonoBehaviour
{
    [SerializeField] int type;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch(type)
            {
                case 1:
                    UITMP.cherryCount++;
                    UITMP.Instance.ChangeCount();
                    break;
                case 2:
                    UITMP.gemCount++;
                    UITMP.Instance.ChangeCount();

                    break;

                default:
                    break;

            }

            Destroy(gameObject);
        }
    }
}
