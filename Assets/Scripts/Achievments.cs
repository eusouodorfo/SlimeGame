using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievments {
    
    private string name;

    private string description;

    private bool unlocked;

    private int spriteIndex;

    private GameObject achievmentRef;

    public Achievments(string name, string description, int spriteIndex, GameObject achievmentRef){

        this.name = name;
        this.description = description;
        this.unlocked = false;
        this.spriteIndex = spriteIndex;
        this.achievmentRef = achievmentRef;

    }

    public bool EarnAchievment(){
        if(!unlocked){
            unlocked = true;
            return true;
        }
        return false; 
    }

    /* void Start(){
        Achievments myAchievment = new Achievments();
    } */
}
