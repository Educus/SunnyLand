using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatItem : MonoBehaviour
{
    [SerializeField] int type;

    public int nowStage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            nowStage = GameManager.Instance.OnStageRead()[1];
            
            switch(type)
            {
                case 1:
                    ScoreManager.Instance.cherry[nowStage]++;
                    UITMP.Instance.ChangeCount();
                    break;
                case 2:
                    ScoreManager.Instance.gem[nowStage]++;
                    UITMP.Instance.ChangeCount();

                    break;

                default:
                    break;

            }

            Destroy(gameObject);
        }
    }
}
