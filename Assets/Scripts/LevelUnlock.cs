using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LevelUnlock : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    int unlockedLevelsNumber;
    [SerializeField] TMP_Text[] numText;

    private void Start(){
        if(!PlayerPrefs.HasKey("levelsUnlocked")){
            PlayerPrefs.SetInt("levelsUnlocked", 1);     
        }
        
        unlockedLevelsNumber = PlayerPrefs.GetInt("levelsUnlocked");

        for (int i=0; i<buttons.Length; i++){
            if(i + 1 > unlockedLevelsNumber){
                buttons[i].interactable = false;
                numText[i].enabled = false;

            }
            
        }

        
    }

    private void Update(){
        unlockedLevelsNumber = PlayerPrefs.GetInt("levelsUnlocked");
        for(int i=0; i<unlockedLevelsNumber; i++){
            buttons[i].interactable = true;
            numText[i].enabled = true;
            
        }
    }
}
