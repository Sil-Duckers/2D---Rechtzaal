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
    public GameObject Bewijsstuk1;
    public GameObject Bewijsstuk2;
    public GameObject Bewijsstuk3;
    public GameObject Bewijsstuk4;



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

    public void BS1On()
    {
        Bewijsstuk1.SetActive(true);
    }
    public void BS1Off()
    {
        Bewijsstuk1.SetActive(false);
    }

    public void BS2On()
    {
        Bewijsstuk2.SetActive(true);
    }
    public void BS2Off()
    {
        Bewijsstuk2.SetActive(false);
    }

    public void BS3On()
    {
        Bewijsstuk3.SetActive(true);
    }
    public void BS3Off()
    {
        Bewijsstuk3.SetActive(false);
    }

    public void BS4On()
    {
        Bewijsstuk4.SetActive(true);
    }
    public void BS4Off()
    {
        Bewijsstuk4.SetActive(false);
    }



}
