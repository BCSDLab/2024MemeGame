using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject explanationPage;
    [SerializeField] private GameObject settingPage;
    [SerializeField] private GameObject scorePage;
    [SerializeField] private TextMeshProUGUI[] maxScores;

    public static UnityEvent<int[]> SetMaxScoresUI = new UnityEvent<int[]>();

    void Start()
    {
        UiManager.SetMaxScoresUI.AddListener(SetMaxScores);
        GameManager gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        startButton.onClick.AddListener(gameManager.LoadGameScene);
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

    public void SetMaxScores(int[] maxScores)
    {
        for(int i = 0; i < this.maxScores.Length; i++)
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
