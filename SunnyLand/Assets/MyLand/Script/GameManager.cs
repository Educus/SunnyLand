using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject player;

    Vector3 StartingPos;
    Quaternion StartingRot;
    bool isStarted = false;

    public static int stageMaxLevel = 4;
    public static int stageLevel = 0;

    private void Start()
    {
        if(stageLevel != SceneManager.GetActiveScene().buildIndex)
            OnReLoadSence();
    }

    public void OnGameClear()
    {
        UITMP.Instance.SaveTmp();
        if (stageLevel >= stageMaxLevel)
        {
            UIController.Instance.UIAllClear();
        }
        else if(stageLevel < stageMaxLevel)
        { 
            UIController.Instance.UIClear();
        }
    }

    public void OnNextStage()
    {
        stageLevel++;
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
        SceneManager.LoadScene(stageLevel, LoadSceneMode.Single);
    }
}
