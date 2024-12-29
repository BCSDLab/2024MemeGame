using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExplanationPage : MonoBehaviour
{
    public int currentExplanationNum;

    public int CurrentExplanationNum
    {
        get { return currentExplanationNum; }
        set
        {
            currentExplanationNum = value;
            if (currentExplanationNum == 1)
                PrevExplanationBtn.interactable = false;
            else PrevExplanationBtn.interactable = true;
            if(currentExplanationNum == maxExplanationNum)
                NextExplanationBtn.interactable = false;
            else NextExplanationBtn.interactable= true;
            t_currentPageNum.text = currentExplanationNum.ToString();
        }
    } 
    public int maxExplanationNum;

    public TextMeshProUGUI t_currentPageNum;
    public TextMeshProUGUI t_maxPageNum;
    public Button PrevExplanationBtn;
    public Button NextExplanationBtn;
    public GameObject[] explanationPages;

    private void Start()
    {
        ResetExplanation();
    }

    private void OnDisable()
    {
        ResetExplanation();
    }

    public void ResetExplanation()
    {
        explanationPages[CurrentExplanationNum - 1].SetActive(false);
        CurrentExplanationNum = 1;
        explanationPages[CurrentExplanationNum - 1].SetActive(true);
    }

    public void OnClickPrevExplanation()
    {
        if(CurrentExplanationNum != 1)
        {
            explanationPages[CurrentExplanationNum - 1].SetActive(false);
            CurrentExplanationNum--;
            explanationPages[CurrentExplanationNum - 1].SetActive(true);
        }
    }

    public void OnClickNextExplanation()
    {
        if (CurrentExplanationNum != maxExplanationNum)
        {
            explanationPages[CurrentExplanationNum - 1].SetActive(false);
            CurrentExplanationNum++;
            explanationPages[CurrentExplanationNum - 1].SetActive(true);
        }
    }
}
