using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{

    //[HideInInspector]
    public Vector2Int posIndex;
    //[HideInInspector]
    public Board board;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void SetupGem(Vector2Int pos, Board theBoard){
        posIndex = pos;
        board = theBoard;
    }
}
