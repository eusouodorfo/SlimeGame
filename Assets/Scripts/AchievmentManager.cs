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

   void Start(){
        CreateAchievment("General", "Titulo Teste", "Descricao teste", 0);
        CreateAchievment("General", "Titulo Teste", "Descricao teste", 0);
        CreateAchievment("General", "Titulo Teste", "Descricao teste", 0);
        CreateAchievment("General", "Titulo Teste", "Descricao teste", 0);
        CreateAchievment("General", "Titulo Teste", "Descricao teste", 0);
        CreateAchievment("General", "Titulo Teste", "Descricao teste", 0);

        /*foreach (GameObject achievmentList in GameObject.FindGameObjectsWithTag("AchievmentList")){
            achievmentList.SetActive(false);
        } */
   }

   public void EarnAchievment(){

   }

   public void CreateAchievment(string category, string title, string description, int  spriteIndex){
        
        GameObject achievment = (GameObject) Instantiate(achievmentPrefab);

        Achievments newAchievment = new Achievments(name, description, spriteIndex, achievment);

        achievments.Add(title, newAchievment);

        SetAchievmentInfo(category, achievment, title, description, spriteIndex);

   }

   public void SetAchievmentInfo(string category, GameObject achievment, string title, string description, int spriteIndex){
        achievment.transform.SetParent(GameObject.Find(category).transform);
        achievment.transform.localScale = new Vector3(1, 1, 1);
        achievment.transform.GetChild(0).GetComponent<Text>().text = title;
        achievment.transform.GetChild(1).GetComponent<Text>().text = description;
        achievment.transform.GetChild(2).GetComponent<Image>().sprite = sprites[spriteIndex];

   }
}
