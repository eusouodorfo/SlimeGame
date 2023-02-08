using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    public float roundTime = 60f;
    private UIManager uiMan;

    private bool endingRound = false;
    private Board board;
    public int currentScore;
    public float displayScore;
    public float scoreSpeed;

    public int scoreTarget1, scoreTarget2, scoreTarget3;


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

        displayScore = Mathf.Lerp(displayScore, currentScore, scoreSpeed * Time.deltaTime);
        uiMan.scoreText.text = displayScore.ToString("0");
    }

    private void WinCheck(){
        uiMan.roundOverScreen.SetActive(true);
        uiMan.winScore.text = currentScore.ToString();

        if(currentScore >= scoreTarget3){
            uiMan.winText.text = "Parabéns! Você alcançou 3 estrelas!";
            uiMan.winStars3.SetActive(true);

            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_Star1", 1);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_Star2", 1);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_Star3", 1);

        }else if(currentScore >= scoreTarget2){
            uiMan.winText.text = "Parabéns! Você alcançou 2 estrelas!";
            uiMan.winStars2.SetActive(true);

            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_Star1", 1);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_Star2", 1);

        }else if(currentScore >= scoreTarget1){
            uiMan.winText.text = "Parabéns! Você alcançou 1 estrelas!";
            uiMan.winStars1.SetActive(true);

            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_Star1", 1);
            
        }else{
            uiMan.winText.text = "Oh não! Nenhuma estrela! Tente novamente!";
        }

        SFXManager.instance.PlayRoundOver();

    }
}
