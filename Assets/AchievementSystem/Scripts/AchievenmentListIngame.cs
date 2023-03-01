﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Add list of achievements to screen
/// </summary>
public class AchievenmentListIngame : MonoBehaviour
{
    [HideInInspector] public GameObject scrollContent;
    [HideInInspector] public GameObject prefab;
    [HideInInspector] public GameObject Menu;
    [HideInInspector] public Dropdown Filter;
    public TextMeshProUGUI CountText;
    public TextMeshProUGUI CompleteText;
    [HideInInspector] public Scrollbar Scrollbar;

    private bool MenuOpen = false;
    [Tooltip("Key used to open UI menu. Set to \"None\" to prevent menu from opening with any key press")]
    public KeyCode OpenMenuKey; //Key to open in-game menu

    /// <summary>
    /// Adds all achievements to the UI based on a filter
    /// </summary>
    /// <param name="Filter">Filter to use (All, Achieved or Unachieved)</param>
    private void AddAchievements(string Filter)
    {  
        foreach (Transform child in scrollContent.transform)
        {
            Destroy(child.gameObject);
        }
        AchievementManager AM = AchievementManager.instance;
        int AchievedCount = AM.GetAchievedCount();

        CountText.text = "" + AchievedCount + " / " + AM.States.Count;
        CompleteText.text = "Completo (" + AM.GetAchievedPercentage() + "%)";

        for (int i = 0; i < AM.AchievementList.Count; i ++)
        {
            //todos era All, Desbloqueado era Achieved e Unachieved ficou bloqueados, Complete -> Completo
            if((Filter.Equals("All")) || (Filter.Equals("Achieved") && AM.States[i].Achieved) || (Filter.Equals("Unachieved") && !AM.States[i].Achieved))
            {
                AddAchievementToUI(AM.AchievementList[i], AM.States[i]);
            }
        }
        Scrollbar.value = 1;
    }

    public void AddAchievementToUI(AchievementInfromation Achievement, AchievementState State)
    {
        UIAchievement UIAchievement = Instantiate(prefab, new Vector3(0f, 0f, 0f), Quaternion.identity).GetComponent<UIAchievement>();
        UIAchievement.Set(Achievement, State);
        UIAchievement.transform.SetParent(scrollContent.transform);
    }
    /// <summary>
    /// Filter out a set of locked or unlocked achievements
    /// </summary>
    public void ChangeFilter ()
    {
        AddAchievements(Filter.options[Filter.value].text);
    }

    /// <summary>
    /// Closes the UI window.
    /// </summary>
    public void CloseWindow()
    {
        MenuOpen = false;
        Menu.SetActive(MenuOpen);
    }
    /// <summary>
    /// Opens the UI window.
    /// </summary>
    public void OpenWindow()
    {
        MenuOpen = true;
        Menu.SetActive(MenuOpen);
        AddAchievements("All");
    }
    /// <summary>
    /// Toggles the state of the UI window open or closed
    /// </summary>
    public void ToggleWindow()
    {
        if (MenuOpen){
            CloseWindow();
        }
        else{
            OpenWindow();
        }
    }
 
    private void Update()
    {
        if(Input.GetKeyDown(OpenMenuKey))
        {
            ToggleWindow();
        }
    }

    
}