using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreUI;
    [SerializeField] private TextMeshProUGUI maxScoreText;

    public delegate void UpdateScoreUI(int score);
    public static UnityEvent<int> CurrentScoreChanged = new UnityEvent<int>();
    public static UnityEvent<int> MaxScoreChanged = new UnityEvent<int>();

    private GameManager gameManager;

    private void Awake()
    {
        CurrentScoreChanged.AddListener(ChangeCurrentScoreUI);
        MaxScoreChanged.AddListener(ChangeMaxScoreUI);
    }

    private void Start()
    {
        gameManager = GameManager.getInstance();
        ChangeMaxScoreUI(gameManager.GetMaxScore());
    }

    private void OnDestroy()
    {
        CurrentScoreChanged.RemoveListener(ChangeCurrentScoreUI);
        MaxScoreChanged.RemoveListener(ChangeMaxScoreUI);
    }

    public void ChangeCurrentScoreUI(int currentScore)
    {
        currentScoreUI.text = currentScore.ToString();
    }

    public void ChangeMaxScoreUI(int maxScore)
    {
        maxScoreText.text = maxScore.ToString();
    }
}
