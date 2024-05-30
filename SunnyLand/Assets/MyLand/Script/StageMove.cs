using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class StageMove : MonoBehaviour
{
    [SerializeField] UnityEvent MovingStage;
    public TMP_Text tmpText;

    // 0 = 튜토리얼, 1 ~ = 스테이지 1 ~

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            // MovingStage.Invoke();
            Debug.Log("inbuild");
            Debug.Log(SceneManager.sceneCountInBuildSettings);
            Debug.Log("count");
            Debug.Log(SceneManager.sceneCount);

        }

    }
}
