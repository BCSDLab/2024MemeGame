using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject explanationPage;
    [SerializeField] private GameObject settingPage;
    [SerializeField] private GameObject scorePage;
    [SerializeField] private TextMeshProUGUI[] maxScores;

    public static UnityEvent<List<int>> SetMaxScoresUI = new UnityEvent<List<int>>();

    void Start()
    {
        UiManager.SetMaxScoresUI.AddListener(SetMaxScores);
    }

    void Update()
    {
        PressedEscButton();
    }

    void OnDestroy()
    {
        UiManager.SetMaxScoresUI.RemoveListener(SetMaxScores);
    }

    public void OnClickExplanationPage()
    {
        panel.SetActive(!panel.activeSelf);
        explanationPage.SetActive(!explanationPage.activeSelf);
    }

    public void OnClickSettingButton()
    {
        panel.SetActive(!panel.activeSelf);
        settingPage.SetActive(!settingPage.activeSelf);
    }

    public void OnClickScoreButton()
    {
        GameManager.UpdateScorePages?.Invoke();
        panel.SetActive(!panel.activeSelf);
        scorePage.SetActive(!scorePage.activeSelf);
    }

    public void SetMaxScores(List<int> maxScores)
    {
        for(int i = 0; i < maxScores.Count; i++)
        {
            this.maxScores[i].text = maxScores[i].ToString();
        }
    }

    public void PressedEscButton()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            if (explanationPage.activeSelf)
            {
                panel.SetActive(false);
                explanationPage.SetActive(false);
                return;
            }

            if (settingPage.activeSelf)
            {
                panel.SetActive(false);
                settingPage.SetActive(false);
                return;
            }

            if (scorePage.activeSelf)
            {
                panel.SetActive(false);
                scorePage.SetActive(false);
            }
        }
    }

    public void GameExit() { Application.Quit(); }
}
