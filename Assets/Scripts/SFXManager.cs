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

        bombCount++;
        Debug.Log("Bombas explodidas " + bombCount);
        
        explodeSound.Play();
    }

     public void PlayStoneBreak(){
        stoneSound.Stop();

        stoneSound.pitch = Random.Range(.8f, 1.2f);

        stoneCount++;
        Debug.Log("Pedras explodidas " + stoneCount);
        
        stoneSound.Play();
    }

    public void PlayRoundOver(){
        roundOverSound.Play();
    }
}
