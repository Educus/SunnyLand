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

    private void Start()    // ���� ���� �� ����ȭ���� �ƴ� ��� ����ȭ������ �̵�
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

    public void OnGameClear()   // ���� Ŭ����
    {
        ScoreManager.Instance.ScoreUpdate();
        UIManager.Instance.UIClear();
    }

    public void OnGameOver()    // ���� ����
    {
        Invoke(nameof(OnLoadSence), 1.0f);
    }

    public int[] OnStageRead() // ������ �������� �б� [0] �ִ�, [1] ����
    {
        stageNowLevel = SceneManager.sceneCount;
        int[] stage = { stageMaxLevel, stageNowLevel };

        return stage;
    }

    public void OnMoveStage() // �������� �̵�
    {
        stageNowLevel = stageMoveLevel;
        OnReLoadSence();
    }

    private void OnLoadSence() // ��� �� �̺�Ʈ
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

    private void PlayerPosReset() // ����� ������ ���� ���� ��� �̵�
    {
        player.transform.position = StartingPos;
    }

    public void OnMoveStageSelect(float value)  // �����ð� �� StageSelect�� �̵�
    {
        stageNowLevel = stageMaxLevel;
        Invoke(nameof(OnReLoadSence), value);
    }

    public void OnReLoadSence() // ����� �����
    {
        ScoreManager.Instance.life = 1;
        PlayerController.playing = true;
        SceneManager.LoadScene(stageNowLevel, LoadSceneMode.Single);
    }
}
