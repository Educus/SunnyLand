using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class StageMove : MonoBehaviour
{
    public TMP_Text tmpText;
    public int round;

    // 0 = Ʃ�丮��, 1 ~ = �������� 1 ~

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            GameManager.stageMoveLevel = round;
            ScoreManager.Instance.ScoreReset();
            GameManager.Instance.OnMoveStage();

        }

    }
}
