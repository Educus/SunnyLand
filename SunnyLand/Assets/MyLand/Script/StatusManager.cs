using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class StatusManager : Singleton<StatusManager>
{
    [SerializeField] TMP_Text Stage;
    [SerializeField] TMP_Text Life;
    [SerializeField] TMP_Text GemCount;
    [SerializeField] TMP_Text CherryCount;

    int maxStage;
    int stage;
    int mainStage;

    public void FirstStart()
    {
        ChangeCount();

        maxStage = GameManager.stageNowLevel;
        stage = GameManager.stageNowLevel;
        mainStage = (GameManager.stageNowLevel - 2) / 3 + 1;
    }
    
    public void ChangeCount()
    {
        mainStage = (GameManager.stageNowLevel - 2) / 3 + 1;
        stage = GameManager.stageNowLevel;

        if (stage == 0) { }
        else if (stage == maxStage) { }
        else if (stage == 1)
            Stage.text = "Stage Tutorial";
        else
            Stage.text = "Stage " + mainStage + " - " + (stage - 1);

        Life.text = "X" + ScoreManager.Instance.life.ToString();
        GemCount.text = "X" + ScoreManager.Instance.gem.ToString();
        CherryCount.text = "X" + ScoreManager.Instance.cherry.ToString();
    }
}
