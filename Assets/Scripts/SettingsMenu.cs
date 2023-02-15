using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour{

    public AudioMixer audioMixer;
    public AudioMixer audioMixerFx;
    public AudioMixer audioMixerMusic;

    public void SetVolume (float volume){
        audioMixer.SetFloat("volume", volume);    
    }

    public void SetFxVolume (float fxVolume){
        audioMixerFx.SetFloat("fxVolume", fxVolume);    
    }

    public void SetMusicVolume (float musicVolume){
        audioMixerMusic.SetFloat("musicVolume", musicVolume);    
    }

    public void SetFullscreen (bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }
    
}
