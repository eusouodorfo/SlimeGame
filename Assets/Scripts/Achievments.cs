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

        this.Name = name;
        this.Description = description;
        this.Unlocked = false;
        this.SpriteIndex = spriteIndex;
        this.achievmentRef = achievmentRef;

    }

    public string Name { get => name; set => name = value; }
    public string Description { get => description; set => description = value; }
    public bool Unlocked { get => unlocked; set => unlocked = value; }
    public int SpriteIndex { get => spriteIndex; set => spriteIndex = value; }

    public bool EarnAchievment(){
        if(!Unlocked){
            Unlocked = true;
            return true;
        }
        return false; 
    }

    /* void Start(){
        Achievments myAchievment = new Achievments();
    } */
}
