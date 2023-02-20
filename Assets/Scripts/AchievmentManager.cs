using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievmentManager : MonoBehaviour
{
   public GameObject achievmentPrefab;

   public Sprite[] sprites;

   void Start(){
        CreateAchievment("General", "Titulo Teste", "Descricao teste", 0);
   }

   public void CreateAchievment(string category, string title, string description, int  spriteIndex){
    GameObject achievment = (GameObject) Instantiate(achievmentPrefab);

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
