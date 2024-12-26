using UnityEngine;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    private SoundManager soundManager;
    private Slider slider;

    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(soundManager.ChangeVolume);
    }
}
