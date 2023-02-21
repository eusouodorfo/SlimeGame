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
           

          CreateAchievment("General", "Teste W", "Descricao teste W", 0);
          CreateAchievment("General", "Teste S", "Descricao teste W", 0);
          CreateAchievment("General", "Teste todas teclas", "Descricao teste W", 0, new string[] {"Teste W", "Teste S"});
      
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

               StartCoroutine(HideAchievment(achievment));
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
}
