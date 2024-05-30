using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    public GameObject player;

    Vector3 StartingPos;
    Quaternion StartingRot;
    bool isStarted = false;

    static public int stageMaxLevel = 0;
    static public int stageNowLevel = 0;
    static public int stageMoveLevel = 0;


    private void Start()
    {
        stageMaxLevel = SceneManager.sceneCountInBuildSettings - 1;
        stageNowLevel = 0;

        if (stageNowLevel != SceneManager.GetActiveScene().buildIndex)
            OnReLoadSence();
    }

    public int[] OnStageRead()
    {
        stageNowLevel = SceneManager.sceneCount;
        int[] stage = { stageMaxLevel, stageNowLevel };

        return stage;
    }
    public void OnStageWrite(int stageNextL)
    {
        stageMoveLevel = stageNextL;
    }


    public void OnGameClear()
    {
        UITMP.Instance.SaveTmp();
        if (stageNowLevel >= stageMaxLevel)
        {
            UIController.Instance.UIAllClear();
        }
        else if(stageNowLevel < stageMaxLevel)
        { 
            UIController.Instance.UIClear();
        }
    }

    public void OnNextStage()
    {
        stageNowLevel++;
        PlayerController.playing = true;
        OnReLoadSence();
    }

    public void OnGameOver()
    {
        Invoke(nameof(OnLoadSence), 1.0f);
    }

    private void OnLoadSence()
    {
        if(UITMP.life > 0)
        {
            UITMP.life--;
            UITMP.gemCount = UITMP.saveCount[0];
            UITMP.cherryCount = UITMP.saveCount[1];

            OnReLoadSence();
        }
        else
        {
            UIController.Instance.UIGameOver();
        }
    }

    public void OnReLoadSence()
    {
        PlayerController.playing = true;
        SceneManager.LoadScene(stageNowLevel, LoadSceneMode.Single);
    }

    public void OnMovingStage(int stage)
    {
        stageNowLevel = stage + 1;
        PlayerController.playing = true;
        OnReLoadSence();
    }

   
}
