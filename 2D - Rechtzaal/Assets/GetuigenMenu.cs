using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetuigenMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject GetuigenMenuUI;
    public GameObject GetuigenStation;
    public GameObject DialogueUI;
    public GameObject ButtonUI;

    
    // Getuigen visual
    public void ListOn()
    {
        GetuigenMenuUI.SetActive(true);
    }
    public void ListOff()
    {
        GetuigenMenuUI.SetActive(false);
    }
    
    // Getuigen praatwolkje
    public void GetuigenOn()
    {
        GetuigenStation.SetActive(true);
    }
    public void GetuigenOff()
    {
        GetuigenStation.SetActive(false);
    }

    //  dialogue veld en slider
    public void DialogueOn()
    {
        DialogueUI.SetActive(true);
    }
    public void DialogueOff()
    {
        DialogueUI.SetActive(false);
    }

    // 3 knoppen onderin
    public void ButtonOn()
    {
        ButtonUI.SetActive(true);
    }
    public void ButtonOff()
    {
        ButtonUI.SetActive(false);
    }



}
