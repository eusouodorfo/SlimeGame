using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    
    public static SFXManager instance;

    [SerializeField] public static int bombCount;
    [SerializeField] public static int stoneCount;

    private void Awake(){
        instance = this;
    }

    public AudioSource gemSound, explodeSound, stoneSound, roundOverSound;
    

    public void PlayGemBreak(){
        gemSound.Stop();

        gemSound.pitch = Random.Range(.8f, 1.2f);

        gemSound.Play();
    }

     public void PlayExplode(){
        explodeSound.Stop();

        explodeSound.pitch = Random.Range(.8f, 1.2f);

        AchievementManager.instance.AddAchievementProgress("Bomber Man", 1);
        
        explodeSound.Play();
    }

     public void PlayStoneBreak(){
        stoneSound.Stop();

        stoneSound.pitch = Random.Range(.8f, 1.2f);

        AchievementManager.instance.AddAchievementProgress("Slime mole em pedra dura...", 1);
        
        stoneSound.Play();
    }

    public void PlayRoundOver(){
        roundOverSound.Play();
    }
}
