using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ScoreManager : Singleton<ScoreManager>
{
    private int[,] score;   // score[nowstage, num] => num( 0 = gem, 1 = cherry )

    int maxStage;
    int nowStage;

    private int countEatItem = 2;
    public int gem = 0;
    public int cherry = 0;
    public int life = 1;

    private void Start()
    {
        Invoke(nameof(ScoreDownLoad) , 0f);
    }
    public void FirstStart()
    {
        maxStage = GameManager.Instance.OnStageRead()[0];
        nowStage = GameManager.Instance.OnStageRead()[1];
        score = new int[maxStage, countEatItem];
        ScoreReset();
    }

    public int ScoreLoad(int nowStage, int num)
    {
        return score[nowStage,num];
    }

    public void ScoreUpdate()
    {
        if (score[nowStage, 0] <= gem)
            score[nowStage, 0] = gem;
        if (score[nowStage, 1] <= cherry)
            score[nowStage, 1] = cherry;

        ScoreUpLoad();
    }

    public void ScoreReset()
    {
        gem = 0;
        cherry = 0;
    }

    public void ScoreAllReset()
    {
        for (int i = 0; i < maxStage; i++)
        {
            for(int j = 0; j < countEatItem; j++)
            {
                score[i,j] = 0;
            }
        }
        ScoreUpLoad();
    }

    public void ScoreUpLoad()
    {
        int[] num = new int[maxStage];
        string strArr = null;

        for(int i = 0; i < maxStage; i++)
        {
            for(int j = 0; j < countEatItem; j++)
            {
                strArr = strArr + score[i,j];

                if (j < countEatItem - 1)
                {
                    strArr = strArr + ",";
                }
            }

            if (i < maxStage - 1)
            {
                strArr = strArr + ";";
            }

        }
        
        PlayerPrefs.SetString("score", strArr);
    }

    public void ScoreDownLoad()
    {
        string[] dataArr = PlayerPrefs.GetString("score").Split(';');
        for(int i = 0; i < maxStage; i++)
        {
            string[] scoreArr = dataArr[i].Split(',');
            
            for(int j = 0; j < countEatItem; j++)
            {
                score[i, j] = System.Convert.ToInt32(scoreArr[j]);
            }
        }
    }
}
