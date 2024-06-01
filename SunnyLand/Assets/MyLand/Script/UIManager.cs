using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] GameObject SubMenu;
    [SerializeField] GameObject BackGround;
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject Clear;
    [SerializeField] GameObject TouchScreen;
    [SerializeField] GameObject Loading;

    bool checkClick = false;
    bool subBool = false;

    TMP_Text clearText;

    private void Start()
    {
         clearText = Clear.GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (checkClick == true && Input.GetMouseButtonDown(0))
        {   // 완전 사망시, 클리어시 클릭표시가 뜨고 난 뒤 클릭했을 때
            GameOver.SetActive(false);
            Clear.SetActive(false);
            TouchScreen.SetActive(false);

            UILoading();
            GameManager.Instance.OnMoveStageSelect(1.3f);
        }
        else if (GameManager.stageNowLevel != 0 && Input.GetKeyUp(KeyCode.Escape))
        {
            UISubMenu();
        }
    }

    public void UIGameOver()
    {
        StartCoroutine(IGameOver());
    }
    public void UILoading()
    {
        StartCoroutine(ILoading());
    }
    public void UIClear()
    {
         StartCoroutine(IClear());
    }
    public void UISubMenu()
    {
        subBool = !subBool;
        UIManager.Instance.UISubMenu(subBool);
    }
    public void UISubMenu(bool subBool)
    {
        SubMenu.SetActive(subBool);
    }


    IEnumerator IGameOver()
    {
        BackGround.SetActive(true);
        GameOver.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        TouchScreen.SetActive(true);
        checkClick = true;
    }
    IEnumerator ILoading()
    {
        BackGround.SetActive(true);
        Loading.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        BackGround.SetActive(false);
        Loading.SetActive(false);
    }
    IEnumerator IClear()
    {
        int stageMain = (GameManager.stageNowLevel - 2) / 3 + 1;
        int stage = GameManager.stageNowLevel;
        int maxStage = GameManager.stageMaxLevel;

        if (stage == 0) { }
        else if (stage == maxStage) { }
        else if (stage == 1)
        {
            clearText.text = "Stage Tutorial" + "\nClear!";
        }
        else
        {
            clearText.text = "Stage " + stageMain + " - " + (stage - 1) % 3 + "\nClear!";
        }
        BackGround.SetActive(true);
        Clear.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        TouchScreen.SetActive(true);
        checkClick = true;
    }
}
