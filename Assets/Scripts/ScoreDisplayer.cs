using TMPro;
using UnityEngine;

public class ScoreDisplayer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreData;
    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text = scoreData.text;
    }
}
