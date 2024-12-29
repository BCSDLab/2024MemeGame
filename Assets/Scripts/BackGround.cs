using UnityEngine;
using UnityEngine.UI;

public class BackGround : MonoBehaviour
{
    void Start()
    {
        Canvas canvas = GetComponent<Canvas>();
        RectTransform rt = GetComponent<RectTransform>();
        float pixelsPerUnit = canvas.GetComponent<CanvasScaler>().referencePixelsPerUnit;
        rt.sizeDelta = new Vector2(Screen.width / pixelsPerUnit, Screen.height / pixelsPerUnit);
    }
}
