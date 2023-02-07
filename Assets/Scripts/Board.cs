using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    public int width;
    public int height;

    public GameObject bgTilePrefab;

    public Gem[] gems;
    public Gem[,] allGems;

    public float gemSpeed;

    [HideInInspector] 
    public MatchFinder matchFind;

    private void Awake(){
          matchFind = FindObjectOfType<MatchFinder>();
    }
    
    void Start()
    {
        allGems = new Gem[width, height];
        Setup();  
    }

    private void Update(){
        matchFind.FindAllMatches();
    }


    private void Setup(){
        for(int x=0; x < width; x++){
            for(int y=0; y < height; y++){
                Vector2 pos = new Vector2(x, y);
                GameObject bgTile = Instantiate(bgTilePrefab, pos, Quaternion.identity);
                bgTile.transform.parent = transform;
                bgTile.name = "Bg Tile - " + x + "," + y;

                int gemToUse = Random.Range(0, gems.Length);

                int interations = 0;
                while(MatchesAt(new Vector2Int(x, y), gems[gemToUse]) && interations < 100){
                    gemToUse = Random.Range(0, gems.Length);
                    interations++;
                }

                SpawnGem(new Vector2Int(x, y), gems[gemToUse]);

            }
        }
    }

    private void SpawnGem(Vector2Int pos, Gem gemToSpawn){
        Gem gem = Instantiate(gemToSpawn, new Vector3(pos.x, pos.y, 0f), Quaternion.identity);
        gem.transform.parent = this.transform;
        gem.name = "Gem - " + pos.x + "," + pos.y; 
        allGems[pos.x, pos.y] = gem;

        gem.SetupGem(pos, this);
    }

    bool MatchesAt(Vector2Int posToCheck, Gem gemToCheck){
        if(posToCheck.x > 1){
            if(allGems[posToCheck.x - 1, posToCheck.y].type == gemToCheck.type && allGems[posToCheck.x - 2, posToCheck.y].type == gemToCheck.type){
                return true;
            }
        }

         if(posToCheck.y > 1){
            if(allGems[posToCheck.x, posToCheck.y - 1].type == gemToCheck.type && allGems[posToCheck.x, posToCheck.y - 2].type == gemToCheck.type){
                return true;
            }
        }

        return false;
    }

    private void DestroyMatchedGemAt(Vector2Int pos){
        if(allGems[pos.x, pos.y] != null){
            if(allGems[pos.x, pos.y].isMatched){
                Destroy(allGems[pos.x, pos.y].gameObject);
                allGems[pos.x, pos.y] = null;
            }
        }

    }

    public void DestroyMatches(){
        for(int i = 0; i < matchFind.currentMatches.Count; i++){
            if(matchFind.currentMatches[i] != null){
                DestroyMatchedGemAt(matchFind.currentMatches[i].posIndex);
            }
        }
          StartCoroutine(DecreaseRowCo());
    }

    private IEnumerator DecreaseRowCo(){
        yield return new WaitForSeconds(.2f);

        int nullCounter = 0;

        for(int x =0; x < width; x++){
            for(int y = 0; y < height; y++){
                if(allGems[x,y] == null){
                    nullCounter++;
                }else if(nullCounter > 0){
                    allGems[x, y].posIndex.y -= nullCounter;
                    allGems[x, y - nullCounter] = allGems[x, y];
                    allGems[x, y] = null;
                }
            }

            nullCounter = 0;
        }
    }
}
