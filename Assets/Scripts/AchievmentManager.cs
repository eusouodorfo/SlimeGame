using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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

     void Start(){

          CreateAchievment("General", "Primeiros passos fofos", "Consiga 3 estrelas: 1-5", 10);
          CreateAchievment("General", "Pegando o jeito", "Consiga 3 estrelas: 6-10", 14);
          CreateAchievment("General", "Talvez isso seja viciante", "Consiga 3 estrelas: 11-15", 13);
          CreateAchievment("General", "Não é uma fase mãe!", "Consiga 3 estrelas: 16-20", 15);
          CreateAchievment("General", "Graduado em apertar slimes", "Consiga 3 estrelas: 21-25", 12);
          CreateAchievment("General", "Me chame de Dr Slime", "Consiga 3 estrelas: 26-30", 11);
          CreateAchievment("General", "De repente 31", "Consegiu 3 estrelas na fase 31", 0);
           
          CreateAchievment("General", "Estrelato", "3 estrelas em todas as fases", 16, new string[] 
          {"Primeiros passos fofos", "Pegando o jeito", "Talvez isso seja viciante", "Não é uma fase mãe!",
          "Graduado em apertar slimes", "Me chame de Dr Slime", "De repente 31"});

          CreateAchievment("General", "Slime de Rubi", "Destruiu 100 slimes vermelhos", 6);
          CreateAchievment("General", "Slime de Topázio", "Destruiu 100 slimes amarelo", 1);
          CreateAchievment("General", "Slime de Turquesa", "Destruiu 100 slimes azul", 3);
          CreateAchievment("General", "Slime de Pérola", "Destruiu 100 slimes branco", 2);
          CreateAchievment("General", "Slime de Ametista", "Destruiu 100 slimes roxo", 5);
          CreateAchievment("General", "Slime de Esmeralda", "Destruiu 100 slimes verde", 4);
          CreateAchievment("General", "Slime mole em pedra dura...", "Destruiu pedras", 8);
          CreateAchievment("General", "Bomber Man", "Explodiu 30 bombas", 7);

          CreateAchievment("General", "Platina", "Platina", 9, new string[]{"Estrelato", "Slime de Rubi",
          "Slime de Topázio", "Slime de Turquesa", "Slime de Pérola", "Slime de Ametista", "Slime de Esmeralda",
          "Slime mole em pedra dura...", "Bomber Man"});
      
      
     }

     void Update(){

          //debug
          if(Input.GetKeyDown(KeyCode.W)){
               EarnAchievment("Primeiros passos fofos");
          }
          if(Input.GetKeyDown(KeyCode.M)){
               EarnAchievment("Estrelato");
          }
          if(Input.GetKeyDown(KeyCode.Q)){
               EarnAchievment("Pegando o jeito");
          }
          if(Input.GetKeyDown(KeyCode.E)){
               EarnAchievment("Talvez isso seja viciante");
          }
          if(Input.GetKeyDown(KeyCode.R)){
               EarnAchievment("Não é uma fase mãe!");
          }
          if(Input.GetKeyDown(KeyCode.T)){
               EarnAchievment("Graduado em apertar slimes");
          }
          if(Input.GetKeyDown(KeyCode.Y)){
               EarnAchievment("Me chame de Dr Slime");
          }
          if(Input.GetKeyDown(KeyCode.U)){
               EarnAchievment("De repente 31");
          }
          if(Input.GetKeyDown(KeyCode.I)){
               EarnAchievment("Slime de Rubi");
          }
          if(Input.GetKeyDown(KeyCode.O)){
               EarnAchievment("Slime de Topázio");
          }
          if(Input.GetKeyDown(KeyCode.P)){
               EarnAchievment("Slime de Turquesa");
          }
          if(Input.GetKeyDown(KeyCode.A)){
               EarnAchievment("Slime de Pérola");
          }
          if(Input.GetKeyDown(KeyCode.S)){
               EarnAchievment("Slime de Ametista");
          }
          if(Input.GetKeyDown(KeyCode.D)){
               EarnAchievment("Slime de Esmeralda");
          }
          if(Input.GetKeyDown(KeyCode.F)){
               EarnAchievment("Slime mole em pedra dura...");
          }
          if(Input.GetKeyDown(KeyCode.G)){
               EarnAchievment("Bomber Man");
          }


         
     }

     public void EarnAchievment(string title){
          if (achievments[title].EarnAchievment()){
               //funciona por favor! Pelo amor de Deus
            
               GameObject achievment = (GameObject)Instantiate(visualAchievment);

               SetAchievmentInfo("EarnCanvas", achievment, title);

               StartCoroutine(FadeAchievment(achievment));
          }
     }

     public IEnumerator HideAchievment(GameObject achievment){
          yield return new WaitForSeconds(3);
          Destroy(achievment);
     }

     public void CreateAchievment(string parent, string title, string description, int spriteIndex, string[] dependencies = null){
        
        GameObject achievment = (GameObject)Instantiate(achievmentPrefab);

        Achievments newAchievment = new Achievments(title, description, spriteIndex, achievment);

        achievments.Add(title, newAchievment);

        SetAchievmentInfo(parent, achievment, title);

          if(dependencies != null){
               foreach (string achievmentTitle in dependencies){
                    Achievments dependency = achievments[achievmentTitle];
                    dependency.Child = title;
                    newAchievment.AddDependency(dependency);
               }
          }

     }

     public void SetAchievmentInfo(string parent, GameObject achievment, string title){

        achievment.transform.SetParent(GameObject.Find(parent).transform);
        achievment.transform.localScale = new Vector3(1, 1, 1);
        achievment.transform.GetChild(0).GetComponent<Text>().text = title;
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
