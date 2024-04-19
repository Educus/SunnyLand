using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIController : Singleton<UIController>
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject BackGround;
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject Clear;
    [SerializeField] GameObject AllClear;
    [SerializeField] GameObject TouchScreen;
    [SerializeField] GameObject Loading;

    [SerializeField] UnityEvent OnDeadPlayer;

    bool CheckClick = false;

    private void Update()
    {
        if (CheckClick == true && Input.GetMouseButtonDown(0))
        {
            // TouchScreen.SetActive(false);
            // GameOver.SetActive(false);
            // BackGround.SetActive(false);

            UITMP.Instance.ResetTMP();
            OnDeadPlayer.Invoke();
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

    IEnumerator IGameOver()
    {
        BackGround.SetActive(true);
        GameOver.SetActive(true);

        yield return new WaitForSeconds(2f);

        TouchScreen.SetActive(true);
        CheckClick = true;
    }
    IEnumerator ILoading()
    {
        BackGround.SetActive(true);
        Loading.SetActive(true);

        yield return new WaitForSeconds(3f);

        BackGround.SetActive(false);
        Loading.SetActive(false);
    }
    IEnumerator IClear()
    {
        BackGround.SetActive(true);
        Clear.SetActive(true);

        yield return null;

        // yield return new WaitForSeconds(3f);

        // Clear.SetActive(false);
        // BackGround.SetActive(false);
    }
}
