using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    public int width;
    public int height;

    public GameObject bgTilePrefab;
    
    void Start()
    {
        Setup();
    }

    private void Setup(){
        for(int x=0; x < width; x++){
            for(int y=0; y < height; y++){
                Vector2 pos = new Vector2(x, y);
                GameObject bgTile = Instantiate(bgTilePrefab, pos, Quaternion.identity);
                bgTile.transform.parent = transform;
                bgTile.name = "Bg Tile - " + x + "," + y;
            }
        }
    }
}
