using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Slider volumeSlider;
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume")) 
        {

            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();    
        
        }
        else 
        {
        
            Load(); 
        
        }
    }

    public void changeVolume()
    {
    
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    public void Load() 
    {
    
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    
    }

    public void Save()
    {

        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);

    }

}
