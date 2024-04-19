using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void OnGameClear()
    {
        UIController.Instance.UIClear();   
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
            UITMP.cherryCount = 0;
            UITMP.gemCount = 0;
            
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            UIController.Instance.UIGameOver();
        }
        
    }
}
