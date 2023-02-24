using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MonoBehaviour
{
    public string mainMenu = "Main_Menu";
    public string LevelSelect = "LevelSelect";

    public void GoToMainMenu(){
        SceneManager.LoadScene(mainMenu);
    }

    public void GoToLevelSelectMenu(){
        SceneManager.LoadScene(LevelSelect);
    }


}
