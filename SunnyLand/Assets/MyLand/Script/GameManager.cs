using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void OnGameClear()
    {

    }

    public void OnGameOver()
    {
        Invoke(nameof(OnLoadSence), 1.0f);
    }

    private void OnLoadSence()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
