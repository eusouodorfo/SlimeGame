using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AchievmentManager : MonoBehaviour
{
    
     public GameObject achievmentPrefab;

     public Sprite[] sprites;

     public GameObject visualAchievment;

     public Dictionary<string, Achievments> achievments = new Dictionary<string, Achievments>();

     public Sprite unlockedSprite;

     private static AchievmentManager instance;

     private int fadeTime = 2;

     public static AchievmentManager Instance{
          get {          
               if (instance == null){
                    instance = GameObject.FindObjectOfType<AchievmentManager>();
               }
          return AchievmentManager.instance;
          }
     }

     //tentativa por adicao de progress
     public int achTagBlue;
     private int achTagBluePre, achTagRedPre;


     void Start(){

          CreateAchievment("General", "Primeiros passos fofos", "Liberou a fase 5", 10, 0);
          CreateAchievment("General", "Pegando o jeito", "Liberou a fase 10", 14, 0);
          CreateAchievment("General", "Talvez isso seja viciante", "Liberou a fase 15", 13, 0);
          CreateAchievment("General", "Não é uma fase mãe!", "Liberou a fase 20", 15, 0);
          CreateAchievment("General", "Graduado em apertar slimes", "Liberou a fase 25", 12, 0);
          CreateAchievment("General", "Me chame de Dr Slime", "Liberou a fase 30", 11, 0);
          CreateAchievment("General", "De repente 31", "Liberou a fase 31", 0, 0);
           
          CreateAchievment("General", "Estrelato", "Liberou todas as fases", 16, 0, new string[] 
          {"Primeiros passos fofos", "Pegando o jeito", "Talvez isso seja viciante", "Não é uma fase mãe!",
          "Graduado em apertar slimes", "Me chame de Dr Slime", "De repente 31"});

          CreateAchievment("General", "Slime de Rubi", "Destruiu 100 slimes vermelhos", 6, 100);
          CreateAchievment("General", "Slime de Topázio", "Destruiu 100 slimes amarelo", 1, 100);
          CreateAchievment("General", "Slime de Turquesa", "Destruiu 100 slimes azul", 3, 100);
          CreateAchievment("General", "Slime de Pérola", "Destruiu 100 slimes branco", 2, 100);
          CreateAchievment("General", "Slime de Ametista", "Destruiu 100 slimes roxo", 5, 100);
          CreateAchievment("General", "Slime de Esmeralda", "Destruiu 100 slimes verde", 4, 100);
          CreateAchievment("General", "Slime mole em pedra dura...", "Destruiu 50 pedras", 8, 50);
          CreateAchievment("General", "Bomber Man", "Explodiu 50 bombas", 7, 50);

          CreateAchievment("General", "Platina", "Platina", 9, 0, new string[]{"Estrelato", "Slime de Rubi",
          "Slime de Topázio", "Slime de Turquesa", "Slime de Pérola", "Slime de Ametista", "Slime de Esmeralda",
          "Slime mole em pedra dura...", "Bomber Man"});
      
      
     }

     void Update(){

          achTagBluePre = achTagBluePre + Board.tagBlue;

          
          //conquistas sobre alcancar fases
          if(LevelUnlock.unlockedLevelsNumber == 5){
                EarnAchievment("Primeiros passos fofos");
          }

          if(LevelUnlock.unlockedLevelsNumber == 10){
                EarnAchievment("Pegando o jeito");
          }

          if(LevelUnlock.unlockedLevelsNumber == 15){
                EarnAchievment("Talvez isso seja viciante");
          }

          if(LevelUnlock.unlockedLevelsNumber == 20){
                EarnAchievment("Não é uma fase mãe!");
          }

          if(LevelUnlock.unlockedLevelsNumber == 25){
                EarnAchievment("Graduado em apertar slimes");
          }

          if(LevelUnlock.unlockedLevelsNumber == 30){
                EarnAchievment("Me chame de Dr Slime");
          }

          if(LevelUnlock.unlockedLevelsNumber == 31){
                EarnAchievment("De repente 31");
          }

          if(LevelUnlock.unlockedLevelsNumber == 31){
                EarnAchievment("Estrelato");
          }

          //conquistas sobre pedras e bombas destruidas
          if(SFXManager.bombCount >= 50){
                EarnAchievment("Bomber Man");
          }

          if(SFXManager.stoneCount >= 50){
                EarnAchievment("Slime mole em pedra dura...");
          }

          //conquistas sobre slimes destruidos
         // if(GameObject.){
           //    EarnAchievment("Slime de Turquesa");
         // }
          if(Board.tagRed >= 100){
               EarnAchievment("Slime de Rubi");
          }
          if(Board.tagYellow >= 100){
               EarnAchievment("Slime de Topázio");
          }
          if(Board.tagWhite >= 100){
               EarnAchievment("Slime de Pérola");
          }
          if(Board.tagPurple >= 100){
               EarnAchievment("Slime de Ametista");
          }
          if(Board.tagGreen >= 100){
               EarnAchievment("Slime de Esmeralda");
          }

          //teste com metodo
          
          
         
     }

     public void EarnAchievment(string title){
          if (achievments[title].EarnAchievment()){
               //funciona por favor! Pelo amor de Deus
            
               GameObject achievment = (GameObject)Instantiate(visualAchievment);

               SetAchievmentInfo("EarnCanvas", achievment, title);

               StartCoroutine(FadeAchievment(achievment));
          }
     }

     public void CreateAchievment(string parent, string title, string description, int spriteIndex, int progress, string[] dependencies = null){
        
        GameObject achievment = (GameObject)Instantiate(achievmentPrefab);

        Achievments newAchievment = new Achievments(title, description, spriteIndex, achievment, progress);

        achievments.Add(title, newAchievment);

        SetAchievmentInfo(parent, achievment, title, progress);

          if(dependencies != null){
               foreach (string achievmentTitle in dependencies){
                    Achievments dependency = achievments[achievmentTitle];
                    dependency.Child = title;
                    newAchievment.AddDependency(dependency);
               }
          }

     }

     public void SetAchievmentInfo(string parent, GameObject achievment, string title, int progression = 0){

          achievment.transform.SetParent(GameObject.Find(parent).transform);
          achievment.transform.localScale = new Vector3(1, 1, 1);

          string progress = progression > 0 ? " " + PlayerPrefs.GetInt("Progression" + title) + "/" +progression.ToString() : string.Empty;

          achievment.transform.GetChild(0).GetComponent<Text>().text = title + progress;
          achievment.transform.GetChild(1).GetComponent<Text>().text = achievments[title].Description;
          achievment.transform.GetChild(2).GetComponent<Image>().sprite = sprites[achievments[title].SpriteIndex];

     }

     private IEnumerator FadeAchievment(GameObject achievment){
          CanvasGroup canvasGroup = achievment.GetComponent<CanvasGroup>();

          float rate = 1.0f / fadeTime;

          int startAlpha = 0;
          int endAlpha = 1;

          

          for (int i =0; i < 2; i++){
               
               float progress = 0.0f;

               while (progress < 1.0){
                    canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, progress);
                    progress += rate * Time.deltaTime;
                    yield return null;
               }
               yield return new WaitForSeconds(2);
               startAlpha = 1;
               endAlpha = 0;
          }

          Destroy(achievment);
          
     }
}
