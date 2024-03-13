using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class UITMP : Singleton<UITMP>
{
    [SerializeField] TMP_Text Stage;
    [SerializeField] TMP_Text Life;
    [SerializeField] TMP_Text GemCount;
    [SerializeField] TMP_Text CherryCount;

    public static int mainStage = 0;
    public static int stage = 1;
    public static int life = 1;
    public static int gemCount = 0;
    public static int cherryCount = 0;

    void Start()
    {
        Stage.text = "Stage Tutorial";
        Life.text = "X" + life.ToString();
        GemCount.text = "X" + gemCount.ToString();
        CherryCount.text = "X" + cherryCount.ToString();
    }
    
    public void ChangeCount()
    {
        Stage.text = "Stage Tutorial";
        Life.text = "X" + life.ToString();
        GemCount.text = "X" + gemCount.ToString();
        CherryCount.text = "X" + cherryCount.ToString();
    }

    public void ResetTMP()
    {
        mainStage = 0;
        stage = 1;
        life = 2;
        gemCount = 0;
        cherryCount = 0;
    }
}
