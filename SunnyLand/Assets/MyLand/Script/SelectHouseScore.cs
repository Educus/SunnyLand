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

    void HouseScore()
    {
        for (int i = 0; i < total; i++)
        {
            int cherry = ScoreManager.Instance.ScoreLoad(i, 1);
            TMP_Text needCherry = transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();

            needCherry.text = "Score " + cherry + " / 10";

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        for (int i = 0; i < total; i++)
        {
            GameObject scoreObj = transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        
            scoreObj.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        for (int i = 0; i < total; i++)
        {
            GameObject scoreObj = transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        
            scoreObj.SetActive(false);
        }
    }
}
