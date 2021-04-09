using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public string unitName;
    public int unitLevel;
    public int timePoints;
    
    public int score;
    public int maxScore;
    public int damage1;
    public int damage2;
    public int damage31;
    public int damage32;

    public int TakeDamage(int dmg) // deze neemt dus player damage in als dmg)
    {
        score += dmg;

        if (score <= 0)
            return 1;
        else if (score >= 100)
        {
            return 2;
        }else
            return 0; 
        
       /* if (timePoints <= 0)
        {
            return 3;
        }
        */
    }

   /* void MinusTime (int tmp)
    {
        timePoints -= tmp;
    }
    */

}
