using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class PleidooiSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject GPrefab1; // dit laadt slechts de eerste enemy prefab in de game. Dit moet dus nog 17x

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


    public BattleSlider battleScore; // hiermee call ik het script Battlelsider in, noem het battlescore, kan evt vaker doen onder andere naam
    public GetuigenMenu UI;
    

    public BattleState state;

    int A3;
    int PT;

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

        yield return new WaitForSeconds(1f); //coroutine, 5 seconde delay 

        dialogueText.text = "Op 4 juli 1993, omstreeks 11.00 uur, werd in de keuken van het Chinees-Indisch restaurant [Golden Garden], gevestigd te Breda, het stoffelijk overschot aangetroffen van de 56-jarige [mw. Zhang], de moeder van de eigenaar van dat restaurant. Zij bleek door geweld om het leven te zijn gebracht.";
        yield return new WaitForSeconds(1f);

        dialogueText.text = "Voor deze moord klaagt de Bredase Rechtbank Aldo, Abdoel, Ali, Joyce, Julia en Clarissa aan. Wij verdenken hen van het plegen van deze moord op basis van het CID rapport.";
        yield return new WaitForSeconds(1f);

        dialogueText.text = "Julia heeft begin 1993 op de uitkijk gestaan bij een inbraak en overval op een Chinese vrouw uit Sittard. De Chinese vrouw is hierbij door de daders vermoord.";
        yield return new WaitForSeconds(1f);

        dialogueText.text = "Abdoel, Aldo en anderen zijn de daders van de moord op de Chinese vrouw.";
        yield return new WaitForSeconds(1f);

        dialogueText.text = "Abdoel, Julia, Mandy en anderen hebben zich in 1993 in Sittard schuldig gemaakt aan diverse winkeldiefstallen, inbraken, berovingen en andere vermogensmisdrijven waarbij in een aantal gevallen de slachtoffers zijn bedreigd met een vuurwapen.";
        yield return new WaitForSeconds(1f);

        dialogueText.text = "Abdoel, Karim en anderen houden zich bezig met de smokkel van cocaïne vanuit Nederland naar Frankrijk.";
        yield return new WaitForSeconds(1f);

        state = BattleState.PLAYERTURN; // verander state naar volgende
        StartCoroutine(PlayerTurn()); // functie PlayerTurn uitoefenen
    }

    IEnumerator PlayerAttack1()
    {   // Aanval 1
        if (PT == 0)
        {
            dialogueText.text = playerUnit.unitName + "zegt " + "Het OM is er van overtuigd dat Ali, Abdoel, Aldo, Julia, Joyce en Clarissa daders zijn van de moord op oma Zhang.";
            yield return new WaitForSeconds(1f);

            int isDead = playerUnit.TakeDamage(playerUnit.OP1A); // Start de TakeDamage funcite (aantal damage komt van player)
            battleScore.SetScore(playerUnit.score);
                        yield return new WaitForSeconds(1f);
            dialogueText.text = "Kies het volgende gedeelte van het starpleidooi.";
            Button1.text = "Op basis van het verhaal van de patholoog-anatoom en de recherches …";
            Button2.text = "Op basis van het verhaal van Mw. Boonstra en het dagboekfragment van Jennifer … ";
            Button3.text = "Op basis van de verklaringen van Joyce, Clarissa en Julia …";
            PT += 1;
        } else if (PT == 1)
        {
            dialogueText.text = playerUnit.unitName + "zegt " + "Op basis van het verhaal van de patholoog-anatoom en de recherches …";
            yield return new WaitForSeconds(1f);

            int isDead = playerUnit.TakeDamage(playerUnit.OP2A); // Start de TakeDamage funcite (aantal damage komt van player)
            battleScore.SetScore(playerUnit.score);
            
            yield return new WaitForSeconds(1f);
            dialogueText.text = "Kies het volgende gedeelte van het starpleidooi.";
            Button1.text = "en op basis van de huidige wetboeken eist het OM voor alle verdachten een gevangenisstraf van ten minste 15 jaar onvoorwaardelijk.";
            Button2.text = "en op basis van de huidige wetboeken eist het OM voor alle verdachten een gevangenisstraf van ten minste 10 jaar voorwaardelijk.";
            Button3.text = "en op basis van de huidige wetboeken eist het OM voor Ali, Abdoel en Aldo een gevangenisstraf van ten minste 15 jaar onvoorwaardelijk en voor Julia, Joyce en Clarissa eist het OM ten minste 5 jaar onvoorwaardelijk.";
            PT += 1;
        } else if (PT == 2)
        {
            dialogueText.text = playerUnit.unitName + "zegt " + "en op basis van de huidige wetboeken eist het OM voor alle verdachten een gevangenisstraf van ten minste 15 jaar onvoorwaardelijk.";
            yield return new WaitForSeconds(1f);

            int isDead = playerUnit.TakeDamage(playerUnit.OP3A); // Start de TakeDamage funcite (aantal damage komt van player)
            battleScore.SetScore(playerUnit.score);
            
            yield return new WaitForSeconds(1f);
            dialogueText.text = "Dit was het starpleidooi.";
            Button1.text = "";
            Button2.text = "";
            Button3.text = "";
            PT += 1;

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        /* else if (PT == 3)
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }*/
    }
    IEnumerator PlayerAttack2()
    {   // Aanval 2

        if (PT == 0)
        {
            dialogueText.text = playerUnit.unitName + "zegt " + "Het OM is er van overtuigd dat Ali, Abdoel en Aldo daders zijn van de moord op oma Zhang en wij beschouwen Julia, Joyce en Clarissa als medeplichtige bij de moord op oma Zhang.";
            yield return new WaitForSeconds(1f);

            int isDead = playerUnit.TakeDamage(playerUnit.OP1B); // Start de TakeDamage funcite (aantal damage komt van player)
            battleScore.SetScore(playerUnit.score);
            
            
            yield return new WaitForSeconds(1f);
            dialogueText.text = "Kies het volgende gedeelte van het starpleidooi.";
            Button1.text = "Op basis van het verhaal van de patholoog-anatoom en de recherches …";
            Button2.text = "Op basis van het verhaal van Mw. Boonstra en het dagboekfragment van Jennifer … ";
            Button3.text = "Op basis van de verklaringen van Joyce, Clarissa en Julia …";
            PT += 1;
        }
        else if (PT == 1)
        {
            dialogueText.text = playerUnit.unitName + "zegt " + "Op basis van het verhaal van Mw. Boonstra en het dagboekfragment van Jennifer … ";
            yield return new WaitForSeconds(1f);

            int isDead = playerUnit.TakeDamage(playerUnit.OP2B); // Start de TakeDamage funcite (aantal damage komt van player)
            battleScore.SetScore(playerUnit.score);
            
            
            yield return new WaitForSeconds(1f);
            dialogueText.text = "Kies het volgende gedeelte van het starpleidooi.";
            Button1.text = "en op basis van de huidige wetboeken eist het OM voor alle verdachten een gevangenisstraf van ten minste 15 jaar onvoorwaardelijk.";
            Button2.text = "en op basis van de huidige wetboeken eist het OM voor alle verdachten een gevangenisstraf van ten minste 10 jaar voorwaardelijk.";
            Button3.text = "en op basis van de huidige wetboeken eist het OM voor Ali, Abdoel en Aldo een gevangenisstraf van ten minste 15 jaar onvoorwaardelijk en voor Julia, Joyce en Clarissa eist het OM ten minste 5 jaar onvoorwaardelijk.";
            PT += 1;
        }
        else if (PT == 2)
        {
            dialogueText.text = playerUnit.unitName + "zegt " + "en op basis van de huidige wetboeken eist het OM voor alle verdachten een gevangenisstraf van ten minste 10 jaar voorwaardelijk.";
            yield return new WaitForSeconds(1f);

            int isDead = playerUnit.TakeDamage(playerUnit.OP3B); // Start de TakeDamage funcite (aantal damage komt van player)
            battleScore.SetScore(playerUnit.score);
            
            
            yield return new WaitForSeconds(1f);
            dialogueText.text = "Dit was het starpleidooi.";
            Button1.text = "";
            Button2.text = "";
            Button3.text = "";
            PT += 1;

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        } /* else if (PT == 3)
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }*/

    }
    IEnumerator PlayerAttack3()
    {   // Aanval 3
        if (PT == 0)
        {
            dialogueText.text = playerUnit.unitName + "zegt " + "Het OM is er van overtuigd dat Ali, Abdoel, Aldo, Julia, Joyce en Clarissa onschuldig zijn. ";
            yield return new WaitForSeconds(1f);

            int isDead = playerUnit.TakeDamage(playerUnit.OP1C); // Start de TakeDamage funcite (aantal damage komt van player)
            battleScore.SetScore(playerUnit.score);
           
            yield return new WaitForSeconds(1f);
            dialogueText.text = "Kies het volgende gedeelte van het starpleidooi.";
            Button1.text = "Op basis van het verhaal van de patholoog-anatoom en de recherches …";
            Button2.text = "Op basis van het verhaal van Mw. Boonstra en het dagboekfragment van Jennifer … ";
            Button3.text = "Op basis van de verklaringen van Joyce, Clarissa en Julia …";
            PT += 1;
        }
        else if (PT == 1)
        {
            dialogueText.text = playerUnit.unitName + "zegt " + "Op basis van de verklaringen van Joyce, Clarissa en Julia …";
            yield return new WaitForSeconds(1f);

            int isDead = playerUnit.TakeDamage(playerUnit.OP2C); // Start de TakeDamage funcite (aantal damage komt van player)
            battleScore.SetScore(playerUnit.score);
            
            
            yield return new WaitForSeconds(1f);
            dialogueText.text = "Kies het volgende gedeelte van het starpleidooi.";
            Button1.text = "en op basis van de huidige wetboeken eist het OM voor alle verdachten een gevangenisstraf van ten minste 15 jaar onvoorwaardelijk.";
            Button2.text = "en op basis van de huidige wetboeken eist het OM voor alle verdachten een gevangenisstraf van ten minste 10 jaar voorwaardelijk.";
            Button3.text = "en op basis van de huidige wetboeken eist het OM voor Ali, Abdoel en Aldo een gevangenisstraf van ten minste 15 jaar onvoorwaardelijk en voor Julia, Joyce en Clarissa eist het OM ten minste 5 jaar onvoorwaardelijk.";
            PT += 1;
        }
        else if (PT == 2)
        {
            dialogueText.text = playerUnit.unitName + "zegt " + "en op basis van de huidige wetboeken eist het OM voor Ali, Abdoel en Aldo een gevangenisstraf van ten minste 15 jaar onvoorwaardelijk en voor Julia, Joyce en Clarissa eist het OM ten minste 5 jaar onvoorwaardelijk.";
            yield return new WaitForSeconds(1f);

            int isDead = playerUnit.TakeDamage(playerUnit.OP3C); // Start de TakeDamage funcite (aantal damage komt van player)
            battleScore.SetScore(playerUnit.score);
            
            yield return new WaitForSeconds(1f);
            dialogueText.text = "Dit was het starpleidooi.";
            Button1.text = "";
            Button2.text = "";
            Button3.text = "";
            PT += 1;
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        } /* else if (PT == 3)
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        */
    }
    
    IEnumerator EnemyTurn()
    {
        if (PT == 3)
        {
            dialogueText.text = enemyUnit.unitName + " verteld zijn startpleidooi."; // Aangeven van aanval
            yield return new WaitForSeconds(1f);

            dialogueText.text = enemyUnit.unitName +"zegt "+ "Mijn cliënten zijn onschuldig";
            yield return new WaitForSeconds(1f);

            dialogueText.text = enemyUnit.unitName + "zegt " + "Het sporenonderzoek van de politie laat geen relatie zien tussen mijn cliënten en de moord op oma Zhang.";
            yield return new WaitForSeconds(1f);

            dialogueText.text = enemyUnit.unitName + "zegt " + "De verklaring van Annabel plaats mijn cliënten niet op de plaats en tijd van de moord, dus zij kunnen het niet gedaan hebben.";
            yield return new WaitForSeconds(1f);


            dialogueText.text = "Dit was het openingspleidooi van de Advocaat";
            int isDead = playerUnit.TakeDamage(enemyUnit.OP1A); // damage de player
            battleScore.SetScore(playerUnit.score); //playerHUD.SetHP, slider verzetten
            yield return new WaitForSeconds(1f);
            PT = 4;

                state = BattleState.PLAYERTURN;
                StartCoroutine(PlayerTurn());
         } else 
         
         if (PT == 4) // hier kan de enemy een getuigen oproepen / iets doen? 
        {
            dialogueText.text = "De advocaat van de verdachte mag nu een getuigen oproepen";
            yield return new WaitForSeconds(3f);
            dialogueText.text = "Ik kies voor geen getuigen";
            yield return new WaitForSeconds(3f);
            PT = 5;

            state = BattleState.PLAYERTURN;
            StartCoroutine(PlayerTurn());
        }

        else

         if (PT == 5) // hier kan de enemy een 2e getuigen oproepen / iets doen? 
        { // Dit is tevens het einde van dag één. Nu kan een nieuwe Scene geladen worden. Dit is scene Start Pleidooi. JE kan een nieuwe aanmaken. Dan moet dit script gekopieerd worden. En alle variabelen opnieuw toegewezen enzo.

            PT = 6;
            state = BattleState.PLAYERTURN;
            StartCoroutine(PlayerTurn());
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

    IEnumerator PlayerTurn()
    {
        
     if (PT == 0)
        {
            dialogueText.text = "Het is tijd voor het openingspleidooi van het OM" + "\r\n" + "Kies een openingspleidooi";
            Button1.text = "Het OM is er van overtuigd dat Ali, Abdoel, Aldo, Julia, Joyce en Clarissa daders zijn van de moord op oma Zhang.";
            Button2.text = "Het OM is er van overtuigd dat Ali, Abdoel en Aldo daders zijn van de moord op oma Zhang en wij beschouwen Julia, Joyce en Clarissa als medeplichtige bij de moord op oma Zhang.";
            Button3.text = "Het OM is er van overtuigd dat Ali, Abdoel, Aldo, Julia, Joyce en Clarissa onschuldig zijn. ";
        } else if (PT >= 4)
            {
                Button1.text = "";
                Button2.text = "";
                Button3.text = "";
            dialogueText.text = "Roep nu uw getuigen op";
            yield return new WaitForSeconds(4f);
            UI.ButtonOff();
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
    
    //Hier volgen de functies voor als de getuigen button ingedrukt wordt
    public void OnGetuigen1() 
    {
        if (state != BattleState.PLAYERTURN) 
            return;
        //playerUnit.MinusTime(1);
        StartCoroutine(PlayerGetuigen1()); // pause during attack
    }
    public void OnGetuigen2()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        //playerUnit.MinusTime(1);
        StartCoroutine(PlayerGetuigen2()); // pause during attack
    }
    public void OnGetuigen3()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        //playerUnit.MinusTime(1);
        StartCoroutine(PlayerGetuigen3()); // pause during attack
    }
    public void OnGetuigen4()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        //playerUnit.MinusTime(1);
        StartCoroutine(PlayerGetuigen4()); // pause during attack
    }
    public void OnGetuigen5()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        //playerUnit.MinusTime(1);
        StartCoroutine(PlayerGetuigen5()); // pause during attack
    }
    public void OnGetuigen6()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        //playerUnit.MinusTime(1);
        StartCoroutine(PlayerGetuigen6()); // pause during attack
    }
    public void OnGetuigen7()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        //playerUnit.MinusTime(1);
        StartCoroutine(PlayerGetuigen7()); // pause during attack
    }
    public void OnGetuigen8()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        //playerUnit.MinusTime(1);
        StartCoroutine(PlayerGetuigen8()); // pause during attack
    }
    public void OnGetuigen9()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        //playerUnit.MinusTime(1);
        StartCoroutine(PlayerGetuigen9()); // pause during attack
    }
    public void OnGetuigen10()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        //playerUnit.MinusTime(1);
        StartCoroutine(PlayerGetuigen10()); // pause during attack
    }
    public void OnGetuigen11()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        //playerUnit.MinusTime(1);
        StartCoroutine(PlayerGetuigen11()); // pause during attack
    }
    public void OnGetuigen12()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        //playerUnit.MinusTime(1);
        StartCoroutine(PlayerGetuigen12()); // pause during attack
    }
    public void OnGetuigen13()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        //playerUnit.MinusTime(1);
        StartCoroutine(PlayerGetuigen13()); // pause during attack
    }
    public void OnGetuigen14()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        //playerUnit.MinusTime(1);
        StartCoroutine(PlayerGetuigen14()); // pause during attack
    }
    public void OnGetuigen15()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        //playerUnit.MinusTime(1);
        StartCoroutine(PlayerGetuigen15()); // pause during attack
    }
    public void OnGetuigen16()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        //playerUnit.MinusTime(1);
        StartCoroutine(PlayerGetuigen16()); // pause during attack
    }
    public void OnGetuigen17()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        //playerUnit.MinusTime(1);
        StartCoroutine(PlayerGetuigen17()); // pause during attack
    }
    public void OnGetuigen18()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        //playerUnit.MinusTime(1);
        StartCoroutine(PlayerGetuigen18()); // pause during attack
    }
    
    IEnumerator PlayerGetuigen1()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Mr Zhang te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Mr Zhang het woord is aan u";
        yield return new WaitForSeconds(1f);
        textWolk.text = "Op 3 juli 1993 waren mijn vrouw en ik in Tongeren in België omdat wij daar een nieuw restaurant hadden geopend. Mijn moeder, oma Zhang, paste op onze kinderen in ons huis zoals zij al vaker deed. In ons huis wonen ook twee hulpkoks, Ting Liao en Guang Yin.";
        playerUnit.TakeDamage(10); // Hierbij zeg je dus 10 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Mr Zhang";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator PlayerGetuigen2()
    {
        dialogueText.text = playerUnit.unitName + " kiest om Mr Zhang te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Mr Zhang ";
    }
    IEnumerator PlayerGetuigen3()
    {
        dialogueText.text = playerUnit.unitName + " kiest om Mr Zhang te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Mr Zhang ";
    }
    IEnumerator PlayerGetuigen4()
    {
        dialogueText.text = playerUnit.unitName + " kiest om Mr Zhang te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Mr Zhang ";
    }
    IEnumerator PlayerGetuigen5()
    {
        dialogueText.text = playerUnit.unitName + " kiest om Mr Zhang te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Mr Zhang ";
    }
    IEnumerator PlayerGetuigen6()
    {
        dialogueText.text = playerUnit.unitName + " kiest om Mr Zhang te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Mr Zhang ";
    }
    IEnumerator PlayerGetuigen7()
    {
        dialogueText.text = playerUnit.unitName + " kiest om Mr Zhang te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Mr Zhang ";
    }
    IEnumerator PlayerGetuigen8()
    {
        dialogueText.text = playerUnit.unitName + " kiest om Mr Zhang te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Mr Zhang ";
    }
    IEnumerator PlayerGetuigen9()
    {
        dialogueText.text = playerUnit.unitName + " kiest om Mr Zhang te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Mr Zhang ";
    }
    IEnumerator PlayerGetuigen10()
    {
        dialogueText.text = playerUnit.unitName + " kiest om Mr Zhang te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Mr Zhang ";
    }
    IEnumerator PlayerGetuigen11()
    {
        dialogueText.text = playerUnit.unitName + " kiest om Mr Zhang te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Mr Zhang ";
    }
    IEnumerator PlayerGetuigen12()
    {
        dialogueText.text = playerUnit.unitName + " kiest om Mr Zhang te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Mr Zhang ";
    }
    IEnumerator PlayerGetuigen13()
    {
        dialogueText.text = playerUnit.unitName + " kiest om Mr Zhang te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Mr Zhang ";
    }
    IEnumerator PlayerGetuigen14()
    {
        dialogueText.text = playerUnit.unitName + " kiest om Mr Zhang te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Mr Zhang ";
    }
    IEnumerator PlayerGetuigen15()
    {
        dialogueText.text = playerUnit.unitName + " kiest om Mr Zhang te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Mr Zhang ";
    }
    IEnumerator PlayerGetuigen16()
    {
        dialogueText.text = playerUnit.unitName + " kiest om Mr Zhang te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Mr Zhang ";
    }
    IEnumerator PlayerGetuigen17()
    {
        dialogueText.text = playerUnit.unitName + " kiest om Mr Zhang te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Mr Zhang ";
    }
    IEnumerator PlayerGetuigen18()
    {
        dialogueText.text = playerUnit.unitName + " kiest om Mr Zhang te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Mr Zhang ";
    }

}
