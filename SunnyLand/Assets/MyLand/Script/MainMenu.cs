using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] UnityEvent OnStart;
    [SerializeField] UnityEvent OnEnd;

    public int _gemCount = 0;
    public int _cherryCount = 0;
    public int _life = 0;
    public int _stageLevel = 0;

    public void OnStartB()
    {
        UITMP.Instance.FormatTMP();
        GameManager.stageLevel += 1;
        OnStart.Invoke();
    }
    public void OnLoadB()
    {
        _gemCount = PlayerPrefs.GetInt("gemCount");
        _cherryCount = PlayerPrefs.GetInt("cheeyCount");
        _life = PlayerPrefs.GetInt("life");
        _stageLevel = PlayerPrefs.GetInt("stageLevel");

        DownLoadUI();
    }
    public void OnMapB()
    {
        Debug.Log("MapB");
    }
    public void OnSettiongB()
    {
        Debug.Log("SettiongB");
    }
    public void OnEndB()
    {
        Debug.Log("EndB");
        Application.Quit();
    }


    public void OnPlayB()
    {
        UIController.Instance.UISubMenu();
    }
    public void OnReStartB()
    {
        UITMP.Instance.ResetTMP();
        OnStart.Invoke();
    }
    public void OnSaveB()
    {
        UpLoadUi();

        PlayerPrefs.SetInt("gemCount", _gemCount);
        PlayerPrefs.SetInt("cheeyCount", _cherryCount);
        PlayerPrefs.SetInt("life", _life);
        PlayerPrefs.SetInt("stageLevel", _stageLevel);
    }
    public void OnExitB()
    {
        GameManager.stageLevel = 0;
        OnStart.Invoke();
    }

    private void DownLoadUI()
    {
        UITMP.saveCount[0] = _gemCount;
        UITMP.saveCount[1] = _cherryCount;
       UITMP.life = _life;
       GameManager.stageLevel = _stageLevel;

        OnReStartB();
    }
    private void UpLoadUi()
    {
        _gemCount = UITMP.saveCount[0];
        _cherryCount = UITMP.saveCount[1];
        _life = UITMP.life;
        _stageLevel = GameManager.stageLevel;

    }

}
