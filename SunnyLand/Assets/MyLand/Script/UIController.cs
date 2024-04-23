using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UIController : Singleton<UIController>
{
    [SerializeField] GameObject SubMenu;
    [SerializeField] GameObject BackGround;
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject Clear;
    [SerializeField] GameObject TouchScreen;
    [SerializeField] GameObject Loading;
    [SerializeField] UnityEvent OnDeadPlayer;
    [SerializeField] UnityEvent OnNextStage;

    bool checkClick = false;
    bool clearStage = false;
    bool subBool = false;

    TMP_Text clearText;

    private void Start()
    {
         clearText = Clear.GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (checkClick == true && Input.GetMouseButtonDown(0))
        {
            GameOver.SetActive(false);
            Clear.SetActive(false);
            TouchScreen.SetActive(false);

            StartCoroutine(ILoading());
        }
        else if (GameManager.stageLevel != 0 && Input.GetKeyUp(KeyCode.Escape))
        {
            UISubMenu();
        }
    }

    public void UISubMenu(bool subBool)
    {
        SubMenu.SetActive(subBool);
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
    public void UIAllClear()
    {
        StartCoroutine(IAllClear());
    }
    public void UISubMenu()
    {
        subBool = !subBool;
        UIController.Instance.UISubMenu(subBool);
    }


    IEnumerator IGameOver()
    {
        BackGround.SetActive(true);
        GameOver.SetActive(true);

        yield return new WaitForSeconds(2f);

        TouchScreen.SetActive(true);
        checkClick = true;
    }
    IEnumerator ILoading()
    {
        BackGround.SetActive(true);
        Loading.SetActive(true);

        yield return new WaitForSeconds(2f);


        if (clearStage)
        {
            clearStage = false;
            OnNextStage.Invoke();
        }
        else
        {
            UITMP.Instance.ResetTMP();
            OnDeadPlayer.Invoke();
        }

        // BackGround.SetActive(false);
        // Loading.SetActive(false);
    }
    IEnumerator IClear()
    {
        int stageMain = (GameManager.stageLevel - 2) / 3 + 1;
        int stage = GameManager.stageLevel;
        int maxStage = GameManager.stageMaxLevel;

        if (stage == 0) { }
        if (stage == 1)
        {
            clearText.text = "Stage Tutorial" + "\nClear!";
        }
        else if (stage == maxStage)
        {
            clearText.text = "Stage All" + "\nClear!";
        }
        else
        {
            clearText.text = "Stage " + stageMain + " - " + (stage - 1) % 3 + "\nClear!";
        }
        BackGround.SetActive(true);
        Clear.SetActive(true);

        yield return new WaitForSeconds(2f);

        TouchScreen.SetActive(true);
        clearStage = true;
        checkClick = true;
    }
    IEnumerator IAllClear()
    {
        BackGround.SetActive(true);
        Clear.SetActive(true);

        yield return null;
    }
}
