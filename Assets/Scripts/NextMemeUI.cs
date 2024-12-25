using UnityEngine;
using UnityEngine.UI;

public class NextMemeUI : MonoBehaviour
{
    private Image nextMemeDisplay;
    private RectTransform rectTransform;

    private void Start()
    {
        nextMemeDisplay = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void DisplayNextMeme(Sprite sprite, float size)
    {
        nextMemeDisplay.sprite = sprite;
        rectTransform.localScale = Vector3.one * size;
    }
}
