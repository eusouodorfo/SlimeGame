using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public float roundTime = 60f;
    private UIManager uiMan;

    private bool endingRound = false;
    private Board board;


    void Awake()
    {
        uiMan = FindObjectOfType<UIManager>();
        board = FindObjectOfType<Board>();
    }


    void Update()
    {
        if(roundTime > 0){
            roundTime -= Time.deltaTime;

            if(roundTime <= 0){
                roundTime = 0;
                endingRound = true;
            }
        }

        if(endingRound && board.currentState == Board.BoardState.move){
            WinCheck();
            endingRound = false;

        }
        uiMan.timeText.text = roundTime.ToString("0.0") + "s";
    }

    private void WinCheck(){
        uiMan.roundOverScreen.SetActive(true);
    }
}
