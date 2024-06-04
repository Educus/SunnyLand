using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageRock : MonoBehaviour
{
    int total;

    private void Start()
    {
        total = transform.childCount;     // ¶ó¿îµåÀÇ ÃÑ °¹¼ö
        Invoke(nameof(RockScore), 0f);
    }

    void Update()
    {
        for (int i = 0; i < total; i++)
        {
            if (ScoreManager.Instance.ScoreLoad(i + 1, 0) >= 3)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        
    }
    void RockScore()
    {
        for (int i = 0; i < total; i++)
        {
            int gem = ScoreManager.Instance.ScoreLoad(i + 1, 0);
            TMP_Text needGem = transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();

            needGem.text = "need gem\n" + gem + " / 3";
        }
    }
}
