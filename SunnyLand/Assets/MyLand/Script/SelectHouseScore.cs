using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectHouseScore : MonoBehaviour
{
    int total;

    void Start()
    {
        total = transform.childCount;
        Invoke(nameof(HouseScore), 0f);

    }

    public void HouseScore()
    {
        for (int i = 0; i < total; i++)
        {
            int cherry = ScoreManager.Instance.ScoreLoad(i + 1, 1);
            GameObject scoreObj = transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            TMP_Text needCherry = scoreObj.GetComponent<TMP_Text>();

            needCherry.text = "Score " + cherry + " / 10";
            // scoreObj.SetActive(false);

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            HouseScore();

            for (int i = 0; i < total; i++)
            {
                GameObject scoreObj = transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;

                scoreObj.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            for (int i = 0; i < total; i++)
            {
                GameObject scoreObj = transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;

                scoreObj.SetActive(false);
            }
        }
    }
}
