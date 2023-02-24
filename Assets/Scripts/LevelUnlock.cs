using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LevelUnlock : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    [SerializeField] public static int unlockedLevelsNumber;
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

        if(unlockedLevelsNumber == 5){
            AchievementManager.instance.Unlock("Primeiros passos fofos");
        }
        if(unlockedLevelsNumber == 10){
            AchievementManager.instance.Unlock("Pegando o jeito");
        }
        if(unlockedLevelsNumber == 15){
            AchievementManager.instance.Unlock("Talvez isso seja viciante");
        }
        if(unlockedLevelsNumber == 20){
            AchievementManager.instance.Unlock("Não é uma fase mãe");
        }
        if(unlockedLevelsNumber == 25){
            AchievementManager.instance.Unlock("Graduado em apertar slimes");
        }
        if(unlockedLevelsNumber == 30){
            AchievementManager.instance.Unlock("Me chame de Dr Slime");
        }
        if(unlockedLevelsNumber == 31){
            AchievementManager.instance.Unlock("De repente 31");
        }
        if(unlockedLevelsNumber == 32){
            AchievementManager.instance.Unlock("Estrelato");
        }
    }

    
}
