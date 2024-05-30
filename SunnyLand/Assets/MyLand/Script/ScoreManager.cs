using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    private int[,] score;

    int maxStage = 0;
    int nowStage = 0;

    public int[] stage;
    public int[] gem;
    public int[] cherry;

    private void Start()
    {
        maxStage = GameManager.Instance.OnStageRead()[0];
        nowStage = GameManager.Instance.OnStageRead()[1];
        score = new int[maxStage,2] ;
        stage = new int[maxStage];
        gem = new int[maxStage];
        cherry = new int[maxStage];
    }

    public int LoadScore(int nowStage, int num)
    {
        ScoreUpdate();
        return score[nowStage,num];
    }

    private void ScoreUpdate()
    {
        score[nowStage,0] = stage[nowStage];
        score[nowStage,1] = gem[nowStage];
        score[nowStage,2] = cherry[nowStage];
    }

    public void ScoreReset()
    {
        stage[nowStage] = 0;
        gem[nowStage] = 0;
        cherry[nowStage] = 0;
    }

}
