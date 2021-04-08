using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleSlider battleScore; // hiermee call ik het script Battlelsider in, noem het battlescore, kan evt vaker doen onder andere naam

    public BattleState state;

    int A3;

    void Start()
    {

        state = BattleState.START; // verander gamestate naar begin
        StartCoroutine(SetupBattle()); // functie Playerturn uitoefenen, Startcoroutine voor delay

    }
      
    IEnumerator SetupBattle() // IEnumerator is voor de delay, coroutine
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = "You are playing against " + enemyUnit.unitName + "\r\n" + enemyUnit.unitName + " has level: " + enemyUnit.unitLevel;

        battleScore.SetSlider(playerUnit); // Dit is voor de void uit te oefenen

        yield return new WaitForSeconds(5f); //coroutine, 2 seconde delay 

        state = BattleState.PLAYERTURN; // verander state naar volgende
        PlayerTurn(); // functie PlayerTurn uitoefenen
    }

    IEnumerator PlayerAttack1()
    {   // Aanval 1

        dialogueText.text = playerUnit.unitName + " chooses Getuige oproepen";
        yield return new WaitForSeconds(2f);

        int isDead = playerUnit.TakeDamage(playerUnit.damage1); // Start de TakeDamage funcite (aantal damage komt van player)
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "The Getuige oproepen is super effective";

        yield return new WaitForSeconds(3f);

        if (isDead == 2)
        {
            state = BattleState.WON;
            EndBattle();
        }else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerAttack2()
    {   // Aanval 2

        dialogueText.text = playerUnit.unitName + " chooses Alibi Smijten";
        yield return new WaitForSeconds(2f);

        int isDead = playerUnit.TakeDamage(playerUnit.damage2); // Start de TakeDamage funcite (aantal damage komt van player)
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "The Alibi Smijten is effective";

        yield return new WaitForSeconds(3f);

        if (isDead == 2)
        {
            state = BattleState.WON;
            EndBattle();
        } else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerAttack3()
    {   // Aanval 3
        if (A3 == 0)
        {
            dialogueText.text = playerUnit.unitName + " chooses It wasn't me";
            yield return new WaitForSeconds(2f);

            int isDead = playerUnit.TakeDamage(playerUnit.damage31); // Start de TakeDamage funcite (aantal damage komt van player)
            battleScore.SetScore(playerUnit.score);
            dialogueText.text = "It wasn't me is not effective";
            A3 = 1;
            yield return new WaitForSeconds(3f);
            
            if (isDead == 2)
            {
                state = BattleState.WON;
                EndBattle();
            }
            else
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            }
        }
        else
        {
            dialogueText.text = playerUnit.unitName + " chooses It wasn't me again!";
            yield return new WaitForSeconds(2f);

            int isDead = playerUnit.TakeDamage(playerUnit.damage32); // Start de TakeDamage funcite (aantal damage komt van player)
            battleScore.SetScore(playerUnit.score);
            dialogueText.text = "It wasn't me is tering effective";
            yield return new WaitForSeconds(3f);
           
            if (isDead == 2)
            {
                state = BattleState.WON;
                EndBattle();
            }
            else
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            }
        }
        
    }
    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + " attacks!"; // Aangeven van aanval
        yield return new WaitForSeconds(5f);

        dialogueText.text = enemyUnit.unitName + " chooses DNA Onderzoek";
        yield return new WaitForSeconds(2f);

        dialogueText.text =  "DNA Onderzoek is tering effective";
        int isDead = playerUnit.TakeDamage(enemyUnit.damage1); // damage de player
        battleScore.SetScore(playerUnit.score); //playerHUD.SetHP, slider verzetten
        yield return new WaitForSeconds(3f);

        if (isDead == 1)  // check if dead or not and change state
        {
            state = BattleState.LOST;
            EndBattle();
        } else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }

    }

    void EndBattle()
    {
        if(state == BattleState.WON)
        {
            dialogueText.text = "Je hebt Gewonnen";
        } else if (state == BattleState.LOST)
        {
            dialogueText.text = enemyUnit.unitName + " has won" + "\r\n" + "You hef lost";
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "Yeah Lets go" + "\r\n" + "Welke actie wil je doen?";
    }

    public void OnAttackButton1() // new function to trigger action when attack is pressed.
    {
        if (state != BattleState.PLAYERTURN) // Checkt of speler aan de beurt is
            return;

       StartCoroutine(PlayerAttack1()); // pause during attack
    }

    public void OnAttackButton2() // new function to trigger action when attack is pressed.
    {
        if (state != BattleState.PLAYERTURN) // Checkt of speler aan de beurt is
            return;
        StartCoroutine(PlayerAttack2()); // pause during attack
    }

    public void OnAttackButton3() // new function to trigger action when attack is pressed.
    {
        if (state != BattleState.PLAYERTURN) // Checkt of speler aan de beurt is
            return;
        StartCoroutine(PlayerAttack3()); // pause during attack
    }
}
