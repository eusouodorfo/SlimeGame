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

          //TEM QUE REMOVER DEPOIS!
           

          CreateAchievment("General", "1-5", "Consiga 3 estrelas: 1-5", 0);
          CreateAchievment("General", "6-10", "Consiga 3 estrelas: 6-10", 0);
          CreateAchievment("General", "11-15", "Consiga 3 estrelas: 11-15", 0);
          CreateAchievment("General", "16-20", "Consiga 3 estrelas: 16-20", 0);
          CreateAchievment("General", "21-25", "Consiga 3 estrelas: 21-25", 0);
          CreateAchievment("General", "26-30", "Consiga 3 estrelas: 26-30", 0);
          CreateAchievment("General", "31", "Consegiu 3 estrelas na fase 31", 0);
          
          CreateAchievment("General", "Estrelato", "Consiga 3 estrelas em todas as 31 fases", 0, new string[]
          {"1-5", "6-10", "11-15", "16-20", "21-25", "26-30", "31"});
          
          CreateAchievment("General", "Red", "Destruiu 100 slimes vermelhos", 0);
          CreateAchievment("General", "Yellow", "Destruiu 100 slimes amarelo", 0);
          CreateAchievment("General", "Blue", "Destruiu 100 slimes azul", 0);
          CreateAchievment("General", "Green", "Destruiu 100 slimes verde", 0);
          CreateAchievment("General", "Purple", "Destruiu 100 slimes roxo", 0);
          CreateAchievment("General", "White", "Destruiu 100 slimes branco", 0);
          CreateAchievment("General", "Rock Baby!", "Destruiu pedras", 0);
          CreateAchievment("General", "Bomber Man", "Explodiu 30 bombas", 0);
          
          CreateAchievment("General", "Platina!", "Fez todas as conquistas", 0, new string[] 
          {"1-5", "6-10", "11-15", "16-20", "21-25", "26-30", "31", "Red", "Yellow", "Blue", "Green", "Purple", "White", "Rock Baby!", "Bomber Man"});
      
     }

     void Update(){
          if(Input.GetKeyDown(KeyCode.W)){
               EarnAchievment("Teste W");
          }
          if(Input.GetKeyDown(KeyCode.S)){
               EarnAchievment("Teste S");
          }
     }

     public void EarnAchievment(string title){
          if (achievments[title].EarnAchievment()){
            //funciona por favor!
            
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

        Achievments newAchievment = new Achievments(name, description, spriteIndex, achievment);

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
