using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievments {
    
    private string name;

    public string Name{
        get { return name;}
        set { name = value;}
    }


    private string description;

    public string Description{
        get { return description;}
        set { description = value;}
    }

    private bool unlocked;

    public bool Unlocked{
        get { return unlocked;}
        set { unlocked = value;}
    }

    private int spriteIndex;

    public int SpriteIndex{
        get { return spriteIndex;}
        set { spriteIndex = value;}
    }

    private GameObject achievmentRef;

    private List<Achievments> dependencies = new List<Achievments>();

    private string child;

    public string Child{
        get { return child;}
        set { child = value;}
    }


    public Achievments(string name, string description, int spriteIndex, GameObject achievmentRef){

        this.Name = name;
        this.Description = description;
        this.Unlocked = false;
        this.SpriteIndex = spriteIndex;
        this.achievmentRef = achievmentRef;

        LoadAchievment();

    }

    public void AddDependency(Achievments dependency){
        dependencies.Add(dependency);
    }


    public bool EarnAchievment(){
        if(!unlocked && !dependencies.Exists(x => x.unlocked == false)){
            achievmentRef.GetComponent<Image>().sprite = AchievmentManager.Instance.unlockedSprite;
            SaveAchievment(true);

            if (child != null){
                AchievmentManager.Instance.EarnAchievment(child);
            }

            return true;
        }
        return false; 
    }

    public void SaveAchievment(bool value){
        unlocked = value;
        PlayerPrefs.SetInt(name, value ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void LoadAchievment(){
        unlocked = PlayerPrefs.GetInt(name) == 1 ? true : false;
        if(unlocked){
            achievmentRef.GetComponent<Image>().sprite = AchievmentManager.Instance.unlockedSprite;
        }
        
    }

     /*void Start(){
        Achievments myAchievment = new Achievments();
    } */
}
