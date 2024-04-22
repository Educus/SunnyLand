using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEditor.SceneManagement;

public class UITMP : Singleton<UITMP>
{
    [SerializeField] TMP_Text Stage;
    [SerializeField] TMP_Text Life;
    [SerializeField] TMP_Text GemCount;
    [SerializeField] TMP_Text CherryCount;

    public static int life = 1;
    public static int gemCount = 0;
    public static int cherryCount = 0;
    public static int[] saveCount = { 0, 0 };

    int maxStage = GameManager.stageMaxLevel;
    int stage = GameManager.stageLevel;
    int mainStage = (GameManager.stageLevel - 1) / 3 + 1;

    void Start()
    {
        if (stage == 0) { }
        if (stage == 1)
            Stage.text = "Stage Tutorial";
        else
            Stage.text = "Stage " + mainStage + " - " + (stage - 1);

        Life.text = "X" + life.ToString();
        GemCount.text = "X" + gemCount.ToString();
        CherryCount.text = "X" + cherryCount.ToString();
    }
    
    public void ChangeCount()
    {
        mainStage = (GameManager.stageLevel - 1) / 3 + 1;
        stage = GameManager.stageLevel;

        if (stage == 0) { }
        else if (stage == 1)
            Stage.text = "Stage Tutorial";
        else
            Stage.text = "Stage " + mainStage + " - " + (stage - 1);

        Life.text = "X" + life.ToString();
        GemCount.text = "X" + gemCount.ToString();
        CherryCount.text = "X" + cherryCount.ToString();
    }

    public void SaveTmp()
    {
        saveCount[0] = gemCount;
        saveCount[1] = cherryCount;
    }

    public void ResetTMP()
    {
        mainStage = 0;
        stage = 0;
        life = 1;
        gemCount = saveCount[0];
        cherryCount = saveCount[1];
    }
}
