using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour
{
	private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BgPref = "BgPref";
    private int firstInt;
    public Slider bgSlider;
    private float bgfloat; 

    void Start()
    {
        firstInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstInt == 0)
        {
            bgfloat = .25f;
            bgSlider.value = bgfloat;
            PlayerPrefs.SetFloat(BgPref, bgfloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
		}
        else
        {
            bgfloat = PlayerPrefs.GetFloat(BgPref);
            bgSlider.value = bgfloat;
		}
	}
    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BgPref, bgSlider.value);
	}
    void OnApplicationFocus(bool inFocus)
    {
        if(!inFocus)
        {
            SaveSoundSettings();  
		}
	} 
}
