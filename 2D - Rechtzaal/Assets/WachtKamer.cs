using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WachtKamer : MonoBehaviour
{
    int Time;
    int Min = 10;
    int Max = 20;

    public GameObject scherm1;
    public GameObject scherm2;
    public GameObject scherm3;
    public GameObject scherm4;
    public GameObject scherm5;
    public Text text; 



    void Start()
    {
        
        Time = Random.Range(Min, Max);
    
    }

    public void Knop0()
    {
        scherm1.SetActive(false);
        scherm2.SetActive(true);
        
    }

    public void Knop1()
    {
        scherm2.SetActive(false);
        scherm3.SetActive(true);
        
    }

    public void Knop2()
    {
        scherm2.SetActive(false);
        scherm4.SetActive(true);
        
    }

    public void StartGame()
    {
        scherm2.SetActive(false); 
        scherm3.SetActive(false);
        scherm4.SetActive(false);
        scherm5.SetActive(true);
        StartCoroutine(Schermen());
    }

    public void Terug()
    {
       
        scherm3.SetActive(false);
        scherm4.SetActive(false);
        scherm2.SetActive(true);
        StartCoroutine(Schermen());
    }


    IEnumerator Schermen()
    {
        
        for (int i = 0; i < Time; i++)
        {
            text.text = "Wachten op tegenstander"  + "\r\n" + "Tijd: " + i + "s";
        yield return new WaitForSeconds(1f);
    }

        text.text = "Tegenstander gevonden!" + "\r\n" + "Spel laden:";
            

        for (int i = 5; i > -1; i--)
        {
            text.text = "Tegenstander gevonden!"+ "\r\n" + "Spel laden: " + i;
            yield return new WaitForSeconds(1f);
        }
        SceneManager.LoadScene("Start Pleidooi");
    }
}
