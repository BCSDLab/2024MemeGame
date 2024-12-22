using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject explanationPage;
    [SerializeField] private GameObject settingPage;
    [SerializeField] private GameObject scorePage;

    void Start()
    {
        
    }

    void Update()
    {
        PressedEscButton();
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
        panel.SetActive(!panel.activeSelf);
        scorePage.SetActive(!scorePage.activeSelf);
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
