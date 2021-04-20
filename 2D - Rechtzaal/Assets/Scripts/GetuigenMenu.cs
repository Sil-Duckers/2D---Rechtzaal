using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetuigenMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject GetuigenMenuUI;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void resume()
    {
        GetuigenMenuUI.SetActive(false);
    }

    public void pause()
    {
        GetuigenMenuUI.SetActive(true);
    }

}
