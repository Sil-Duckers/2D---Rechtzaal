using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleSlider : MonoBehaviour
{

    public Slider ScoreSlider;
    public Text SliderText;

    public void SetSlider(Unit unit)
    {
        // SliderText.text = "Als je dit leest werkt het" + unit.unitName; // Test 


        ScoreSlider.maxValue = unit.maxScore; // hiermee hoop ik de slider interactief te maken. Ik weet niet of maxValue live updatebaar is
        ScoreSlider.value = unit.score; // als je dus de score van de ene tegen beide scores hebt zou je mooi een verhouding krijgen
    }

    public void SetScore(int Pscore)
    {
        ScoreSlider.value = Pscore;
    }
   
}
