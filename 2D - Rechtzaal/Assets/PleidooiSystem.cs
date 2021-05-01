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
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Mw Huang te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Mw Huang het woord is aan u";
        yield return new WaitForSeconds(1f);
        textWolk.text = "Ik heb niet kunnen zien of oma Zhang in het huis heeft geslapen. Meestal slaapt zij op de bedbank of op de bank in de kamer. Het dekbed op de bedbank was in de war maar dat kan ook komen door de kinderen die aan het spelen waren. De bedbank staat namelijk in de kamer van de kinderen.";
        playerUnit.TakeDamage(0); // Hierbij zeg je dus 10 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Mw Huang";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator PlayerGetuigen3()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Chong Kong te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Chong Kong het woord is aan u";
        yield return new WaitForSeconds(1f);
        textWolk.text = "Rond 11:00 kwam ik samen met Fai She en Park Tao binnen via het afhaalgedeelte van het restaurant, dat tevens al van het slot was. Meestal is Kelvin of oma Zhang binnen als wij aankomen. Maar toen zagen wij iets ongebruikelijks: het licht in de keuken brandt, de gokkast ligt opengebroken en het geldbakje van de kast ligt op de grond. In de keuken vonden wij het dode lichaam van oma Zhang waarna ik schreeuwde en weg liep.";
        playerUnit.TakeDamage(2); // Hierbij zeg je dus 10 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Chong Kong";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator PlayerGetuigen4()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Fai She te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Fai She het woord is aan u";
        yield return new WaitForSeconds(1f);
        textWolk.text = "Samen met Chong Kong Long en Park Tao kwam ik binnen even voor 11:00 in het restaurant. De deur van het afhaalgedeelte was al van het slot, wat niet vreemd is want soms is ober Kelvin of oma Zhang al binnen. Wij troffen daar wel het licht dat aan was in de keuken, de gokkast die opengebroken lag en het geldbakje van de kast die op de grond lag. In de keuken vonden we het dode lichaam van oma Zhang, waarna Long schreeuwde en weg liep. Ik ging toen gewapend met een meubelstuk de keuken in, zodat ik mij kon verweren tegen eventuele inbrekers. Nadat ik niemand tegenkwam ben ik naar het huis van oma Zhang gerend om mijn man te halen.";
        playerUnit.TakeDamage(5); // Hierbij zeg je dus 10 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Fai She";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator PlayerGetuigen5()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Guang Yin te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Guang Yin het woord is aan u";
        yield return new WaitForSeconds(1f);
        textWolk.text = "Oma Zhang heeft voor mij de deur opengemaakt waarna ik direct naar mijn zolderkamer ging die ik deel met Liao. Na een half uur kwam ook Liao thuis. Ik heb zelf televisie gekeken en een douche genomen waarna ik rond middernacht ben gaan slapen. Ik heb ‘s nachts niks bijzonders gehoord of gezien.";
        playerUnit.TakeDamage(0); // Hierbij zeg je dus 0 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Guang Yin";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator PlayerGetuigen6()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Park Tao te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Park Tao het woord is aan u";
        yield return new WaitForSeconds(1f);
        textWolk.text = "Ik kwam samen met Fai She en Chong Kong Long rond 11:00 binnen in het restaurant via het afhaalgedeelte. De deur was al van het slot wat normaal was, maar het licht in de keuken brandde, de gokkast was opengebroken en het geldbakje van de kast lag op de grond, wat erg vreemd was. Toen wij de keuken in liepen zagen wij het dode lichaam van oma Zhang waardoor Long ging schreeuwen en wegliep en Fai She pakte een meubelstuk om inbrekers te kunnen verweren. Ik ging toen snel naar de snackbar naast het restaurant toe, Sjakies Smikkel, en de eigenaar Casper Bosman belde toen de politie rond 10:55. Tijdens het wachten belde ik met de België verblijvende zoon van oma Zhang en iets na elven was de politie ter plaatse.";
        playerUnit.TakeDamage(3); // Hierbij zeg je dus 3 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Park Tao";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator PlayerGetuigen7()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Ting Liao te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Tiang Liao het woord is aan u";
        yield return new WaitForSeconds(1f);
        textWolk.text = "Ik heb rond 23:00 de overdracht van de dagopbrengst gezien van ober Fong Cheng (bijnaam Kelvin) aan oma Zhang. Toen ik thuiskwam was Yin al televisie aan het kijken en zelf ging ik rond 2:00 slapen. Ik heb niemand uit de woning horen gaan en ook geen telefoon gehoord.";
        playerUnit.TakeDamage(0); // Hierbij zeg je dus 0 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Ting Liao";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator PlayerGetuigen8()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Wei Deng te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Wei Deng het woord is aan u";
        yield return new WaitForSeconds(1f);
        textWolk.text = "Ik werkte bij Golden Garden net een week. Op zaterdag 3 juli 1993 werkte ik in het restaurant in Tongeren. Na sluiting zaten we nog te eten tot 0:30. Ik heb toen aan eigenaar Zhang gevraagd of hij nog naar Sittard gaat, want er is niet meer genoeg babi pangang-vlees en babi pangang-saus. Omdat hij dat niet van plan was, dacht ik dat ik dan zelf wel kon gaan de volgende ochtend. Ik zou op zondagochtend om 9:00 bij Golden Garden zijn om het op te halen. Ik vertrok even later met een collega richting Nederland en zette hem af in Maastricht.Ik kwam thuis, in Weert, rond 1:50 waarna ik in slaap ben gevallen.De volgende ochtend, zondags, had ik mij verslapen en stapte ik snel in de auto. Voor de grens ging ik even tanken, maar het was heel erg druk en ik moest wel 20 - 25 min wachten. Ik kon pas om 11:30 weer doorrijden en kwam rond het middaguur aan in Tongeren.
";
        playerUnit.TakeDamage(-5); // Hierbij zeg je dus -5 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Wei Deng";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator PlayerGetuigen9()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Kelvin te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Kelvin het woord is aan u";
        yield return new WaitForSeconds(1f);
        textWolk.text = "Ik ben op 3 juli samen met Liao om ongeveer 23:00 uit het restaurant vertrokken. Toen kwamen wij oma Zhang halverwege op straat tegen en hebben toen ter plekke het geld gegeven. Daarna zijn Liao en oma Zhang vertrokken naar het huis van de zoon van oma Zhang.";
        playerUnit.TakeDamage(2); // Hierbij zeg je dus 2 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Kelvin";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator PlayerGetuigen10()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Mr Voortman te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Mr Voortman het woord is aan u";
        yield return new WaitForSeconds(1f);
        textWolk.text = "De 56-jarige oma Zhang is hoogstwaarschijnlijk door verstikking of wurging om het leven gebracht, vermoedelijk nadat zij hevig was mishandeld. De bevindingen op het lichaam van oma Zhang wijzen op verstikking door krachtig geweld op de hals, dit past bij de kenmerken van wurging of een wurggreep. Daarnaast waren er ook sporen van mishandeling gevonden op haar hoofd, borstkas en bovenste deel van haar buik waardoor verschillende ribben gebroken raakten.";
        playerUnit.TakeDamage(2); // Hierbij zeg je dus 2 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Mr Voortman";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator PlayerGetuigen11()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Mw Evers te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Ik heb verschillende dingen onderzocht. Een van deze dingen waren de hoofdharen die zijn gevonden in de broek van oma Zhang en die niet van haarzelf waren. Mijn onderzoek laat zien dat de haren niet passend zijn bij de verdachten. Uit de bloedsporen heb ik wederom niks kunnen halen.Het was niet mogelijk om bruikbaar DNA uit deze sporen te verkrijgen. Als laatste heb ik gekeken naar de vlekken op de kleding van het slachtoffer. Alle sporen heb ik onderzocht maar wederom bleek er weer te weinig DNA aanwezig te zijn voor een analyse.";
        yield return new WaitForSeconds(1f);
        textWolk.text = "Op 3 juli 1993 waren mijn vrouw en ik in Tongeren in België omdat wij daar een nieuw restaurant hadden ";
        playerUnit.TakeDamage(-2); // Hierbij zeg je dus -2 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Mw Evers";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator PlayerGetuigen12()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Mw Vermeulen te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "De tijd van deze ernstige mishandeling lag tussen 4:15 en 5:00. Het tijdstip van overleden ligt tussen acht uren en vier uren voorafgaande aan het tijdstip van mijn onderzoek om 12:15. Ik heb toen ook vastgesteld dat de dood een niet-natuurlijke oorzaak had.";
        yield return new WaitForSeconds(1f);
        textWolk.text = "Op 3 juli 1";
        playerUnit.TakeDamage(2); // Hierbij zeg je dus 2 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Mw Vermeulen";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator PlayerGetuigen13()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Mw Kuipers te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Mw Kuipers het woord is aan u";
        yield return new WaitForSeconds(1f);
        textWolk.text = "Mijn collega’s en ik zijn er van overtuigd dat er voor de avond van 3 op 4 juli 1993 twee scenario's zich hebben kunnen afspelen. Ik zal kort beide scenario’s beschrijven voor de rechtbank. Scenario 1 beschouwd Joyce, Julia en Clarissa als toeschouwers en Aldo, Abdoel en Ali als daders. Joyce en Clarissa zijn samen uit geweest in Sittard en arriveren rond 3:00 bij het huis van Alexander waarna ze zijn gaan slapen. Om 4:00 wordt Clarissa gewekt door Joyce om naar een straat in de buurt van het restaurant te gaan.Clarissa zegt dat ze daar tussen 4:00 en 4:30 daar aankwamen, Joyce beweert dat ze tussen 4:30 en 5:15 aankwamen.Eenmaal aangekomen daar treffen ze de Abdoel, Aldo en Ali.Volgens Clarissa en Joyce gingen de jongens naar binnen en kwamen ze even later weer naar buiten.Na het vertrek van de jongens lopen de meiden naar binnen om te controleren of oma Zhang nog leefde, Clarissa beweert dat ze oma Zhang niet in leven heeft gezien. Scenario 2 beschouwd zowel Joyce, Julia en Clarissa als Aldo, Abdoel en Ali als daders.De tijden zijn hetzelfde alleen zeg Julia dat zij samen met de jongens arriveert rond 2:00.Julia zegt dat de jongens de meisjes hebben opgedragen om de eigenaar van Golden Garden op te halen.Joyce, Julia en Clarissa hebben oma opgehaald en meegenomen. Iedereen behalve Julia gaat het restaurant binnen, dat komt in elke verklaring naar voren. Joyce en Clarissa zien dat oma mishandeld wordt door de jongens en ze proberen hun te stoppen waarna een van de jongens oma’s keel hebben dicht gegrepen en daarna dichtgeknepen. Wie de dader is, is niet duidelijk";
        playerUnit.TakeDamage(10); // Hierbij zeg je dus 10 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Mw Kuipers";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator PlayerGetuigen14()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Mr Van der Laan te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Mr Van der Laan het woord is aan u";
        yield return new WaitForSeconds(1f);
        textWolk.text = "Oudeweg 92 is een soort halfweghuis. De meeste bewoners wonen daar omdat zij eerder verbleven in het gezinsvervangend tehuis Huize Terlet in Roermond. In 1993 werd de Oudeweg 92 bijna dagelijks bezocht door een groep jongens, onder wie Aldo, Abdoel en Ali, die zichzelf ‘de zeven van Sittard’ zouden noemen. Aldo ontkent deze naam. Volgens de meisjes zijn de jongens al in juni 1993 frequente bezoekers van Oudeweg 92, maar volgens de jongens pas vanaf juli / augustus 1993.De bezoeken zouden gepaard zijn gegaan met bedreiging en intimidatie.De verklaringen hierover zijn zowel afkomstig van de vermeende slachtoffers als van getuigen.";
        playerUnit.TakeDamage(5); // Hierbij zeg je dus 5 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Mr Van der Laan";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator PlayerGetuigen15()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Mw Boonstra te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Mw Boonstra het woord is aan u";
        yield return new WaitForSeconds(1f);
        textWolk.text = "Na een drukke dag kwamen mijn man en ik tussen 23.30 en 24.00 thuis op zondag 4 juli 1993. Van de overburen kregen we te horen wat er met Oma Zhang was gebeurd. Ik realiseerde mij een week later dat wat ik toen gehoord had mogelijk verband houdt met de moord op oma Zhang. Ik was die nacht tussen 3.15 en 3.30 in de keuken waar ik het licht uitdeed en toen naar de gang liep. Ik herkende de schim van Oma Zhang aan de manier van lopen en aan haar slofjes. Toen ik de woonkamer in liep hoorde ik een gil waarna er in het Chinees gegild en gekrijst werd. De gil kon van oma komen maar dat weet ik niet zeker. Op een gegeven moment hoorde ik niks meer en ging ik weer slapen.";
        playerUnit.TakeDamage(10); // Hierbij zeg je dus 10 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Mw Boonstra";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator PlayerGetuigen16()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Jennifer te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Jennifer het woord is aan u";
        yield return new WaitForSeconds(1f);
        textWolk.text = "Ik ben samen met mijn vriend Aldo, uit geweest in Sittard, samen met een vriendin van mij. Mijn vriendin en ik gingen samen naar de discotheek De Roemer en ontmoette daar Aldo. Samen klikte we meteen en kregen we iets. We waren sowieso vanaf 23h in de kroeg tot een uur of 3:00 toen alles ging sluiten. Toen ik thuis kwam heb ik meteen deze fantastische avond opgeschreven in mijn dagboek, je kan het zelf checken hoor! Ik heb de volgende dag de datum aangepast, omdat ik te dronken was en het verkeerd had opgeschreven.";
        playerUnit.TakeDamage(-5); // Hierbij zeg je dus -5 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Jennifer";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator PlayerGetuigen17()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Annabel te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Annabel het woord is aan u";
        yield return new WaitForSeconds(1f);
        textWolk.text = "Ivar, Floris, Abdoel en ik zijn uitgegaan in Sittard. Ik weet niet meer precies hoe laat wij naar huis gingen maar het was zeker sluitingstijd aangezien de lampen in de clubs alweer aan gingen. Daarna zijn wij naar Ivar’s en mijn oma gegaan want die was jarig, Ivar is trouwens ook mijn neef. We namen de taxi naar haar huis en toen wij aankwamen was het feest zeker nog in volle gang. Toen we aangeschoven waren zijn we tot vroeg in de ochtend door gegaan. Ik heb niet afscheid genomen van de jongens maar ben gaan slapen toen het licht werd, ik weet niet hoe lang zij nog door zijn gegaan of of ze al eerder weg waren.  ";
        playerUnit.TakeDamage(-5); // Hierbij zeg je dus -5 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Annabel";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator PlayerGetuigen18()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Chi Li te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Chi Li het woord is aan u";
        yield return new WaitForSeconds(1f);
        textWolk.text = "Ik arriveerde ongeveer 5 min voordat de koks kwamen. Ik ging niet door de niet afgesloten deur naar binnen maar ik zag wel dat het licht in de keuken aan is. Ik besloot om meteen aan het werk te gaan en deed het deur naar het restaurantgedeelte van het slot, zette een decoratieboom buiten en ging mij opmaken in het toilet. Toen hoorde ik de koks binnenkomen en tegen elkaar zeggen dat de gokkast was opengebroken. Ik hoorde toen een van de koks heel hard gillen en besloot mij te verstoppen in de wc. Toen ik hoorde dat oma Zhang ‘neer ligt’ rende ik in paniek naar buiten en ging naar het huis van de eigenaar Zhang om op de kinderen te passen.";
        playerUnit.TakeDamage(2); // Hierbij zeg je dus 2 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Chi Li";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

}
