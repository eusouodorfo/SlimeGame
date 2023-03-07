using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GambiarraMaster : MonoBehaviour
{
    
    public GameObject settings;

    void Awake()
    {
        settings.SetActive(true); 
        settings.GetComponent<Canvas>().enabled = false;
        
    }

    void OnBecameInvisible()
        {
            enabled = true;
        }

    void Start(){
        
        StartCoroutine(Contador());
    }

    IEnumerator Contador(){
        yield return new WaitForSeconds(0.1f);
        settings.SetActive(false);
        settings.GetComponent<Canvas>().enabled = true;
    }
}
