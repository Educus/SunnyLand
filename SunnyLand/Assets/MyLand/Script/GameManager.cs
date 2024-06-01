using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject player;

    static public int stageMaxLevel = 0;
    static public int stageNowLevel = 0;
    static public int stageMoveLevel = 0;

    Vector3 StartingPos = new Vector3(0,0,0);

    private void Start()    // 게임 시작 시 메인화면이 아닐 경우 메인화면으로 이동
    {
        stageMaxLevel = SceneManager.sceneCountInBuildSettings - 1;
        // stageNowLevel = 0;

        //if (stageNowLevel != SceneManager.GetActiveScene().buildIndex)
        //    OnReLoadSence();
    }
    private void Update()
    {
        Debug.Log(stageNowLevel);
    }

    public void OnGameClear()   // 게임 클리어
    {
        ScoreManager.Instance.ScoreUpdate();
        UIManager.Instance.UIClear();
    }

    public void OnGameOver()    // 게임 오버
    {
        Invoke(nameof(OnLoadSence), 1.0f);
    }

    public int[] OnStageRead() // 현재의 스테이지 읽기 [0] 최대, [1] 현제
    {
        stageNowLevel = SceneManager.sceneCount;
        int[] stage = { stageMaxLevel, stageNowLevel };

        return stage;
    }

    public void OnMoveStage() // 스테이지 이동
    {
        stageNowLevel = stageMoveLevel;
        OnReLoadSence();
    }

    private void OnLoadSence() // 사망 시 이벤트
    {
        if(ScoreManager.Instance.life > 0)
        {
            UIManager.Instance.UILoading();
            ScoreManager.Instance.life -= 1;
            PlayerController.playing = true;
            StatusManager.Instance.ChangeCount();
            Invoke(nameof(PlayerPosReset), 1f);
        }
        else
        {
            UIManager.Instance.UIGameOver();
        }
    }

    private void PlayerPosReset() // 사망시 생명이 남아 있을 경우 이동
    {
        player.transform.position = StartingPos;
    }

    public void OnMoveStageSelect(float value)  // 일정시간 뒤 StageSelect로 이동
    {
        stageNowLevel = stageMaxLevel;
        Invoke(nameof(OnReLoadSence), value);
    }

    public void OnReLoadSence() // 현재씬 재시작
    {
        ScoreManager.Instance.life = 1;
        PlayerController.playing = true;
        SceneManager.LoadScene(stageNowLevel, LoadSceneMode.Single);
    }
}
