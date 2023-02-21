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

        CreateAchievment("General", "Teste W", "Descricao teste W", 0);
      

        /*foreach (GameObject achievmentList in GameObject.FindGameObjectsWithTag("AchievmentList")){
            achievmentList.SetActive(false);
        } */
     }

     void Update(){
          if(Input.GetKeyDown(KeyCode.W)){
               EarnAchievment("Press W");
          }
     }

     public void EarnAchievment(string title){
          if (achievments[title].EarnAchievment()){
            //funciona por favor!
               SetAchievmentInfo("EarnCanvas", achievment, title);

               GameObject achievment = (GameObject)Instantiate(visualAchievment);

               StartCoroutine(HideAchievment(achievment));
          }
     }

     public IEnumerator HideAchievment(GameObject achievment){
          yield return new WaitForSeconds(3);
          Destroy(achievment);
     }

     public void CreateAchievment(string parent, string title, string description, int  spriteIndex){
        
        GameObject achievment = (GameObject) Instantiate(achievmentPrefab);

        Achievments newAchievment = new Achievments(name, description, spriteIndex, achievment);

        achievments.Add(title, newAchievment);

        SetAchievmentInfo(parent, achievment, title);

     }

     public void SetAchievmentInfo(string parent, GameObject achievment, string title){
        achievment.transform.SetParent(GameObject.Find(parent).transform);
        achievment.transform.localScale = new Vector3(1, 1, 1);
        achievment.transform.GetChild(0).GetComponent<Text>().text = title;
        achievment.transform.GetChild(1).GetComponent<Text>().text = achievments[title].Description;
        achievment.transform.GetChild(2).GetComponent<Image>().sprite = sprites[achievments[title].SpriteIndex];

     }
}
