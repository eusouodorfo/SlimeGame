using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour{

    public AudioMixer audioMixer;
    
    public void SetVolume (float volume){
        audioMixer.SetFloat("volume", volume);    
    }

     public void SetMusicVolume (float music){
        audioMixer.SetFloat("music", music);   
    }

     public void SetFxVolume (float fx){
        audioMixer.SetFloat("fx", fx);    
    }

   
    public void SetFullscreen (bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }
    
}
