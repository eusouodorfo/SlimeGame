using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioOptionManager : MonoBehaviour
{
   public static float musicVolume{get; private set;}
   public static float soundEffectsVolume{get; private set;}

   [SerializeField] private TextMeshProUGUI musicSliderText;
   [SerializeField] private TextMeshProUGUI soundEffectsSliderText;

   public void OnMusicSliderValueChange(float value){
        musicVolume = value;
        musicSliderText.text = value.ToString();
   }
}
