using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeMasterControl: MonoBehaviour
{
    float volumeMaster, volumeFX, volumeMusica;
    public Slider sliderMaster, sliderFX, sliderMusica;

    void Start(){

        sliderMaster.value = PlayerPrefs.GetFloat("Master");
        sliderFX.value = PlayerPrefs.GetFloat("FX");
        sliderMusica.value = PlayerPrefs.GetFloat("Musica");
    }

    void Update(){

    }

    public void VolumeMaster(float volume){
        volumeMaster = volume;
        AudioListener.volume = volumeMaster;

        PlayerPrefs.SetFloat("Master", volumeMaster);
    }

    public void VolumeFX(float volume){
        volumeFX = volume;
        GameObject[] Fxs = GameObject.FindGameObjectsWithTag("FX");
        for(int i = 0; i < Fxs.Length; i++){
            Fxs[i].GetComponent<AudioSource>().volume = volumeFX;
        }

        PlayerPrefs.SetFloat("FX", volumeFX);
    }

    public void VolumeMusica(float volume){
        volumeMusica = volume;
        GameObject[] Musicas = GameObject.FindGameObjectsWithTag("Musica");
        for(int i = 0; i < Musicas.Length; i++){
            Musicas[i].GetComponent<AudioSource>().volume = volumeMusica;
        }
        PlayerPrefs.SetFloat("Musica", volumeMusica);
    }
}
