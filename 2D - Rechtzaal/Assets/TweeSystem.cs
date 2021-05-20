using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class TweeSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject GPrefab1; // dit laadt slechts de eerste enemy prefab in de game. Dit moet dus nog 17x
    public GameObject GPrefab2;
    public GameObject GPrefab3;
    public GameObject GPrefab4;
    public GameObject GPrefab5;
    public GameObject GPrefab6;
    public GameObject GPrefab7;
    public GameObject GPrefab8;
    public GameObject GPrefab9;
    public GameObject GPrefab10;
    public GameObject GPrefab11;
    public GameObject GPrefab12;
    public GameObject Scherm;
       

    public Transform playerBattleStation;
    public Transform enemyBattleStation;
    public Transform GetuigenBattleStation;


    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;
    public Text textWolk;

    public Text Button1;
    public Text Button2;
    public Text Button3;
    public Text Button4;


    public BattleSlider battleScore; // hiermee call ik het script Battlelsider in, noem het battlescore, kan evt vaker doen onder andere naam
    public GetuigenMenu UI;
    
    

    public BattleState state;

    int PT;
    int G1;
    int G2 = 0;
    int G3;

    void Start()
    {

        state = BattleState.START; // verander gamestate naar begin
        
         // functie Playerturn uitoefenen, Startcoroutine voor delay
        
    }

    public void KnopScherm()
    {
        Scherm.SetActive(false);
        UI.DialogueOn();
        StartCoroutine(SetupBattle());
    }
    
    IEnumerator SetupBattle() // IEnumerator is voor de delay, coroutine
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = "Welkom bij de tweede zitting in de zaak: De zes van Breda" + "\r\n";
        

        yield return new WaitForSeconds(4f); //coroutine, 5 seconde delay 
        playerUnit.score = Score.HScore;
        battleScore.SetSlider(playerUnit);
        state = BattleState.PLAYERTURN; // verander state naar volgende
        StartCoroutine(PlayerTurn()); // functie PlayerTurn uitoefenen
    }

    IEnumerator PlayerAttack1()
    {   // Aanval 1
        if (PT == 0)
       {
            dialogueText.text = playerUnit.unitName + " wilt graag bewijsstuk 1 (Het Dagboek van Jennifer) inzien.";
            yield return new WaitForSeconds(2f);
            UI.BS1On();
            UI.DialogueOff();
            UI.ButtonOff();
            yield return new WaitForSeconds(14f);
            UI.BS1Off();
            UI.DialogueOn();
            UI.ButtonOn();
            int isDead = playerUnit.TakeDamage(5); // Start de TakeDamage funcite (aantal damage komt van player)
            battleScore.SetScore(playerUnit.score);
            yield return new WaitForSeconds(2f);
            dialogueText.text = "De advocaat van de verdachten mag nu drie getuigen oproepen."; 
            PT = 4;

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
     }
    IEnumerator PlayerAttack2()
    {   // Aanval 2

        if (PT == 0)
        {
            dialogueText.text = playerUnit.unitName + " wilt graag bewijsstuk 2 (Brief Ting) inzien. ";
            yield return new WaitForSeconds(2f);
            UI.BS2On();
            UI.DialogueOff();
            UI.ButtonOff();
            yield return new WaitForSeconds(14f);
            UI.BS2Off();
            UI.DialogueOn();
            UI.ButtonOn();
            int isDead = playerUnit.TakeDamage(-5); // Start de TakeDamage funcite (aantal damage komt van player)
            battleScore.SetScore(playerUnit.score);
            yield return new WaitForSeconds(2f);
            dialogueText.text = "De advocaat van de verdachten mag nu drie getuigen oproepen.";
            PT = 4;

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

    }
    IEnumerator PlayerAttack3()
    {   // Aanval 3
        if (PT == 0)
        {
            dialogueText.text = playerUnit.unitName + " wilt graag bewijsstuk 3 (Reconstructie) inzien.";
            yield return new WaitForSeconds(2f);
            UI.BS3On();
            UI.DialogueOff();
            UI.ButtonOff();
            yield return new WaitForSeconds(14f);
            UI.BS3Off();
            UI.DialogueOn();
            UI.ButtonOn();
            int isDead = playerUnit.TakeDamage(0); // Start de TakeDamage funcite (aantal damage komt van player)
            battleScore.SetScore(playerUnit.score);
            yield return new WaitForSeconds(2f);
            dialogueText.text = "De advocaat van de verdachten mag nu drie getuigen oproepen.";
            PT = 4;

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
    IEnumerator PlayerAttack4()
    {   // Aanval 3
        if (PT == 0)
        {
            dialogueText.text = playerUnit.unitName + " wilt graag bewijsstuk 4 (Relatie Tree) inzien.";
            yield return new WaitForSeconds(2f);
            UI.BS4On();
            UI.DialogueOff();
            UI.ButtonOff();
            yield return new WaitForSeconds(14f);
            UI.BS4Off();
            UI.DialogueOn();
            UI.ButtonOn();
            int isDead = playerUnit.TakeDamage(5); // Start de TakeDamage funcite (aantal damage komt van player)
            battleScore.SetScore(playerUnit.score);
            yield return new WaitForSeconds(2f);
            dialogueText.text = "De advocaat van de verdachten mag nu drie getuigen oproepen.";
            PT = 4;

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
         

            yield return new WaitForSeconds(2f);

            UI.ButtonOff();
            UI.GetuigenOff();
            // Getuigen 1 --------------------------------------------------------------------
            //yield return new WaitForSeconds(10f);
            GameObject GE1 = Instantiate(GPrefab2, GetuigenBattleStation); // Klopt nog niet
            dialogueText.text = playerUnit.unitName + " kiest om Aldo te verhoren"; //hier moet de naam nog bij
            yield return new WaitForSeconds(2f);
            dialogueText.text = "Aldo het woord is aan u"; // idem
            yield return new WaitForSeconds(2f);
            UI.GetuigenOn();
            textWolk.text = "Ik ben onschuldig, ik was uit met Jennifer en haar vriendin."; // hier komt zijn verhaal
            playerUnit.TakeDamage(-5); // Hierbij zeg je dus 10 damage. Dit is makkelijker dan dat gezeik via de prefab.
            battleScore.SetScore(playerUnit.score); // update de slider
            yield return new WaitForSeconds(4f);
            dialogueText.text = "Bedankt Aldo"; // update
            UI.GetuigenOff();
            Destroy(GE1); 

            yield return new WaitForSeconds(2f);


            // Getuigen 2 --------------------------------------------------------------------
            dialogueText.text = "De advocaat van de verdachte mag nu een tweede getuigen oproepen";
            yield return new WaitForSeconds(2f);
            GameObject GE2 = Instantiate(GPrefab11, GetuigenBattleStation); // Klopt nog niet
            dialogueText.text = playerUnit.unitName + " kiest om Linda te verhoren"; //hier moet de naam nog bij
            yield return new WaitForSeconds(2f);
            dialogueText.text = "Linda het woord is aan u"; // idem
            yield return new WaitForSeconds(2f);
            UI.GetuigenOn();
            textWolk.text = "Ik was erbij toen Joyce werd bedreigd met een pistool door Abdoel, maar dit was niet op maandag 5 juli. Het was sowieso op een andere dag. Joyce is wel vaker bedreigd door de jongens. Ik heb het meerdere keren meegemaakt en een keer hadden de jongens zich opgesloten in Joyce’s kamer en toen gingen ze haar spullen kapot maken. Ze gooiden haar ruiten in en schreven het woord stinkdier op de muren. Uiteindelijk is ze maar verhuist. Julia en de jongens hebben altijd ruzie. Ze komt alleen naar ons huis als ze Mandy bezoekt. Ik denk wel dat Julia een oogje heeft op Abdoel, al snap ik niet waarom. Joyce is bij niemand echt geliefd. We hebben ook een keer met de meiden tegen de huisbaas gezegd dat ze soms liegt."; // hier komt zijn verhaal
            playerUnit.TakeDamage(-5); // Hierbij zeg je dus 10 damage. Dit is makkelijker dan dat gezeik via de prefab.
            battleScore.SetScore(playerUnit.score); // update de slider
            yield return new WaitForSeconds(10f);
            dialogueText.text = "Bedankt Linda"; // update
            Destroy(GE2);
            UI.GetuigenOff();
            yield return new WaitForSeconds(2f);

            // Getuigen 3--------------------------------------------------------------------
            dialogueText.text = "De advocaat van de verdachte mag nu de derde getuigen oproepen";
            yield return new WaitForSeconds(2f);
            GameObject GE3 = Instantiate(GPrefab7, GetuigenBattleStation); // Klopt nog niet
            dialogueText.text = playerUnit.unitName + " kiest om MW. Vermeulen te verhoren"; //hier moet de naam nog bij
            yield return new WaitForSeconds(2f);
            dialogueText.text = "MW. Vermeulen het woord is aan u"; // idem
            yield return new WaitForSeconds(2f);
            UI.GetuigenOn();
            textWolk.text = "De tijd van deze ernstige mishandeling lag tussen 4:15 en 5:00. Het tijdstip van overleden ligt tussen acht uren en vier uren voorafgaande aan het tijdstip van mijn onderzoek om 12:15. Ik heb toen ook vastgesteld dat de dood een niet-natuurlijke oorzaak had."; // hier komt zijn verhaal
            playerUnit.TakeDamage(-5); // Hierbij zeg je dus 10 damage. Dit is makkelijker dan dat gezeik via de prefab.
            battleScore.SetScore(playerUnit.score); // update de slider
            yield return new WaitForSeconds(6f);
            dialogueText.text = "Bedankt MW. Vermeulen"; // update
            Destroy(GE3);
            UI.GetuigenOff();
            yield return new WaitForSeconds(2f);

            state = BattleState.PLAYERTURN;
            StartCoroutine(PlayerTurn());
        
            }

    IEnumerator EndDag1(int input)
    {
        dialogueText.text = "Dit was de tweede zitting";
        UI.GetuigenOff();
        Score.HScore = input;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("3e zitting");
    }

    IEnumerator PlayerTurn()
    {
        
     if (PT == 0)
        {
            dialogueText.text = "Je mag nu één bewijsstuk kiezen";
            yield return new WaitForSeconds(1f);
            Button1.text = "Het dagboek van Jennifer";
            Button2.text = "De brief van Ting";
            Button3.text = "Reconstructie";
            Button4.text = "Relatie Tree";

        } else if (PT >= 4)
            {
                Button1.text = "";
                Button2.text = "";
                Button3.text = "";
            dialogueText.text = "Roep nu uw getuigen op";
            yield return new WaitForSeconds(2f);
            UI.ButtonOff();
            UI.ListOn();
            UI.GetuigenOff();

        } else if (G1 >= 0)
        {
            UI.GetuigenOff();
            UI.ListOn();
        }
    }
    // Dit zijn de functies voor als de 3 aanval buttons ingedrukt worden
    public void OnAttackButton1() // new function to trigger action when attack is pressed.
    {
        if (state != BattleState.PLAYERTURN) // Checkt of speler aan de beurt is
            return;
        //playerUnit.MinusTime(1);
        StartCoroutine(PlayerAttack1()); // pause during attack
    }
    public void OnAttackButton2() // new function to trigger action when attack is pressed.
    {
        if (state != BattleState.PLAYERTURN) // Checkt of speler aan de beurt is
            return;
        //playerUnit.MinusTime(1);
        StartCoroutine(PlayerAttack2()); // pause during attack
    }
    public void OnAttackButton3() // new function to trigger action when attack is pressed.
    {
        if (state != BattleState.PLAYERTURN) // Checkt of speler aan de beurt is
            return;
        //playerUnit.MinusTime(1);
        StartCoroutine(PlayerAttack3()); // pause during attack
    }
    public void OnAttackButton4() // new function to trigger action when attack is pressed.
    {
        if (state != BattleState.PLAYERTURN) // Checkt of speler aan de beurt is
            return;
        //playerUnit.MinusTime(1);
        StartCoroutine(PlayerAttack4()); // pause during attack
    }
    //Hier volgen de functies voor als de getuigen button ingedrukt wordt
    public void OnGetuigen1() 
    {
        if (state != BattleState.PLAYERTURN || G1 == 1 || G2 == 1)
        {
            return;
        }else 
                   
        if (G1 == 0)
        {
            G1 = 1;
            StartCoroutine(PlayerGetuigen1());
        } else
        if (G2 == 0)
        {
            G2 = 1;
            StartCoroutine(PlayerGetuigen1());
        } 
        else 
        if (G2 != 0)
        {
            G3 = 1;
            StartCoroutine(PlayerGetuigen1());
        }
        else
            StartCoroutine(PlayerGetuigen1()); // pause during attack
    }
    public void OnGetuigen2()
    {
        if (state != BattleState.PLAYERTURN || G1 == 2 || G2 == 2)
        {
            return;
        }
        else

         if (G1 == 0)
        {
            G1 = 2;
            StartCoroutine(PlayerGetuigen2());
        }
        else
         if (G2 == 0)
        {
            G2 = 2;
            StartCoroutine(PlayerGetuigen2());
        }
        else
        if (G2 != 0)
        {
            G3 = 2;
            StartCoroutine(PlayerGetuigen2());
        }
        else
            StartCoroutine(PlayerGetuigen2()); // pause during attack
    }
    public void OnGetuigen3()
    {
        if (state != BattleState.PLAYERTURN || G1 == 3 || G2 == 3)
        {
            return;
        }
        else

        if (G1 == 0)
        {
            G1 = 3;
            StartCoroutine(PlayerGetuigen3());
        }
        else
        if (G2 == 0)
        {
            G2 = 3;
            StartCoroutine(PlayerGetuigen3());
        }
        else
        if (G2 != 0)
        {
            G3 = 3;
            StartCoroutine(PlayerGetuigen3());
        }
        else
            StartCoroutine(PlayerGetuigen3()); // pause during attack
    }
    public void OnGetuigen4()
    {
        if (state != BattleState.PLAYERTURN || G1 == 4 || G2 == 4)
        {
            return;
        }
        else

         if (G1 == 0)
        {
            G1 = 4;
            StartCoroutine(PlayerGetuigen4());
        }
        else
         if (G2 == 0)
        {
            G2 = 4;
            StartCoroutine(PlayerGetuigen4());
        }
        else
        if (G2 != 0)
        {
            G3 = 4;
            StartCoroutine(PlayerGetuigen4());
        }
        else
            StartCoroutine(PlayerGetuigen4()); // pause during attack
    }
    public void OnGetuigen5()
    {
        if (state != BattleState.PLAYERTURN || G1 == 5 || G2 == 5)
        {
            return;
        }
        else

        if (G1 == 0)
        {
            G1 = 5;
            StartCoroutine(PlayerGetuigen5());
        }
        else
        if (G2 == 0)
        {
            G2 = 5;
            StartCoroutine(PlayerGetuigen5());
        }
        else
        if (G2 != 0)
        {
            G3 = 5;
            StartCoroutine(PlayerGetuigen5());
        }
        else
            StartCoroutine(PlayerGetuigen5()); // pause during attack
    }
    public void OnGetuigen6()
    {
        if (state != BattleState.PLAYERTURN || G1 == 6 || G2 == 6)
        {
            return;
        }
        else

        if (G1 == 0)
        {
            G1 = 6;
            StartCoroutine(PlayerGetuigen6());
        }
        else
        if (G2 == 0)
        {
            G2 = 6;
            StartCoroutine(PlayerGetuigen6());
        }
        else
        if (G2 != 0)
        {
            G3 = 6;
            StartCoroutine(PlayerGetuigen6());
        }
        else
            StartCoroutine(PlayerGetuigen6()); // pause during attack
    }
    public void OnGetuigen7()
    {
        if (state != BattleState.PLAYERTURN || G1 == 7 || G2 == 7)
        {
            return;
        }
        else

        if (G1 == 0)
        {
            G1 = 7;
            StartCoroutine(PlayerGetuigen7());
        }
        else
        if (G2 == 0)
        {
            G2 = 7;
            StartCoroutine(PlayerGetuigen7());
        }
        else
        if (G2 != 0)
        {
            G3 = 7;
            StartCoroutine(PlayerGetuigen7());
        }
        else
            StartCoroutine(PlayerGetuigen7()); // pause during attack
    }
    public void OnGetuigen8()
    {
        if (state != BattleState.PLAYERTURN || G1 == 8 || G2 == 8)
        {
            return;
        }
        else

        if (G1 == 0)
        {
            G1 = 8;
            StartCoroutine(PlayerGetuigen8());
        }
        else
        if (G2 == 0)
        {
            G2 = 8;
            StartCoroutine(PlayerGetuigen8());
        }
        else
        if (G2 != 0)
        {
            G3 = 8;
            StartCoroutine(PlayerGetuigen8());
        }
        else
            StartCoroutine(PlayerGetuigen8()); // pause during attack
    }
    public void OnGetuigen9()
    {
        if (state != BattleState.PLAYERTURN || G1 == 9 || G2 == 9)
        {
            return;
        }
        else
         if (G1 == 0)
        {
            G1 = 9;
            StartCoroutine(PlayerGetuigen9());
        }
        else
         if (G2 == 0)
        {
            G2 = 9;
            StartCoroutine(PlayerGetuigen9());
        }
        else
        if (G2 != 0)
        {
            G3 = 9;
            StartCoroutine(PlayerGetuigen9());
        }
        else
            StartCoroutine(PlayerGetuigen9()); // pause during attack
    }
    public void OnGetuigen10()
    {
        if (state != BattleState.PLAYERTURN || G1 == 10 || G2 == 10)
        {
            return;
        }
        else

        if (G1 == 0)
        {
            G1 = 10;
            StartCoroutine(PlayerGetuigen10());
        }
        else
        if (G2 == 0)
        {
            G2 = 10;
            StartCoroutine(PlayerGetuigen10());
        }
        else
        if (G2 != 0)
        {
            G3 = 10;
            StartCoroutine(PlayerGetuigen10());
        }
        else
            StartCoroutine(PlayerGetuigen10()); // pause during attack
    }
    public void OnGetuigen11()
    {
        if (state != BattleState.PLAYERTURN || G1 == 11 || G2 == 11)
        {
            return;
        }
        else

        if (G1 == 0)
        {
            G1 = 11;
            StartCoroutine(PlayerGetuigen11());
        }else if (G2 == 0)
        {
            G1 = 11;
            StartCoroutine(PlayerGetuigen11());
        }
        else
        if (G2 != 0)
        {
            G3 = 11;
            StartCoroutine(PlayerGetuigen11());
        }

        else
            StartCoroutine(PlayerGetuigen11()); // pause during attack
    }
    public void OnGetuigen12()
    {
        if (state != BattleState.PLAYERTURN || G1 == 12 || G2 == 12)
        {
            return;
        }
        else
        if (G1 == 0)
        {
            G1 = 12;
            StartCoroutine(PlayerGetuigen12());
        }
        else
        if (G2 == 0)
        {
            G2 = 12;
            StartCoroutine(PlayerGetuigen12());
        }
        else
        if (G2 != 0)
        {
            G3 = 12;
            StartCoroutine(PlayerGetuigen12());
        }
        else
            StartCoroutine(PlayerGetuigen12()); // pause during attack
    }
    

    IEnumerator PlayerGetuigen6()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOff(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab6, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Joyce te verhoren";
        yield return new WaitForSeconds(2f);
        dialogueText.text = " Joyce het woord is aan u";
        yield return new WaitForSeconds(2f);
        UI.GetuigenOn();
        textWolk.text = " Ik ben op maandagavond 5 juli 1993 bedreigd door Ali, Aldo en Abdoel. Ze hebben mij heel erg duidelijk gemaakt dat ik mijn mond moest houden over wat ik had gezien bij Golden Garden. Abdoel trok een wapen, ik schrok me dood. Er zijn al sinds het begin problemen tussen de jongens en mij. Ze drongen mijn kamer binnen en namen spullen of geld mee. Elke keer heb ik aangifte hiervan gedaan bij de politie. Nadat de jongens een keer mijn hele kamer kort en klein hadden geslagen, ben ik verhuisd. Ik denk dat Julie de jongens heeft geholpen om mij uit mijn kamer te zetten. Toen ik verhuisde naar een andere woning op de Oudeweg, toen vonden de jongens mij weer. Clarissa had namelijk het adres doorgegeven.";
        playerUnit.TakeDamage(10); // Hierbij zeg je dus 10 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        yield return new WaitForSeconds(10f);
        dialogueText.text = "Bedankt Joyce";
        UI.GetuigenOff();
        yield return new WaitForSeconds(2f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        if (G3 != 0)
        {
            StartCoroutine(EndDag1(playerUnit.score));
        }
        else
            StartCoroutine(PlayerTurn());
    }
    IEnumerator PlayerGetuigen4()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOff(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab4, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Clarissa te verhoren";
        yield return new WaitForSeconds(2f);
        dialogueText.text = "Mw Huang het woord is aan u";
        yield return new WaitForSeconds(2f);
        UI.GetuigenOn();
        textWolk.text = " De jongens die vaak langskomen bij ons op de Oudeweg hebben de boel helemaal verziekt. Ze hebben zelf op Linda en Mandy geschoten en de spullen van Joyce kapot gemaakt! Ik heb nooit echt een gelijkwaardige vriendschap met Joyce gehad. Ik durfde niets te zeggen tegen Joyce, laat staan haar tegen praten. Ze is nogal moeilijk te ontwijken. Joyce praat wel vaker niet de waarheid en dat hebben we ook tegen de huisbaas gezegd om te laten weten wat er aan de hand is.";
        playerUnit.TakeDamage(10); // Hierbij zeg je dus 10 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        yield return new WaitForSeconds(8f);
        dialogueText.text = "Bedankt Clarissa";
        UI.GetuigenOff();
        yield return new WaitForSeconds(2f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        if (G3 != 0)
        {
            StartCoroutine(EndDag1(playerUnit.score));
        }
        else
            StartCoroutine(PlayerTurn());
    }
    IEnumerator PlayerGetuigen5()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOff(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab5, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Julia te verhoren";
        yield return new WaitForSeconds(2f);
        dialogueText.text = "Julia het woord is aan u";
        yield return new WaitForSeconds(2f);
        UI.GetuigenOn();
        textWolk.text = "Wat er allemaal op de Oudeweg is gebeurd is voor mij echt het meest schokkende wat ik ooit heb meegemaakt. Ik denk dat de andere meiden echt door het huis zijn gecommandeerd door Aldo, Ali. Abdoel deed niks, hij gedraagt zich gewoon.";
        playerUnit.TakeDamage(7); // Hierbij zeg je dus 10 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        yield return new WaitForSeconds(6f);
        dialogueText.text = "Bedankt Julia";
        UI.GetuigenOff();
        yield return new WaitForSeconds(2f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        if (G3 != 0)
        {
            StartCoroutine(EndDag1(playerUnit.score));
        }
        else
            StartCoroutine(PlayerTurn());
    }
    IEnumerator PlayerGetuigen12()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOff(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab12, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Davey Kok te verhoren";
        yield return new WaitForSeconds(2f);
        dialogueText.text = "Davey Kok het woord is aan u";
        yield return new WaitForSeconds(2f);
        UI.GetuigenOn();
        textWolk.text = "Soms als de jongens langs kwamen op de Oudeweg, dan terroriseerde de 3 jongens de meisjes. Ik heb ook het idee dat Linda door een van hen wordt mishandeld met stroomschokken. Joyce en Linda zijn door de jongens met de dood bedreigd zijn, althans dat is wat ik vernomen had.";
        playerUnit.TakeDamage(2); // Hierbij zeg je dus 10 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        yield return new WaitForSeconds(6f);
        dialogueText.text = "Bedankt Davey Kok";
        UI.GetuigenOff();
        yield return new WaitForSeconds(2f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        if (G3 != 0)
        {
            StartCoroutine(EndDag1(playerUnit.score));
        }
        else
            StartCoroutine(PlayerTurn());
    }
    IEnumerator PlayerGetuigen11()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOff(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab11, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Linda te verhoren";
        yield return new WaitForSeconds(2f);
        dialogueText.text = "Linda het woord is aan u";
        yield return new WaitForSeconds(2f);
        UI.GetuigenOn();
        textWolk.text = "Ik was erbij toen Joyce werd bedreigd met een pistool door Abdoel, maar dit was niet op maandag 5 juli. Het was sowieso op een andere dag. Joyce is wel vaker bedreigd door de jongens. Ik heb het meerdere keren meegemaakt en een keer hadden de jongens zich opgesloten in Joyce’s kamer en toen gingen ze haar spullen kapot maken. Ze gooiden haar ruiten in en schreven het woord stinkdier op de muren. Uiteindelijk is ze maar verhuist. Julia en de jongens hebben altijd ruzie. Ze komt alleen naar ons huis als ze Mandy bezoekt. Ik denk wel dat Julia een oogje heeft op Abdoel, al snap ik niet waarom. Joyce is bij niemand echt geliefd. We hebben ook een keer met de meiden tegen de huisbaas gezegd dat ze soms liegt.";
        playerUnit.TakeDamage(2); // Hierbij zeg je dus 0 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        yield return new WaitForSeconds(10f);
        dialogueText.text = "Bedankt Linda";
        UI.GetuigenOff();
        yield return new WaitForSeconds(2f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        if (G3 != 0)
        {
            StartCoroutine(EndDag1(playerUnit.score));
        }
        else
            StartCoroutine(PlayerTurn());
    }
    IEnumerator PlayerGetuigen10()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOff(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab10, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Mandy te verhoren";
        yield return new WaitForSeconds(2f);
        dialogueText.text = "Mandy het woord is aan u";
        yield return new WaitForSeconds(2f);
        UI.GetuigenOn();
        textWolk.text = "Ik ben doodsbang voor de jongens, vooral voor Ali toen hij een mes op mijn keel zette en me met de dood bedreigde. Ik ben niet in mijn eentje uit geweest toen ik nog met Ali had, dat mocht niet van hem. Toen ik dacht dat Ali iets te maken had met de moord op die oma in Golden Garden, wilde ik niks meer met hem te maken hebben maar ik durfde niets te doen. Ik weet dat ik niet goed lig met de jongens en dat ik een keer geruimd zal worden en iedereen weet dat. Samen met de meiden heb ik met de huisbaas over Joyce gesproken. Ze liegt namelijk vaak en praat niet de waarheid maar niemand durft daar iets aan te doen.";
        playerUnit.TakeDamage(4); // Hierbij zeg je dus 3 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        yield return new WaitForSeconds(10f);
        dialogueText.text = "Bedankt Mandy";
        UI.GetuigenOff();
        yield return new WaitForSeconds(2f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        if (G3 != 0)
        {
            StartCoroutine(EndDag1(playerUnit.score));
        }
        else
            StartCoroutine(PlayerTurn());
    }
    IEnumerator PlayerGetuigen9()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOff(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab9, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Mw Vermeulen te verhoren";
        yield return new WaitForSeconds(2f);
        dialogueText.text = "Mw Vermeulen het woord is aan u";
        yield return new WaitForSeconds(2f);
        UI.GetuigenOn();
        textWolk.text = "De tijd van deze ernstige mishandeling zou zijn gelegen tussen 4:15 en 5:00. Het tijdstip van overleden ligt tussen acht uren en vier uren voorafgaande aan het tijdstip van mijn onderzoek om 12:15. Ik heb toen ook vastgesteld dat de dood een niet-natuurlijke oorzaak had.";
        playerUnit.TakeDamage(2); // Hierbij zeg je dus 2 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        yield return new WaitForSeconds(6f);
        dialogueText.text = "Bedankt Mw Vermeulen";
        UI.GetuigenOff();
        yield return new WaitForSeconds(2f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        if (G3 != 0)
        {
            StartCoroutine(EndDag1(playerUnit.score));
        }
        else
            StartCoroutine(PlayerTurn());

    }
    IEnumerator PlayerGetuigen8()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOff(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab8, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Mw Evers te verhoren";
        yield return new WaitForSeconds(2f);
        dialogueText.text = "Mw Evers het woord is aan u";
        yield return new WaitForSeconds(2f);
        UI.GetuigenOn();
        textWolk.text = "Ik heb verschillende dingen onderzocht. Een van deze dingen waren de hoofdharen die zijn gevonden in de broek van oma Zhang en die niet van haarzelf waren. Mijn onderzoek laat zien dat de haren niet passend zijn bij de verdachten.";
        playerUnit.TakeDamage(-2); // Hierbij zeg je dus -2 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        yield return new WaitForSeconds(6f);
        dialogueText.text = "Bedankt Mw Evers";
        UI.GetuigenOff();
        yield return new WaitForSeconds(2f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        if (G3 != 0)
        {
            StartCoroutine(EndDag1(playerUnit.score));
        }
        else
            StartCoroutine(PlayerTurn());

    }
    IEnumerator PlayerGetuigen7()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOff(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab7, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Mr Voortman te verhoren";
        yield return new WaitForSeconds(2f);
        dialogueText.text = "Mr Voortman het woord is aan u";
        yield return new WaitForSeconds(2f);
        UI.GetuigenOn();
        textWolk.text = "De 56-jarige oma Zhang is hoogstwaarschijnlijk door verstikking of wurging om het leven gebracht, vermoedelijk nadat zij hevig was mishandeld. De bevindingen op het lichaam van oma Zhang wijzen op verstikking door krachtig geweld op de hals, dit past bij de kenmerken van wurging of een wurggreep. Daarnaast waren er ook sporen van mishandeling gevonden op haar hoofd, borstkas en bovenste deel van haar buik waardoor verschillende ribben gebroken raakten.";
        playerUnit.TakeDamage(2); // Hierbij zeg je dus 2 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        yield return new WaitForSeconds(8f);
        dialogueText.text = "Bedankt Mr Voortman";
        UI.GetuigenOff();
        yield return new WaitForSeconds(2f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        if (G3 != 0)
        {
            StartCoroutine(EndDag1(playerUnit.score));
        }
        else
            StartCoroutine(PlayerTurn());

    }
    IEnumerator PlayerGetuigen1()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOff(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Abdoel te verhoren";
        yield return new WaitForSeconds(2f);
        dialogueText.text = "Abdoel het Woord is aan u.";
        yield return new WaitForSeconds(2f);
        UI.GetuigenOn();
        textWolk.text = "Op 3 juli 1993 waren mijn vrouw en ik in Tongeren in België omdat wij daar een nieuw restaurant hadden ";
        playerUnit.TakeDamage(-2); // Hierbij zeg je dus -2 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        yield return new WaitForSeconds(4f);
        dialogueText.text = "Bedankt Abdoel";
        UI.GetuigenOff();
        yield return new WaitForSeconds(2f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        if (G3 != 0)
        {
            StartCoroutine(EndDag1(playerUnit.score));
        }
        else
            StartCoroutine(PlayerTurn());
    }
    IEnumerator PlayerGetuigen3()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOff(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab3, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Ali te verhoren";
        yield return new WaitForSeconds(2f);
        dialogueText.text = "Ali het woord is aan u.";
        yield return new WaitForSeconds(2f);
        UI.GetuigenOn();
        textWolk.text = "Ik heb het niet gedaan, ik was sowieso die hele avond gewoon op de Oudeweg. ";
        playerUnit.TakeDamage(2); // Hierbij zeg je dus 2 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        yield return new WaitForSeconds(4f);
        dialogueText.text = "Bedankt Ali";
        UI.GetuigenOff();
        yield return new WaitForSeconds(2f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        if (G3 != 0)
        {
            StartCoroutine(EndDag1(playerUnit.score));
        }
        else
            StartCoroutine(PlayerTurn());
    }
    IEnumerator PlayerGetuigen2()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOff(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab2, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Aldo te verhoren";
        yield return new WaitForSeconds(2f);
        dialogueText.text = "Aldo het woord is aan u";
        yield return new WaitForSeconds(2f);
        UI.GetuigenOn();
        textWolk.text = "Ik ben onschuldig, ik was uit met Jennifer en haar vriendin.";
        playerUnit.TakeDamage(-5); // Hierbij zeg je dus 10 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        yield return new WaitForSeconds(4f);
        dialogueText.text = "Bedankt Aldo";
        UI.GetuigenOff();
        yield return new WaitForSeconds(2f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        if (G3 != 0)
        {
            StartCoroutine(EndDag1(playerUnit.score));
        }
        else
            StartCoroutine(PlayerTurn());
    }
}
