using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] UnityEvent OnStart;

    public void OnStartB()
    {
        ScoreManager.Instance.ScoreAllReset();
        GameManager.stageNowLevel = GameManager.stageMaxLevel;
        OnStart.Invoke();
    }
    public void OnLoadB()
    {
        ScoreManager.Instance.ScoreDownLoad();
        GameManager.stageNowLevel = GameManager.stageMaxLevel;
        OnStart.Invoke();
    }
    public void OnSettiongB()
    {
        Debug.Log("SettiongB");
    }
    public void OnEndB()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


    public void OnPlayB()
    {
        UIManager.Instance.UISubMenu();
    }
    public void OnReStartB()
    {
        ScoreManager.Instance.ScoreReset();
        OnStart.Invoke();
    }
    public void OnExitB()
    {
        GameManager.stageMoveLevel = 
            GameManager.stageNowLevel == GameManager.stageMaxLevel ? 0 : GameManager.stageMaxLevel;
        OnStart.Invoke();

    }
}
