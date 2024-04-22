using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] UnityEvent OnStart;

    public void OnStartButton()
    {
        OnStart.Invoke();
    }

    public void OnLoadButton()
    {
        Debug.Log("LoadButton");
    }
    public void OnMapButton()
    {
        Debug.Log("MapButton");
    }
    public void OnSettiongButton()
    {
        Debug.Log("SettiongButton");
    }
    public void OnEndButton()
    {
        Debug.Log("EndButton");
        Application.Quit();
    }



}
