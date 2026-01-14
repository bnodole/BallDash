using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioSource bgSound;
    public AudioSource gameSound;
    public Slider bgSoundSlider;
    public Slider otherSoundSlider;
    private void Update()
    {
        bgSoundSlider.value = PlayerPrefs.GetFloat("BgMusic");
        bgSound.volume = bgSoundSlider.value;

        otherSoundSlider.value = PlayerPrefs.GetFloat("OtherSounds");
        gameSound.volume = otherSoundSlider.value;
    }
    public void BackgroundMusic()
    {
        PlayerPrefs.SetFloat("BgMusic", bgSoundSlider.value);
    }

    public void OtherSouond()
    {
        PlayerPrefs.SetFloat("OtherSounds", otherSoundSlider.value);
    }
}
