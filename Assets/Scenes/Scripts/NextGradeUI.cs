using UnityEngine;
using UnityEngine.UI;

public class NextGradeUI : MonoBehaviour
{
    private Image nextGradeDisplay;
    private RectTransform rectTransform;

    private void Awake()
    {
        nextGradeDisplay = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void DisplayNextGrade(Sprite sprite, float size)
    {
        nextGradeDisplay.sprite = sprite;
        rectTransform.localScale = Vector3.one * size;
    }
}
