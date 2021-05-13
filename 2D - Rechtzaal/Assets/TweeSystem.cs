using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject GPrefab13;
    public GameObject GPrefab14;
    public GameObject GPrefab15;
    public GameObject GPrefab16;
    public GameObject GPrefab17;
    public GameObject GPrefab18;
    

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

    int PT;
    int G1;
    int G2 = 0;
    int G3;

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


            dialogueText.text = "De advocaat van de verdachte mag nu drie getuigen oproepen";
            yield return new WaitForSeconds(3f);


            UI.ButtonOff();
            UI.GetuigenOn();
            // Getuigen 1 --------------------------------------------------------------------
            yield return new WaitForSeconds(1f);
            GameObject GE1 = Instantiate(GPrefab12, GetuigenBattleStation); // Klopt nog niet
            dialogueText.text = playerUnit.unitName + " kiest om Mr Zhang te verhoren"; //hier moet de naam nog bij
            yield return new WaitForSeconds(1f);
            dialogueText.text = "Mr Zhang het woord is aan u"; // idem
            yield return new WaitForSeconds(1f);
            textWolk.text = ""; // hier komt zijn verhaal
            playerUnit.TakeDamage(-5); // Hierbij zeg je dus 10 damage. Dit is makkelijker dan dat gezeik via de prefab.
            battleScore.SetScore(playerUnit.score); // update de slider
            dialogueText.text = "Bedankt Mr Zhang"; // update
            Destroy(GE1); 

            yield return new WaitForSeconds(3f);


            // Getuigen 2 --------------------------------------------------------------------
            dialogueText.text = "De advocaat van de verdachte mag nu een tweede getuigen oproepen";
            yield return new WaitForSeconds(1f);
            GameObject GE2 = Instantiate(GPrefab13, GetuigenBattleStation); // Klopt nog niet
            dialogueText.text = playerUnit.unitName + " kiest om dingdong te verhoren"; //hier moet de naam nog bij
            yield return new WaitForSeconds(1f);
            dialogueText.text = "Mr dingdong het woord is aan u"; // idem
            yield return new WaitForSeconds(1f);
            textWolk.text = ""; // hier komt zijn verhaal
            playerUnit.TakeDamage(-5); // Hierbij zeg je dus 10 damage. Dit is makkelijker dan dat gezeik via de prefab.
            battleScore.SetScore(playerUnit.score); // update de slider
            dialogueText.text = "Bedankt Mr dingdong"; // update
            Destroy(GE2);
            yield return new WaitForSeconds(3f);

            // Getuigen 3--------------------------------------------------------------------
            dialogueText.text = "De advocaat van de verdachte mag nu de derde getuigen oproepen";
            yield return new WaitForSeconds(1f);
            GameObject GE3 = Instantiate(GPrefab14, GetuigenBattleStation); // Klopt nog niet
            dialogueText.text = playerUnit.unitName + " kiest om appelsap te verhoren"; //hier moet de naam nog bij
            yield return new WaitForSeconds(1f);
            dialogueText.text = "Mr appelsap het woord is aan u"; // idem
            yield return new WaitForSeconds(1f);
            textWolk.text = ""; // hier komt zijn verhaal
            playerUnit.TakeDamage(-5); // Hierbij zeg je dus 10 damage. Dit is makkelijker dan dat gezeik via de prefab.
            battleScore.SetScore(playerUnit.score); // update de slider
            dialogueText.text = "Bedankt Mr appelsap"; // update
            Destroy(GE3);
            yield return new WaitForSeconds(3f);

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

            state = BattleState.PLAYERTURN;
            StartCoroutine(PlayerTurn());
        } else
                
        if (PT == 4)
        {
            state = BattleState.PLAYERTURN;
            StartCoroutine(PlayerTurn());
        }

    }

    IEnumerator EndDag1()
    {
        dialogueText.text = "Dit was de eerste zitting";
        UI.GetuigenOff();
        yield return new WaitForSeconds(5f);
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
            
        } else if (G1 >= 0)
        {
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
    public void OnGetuigen13()
    {
        if (state != BattleState.PLAYERTURN || G1 == 13 || G2 == 13)
        {
            return;
        }
        else 
        if (G1 == 0)
        {
            G1 = 13;
            StartCoroutine(PlayerGetuigen13());
        }   
        else    
        if (G2 == 0)
        {
            G2 = 13;
            StartCoroutine(PlayerGetuigen13());
        }
        else
        if (G2 != 0)
        {
            G3 = 13;
            StartCoroutine(PlayerGetuigen13());
        }
        else
            StartCoroutine(PlayerGetuigen13()); // pause during attack
    }
    public void OnGetuigen14()
    {
        if (state != BattleState.PLAYERTURN || G1 == 14 || G2 == 14)
        {
            return;
        }
        else

        if (G1 == 0)
        {
            G1 = 14;
            StartCoroutine(PlayerGetuigen14());
        }
        else
        if (G2 == 0)
        {
            G2 = 14;
            StartCoroutine(PlayerGetuigen14());
        }
        else
        if (G2 != 0)
        {
            G3 = 14;
            StartCoroutine(PlayerGetuigen14());
        }
        else
            StartCoroutine(PlayerGetuigen14()); // pause during attack
    }
    public void OnGetuigen15()
    {
        if (state != BattleState.PLAYERTURN || G1 == 15 || G2 == 15)
        {
            return;
        }
        else

         if (G1 == 0)
        {
            G1 = 15;
            StartCoroutine(PlayerGetuigen15());
        }
        else
         if (G2 == 0)
        {
            G2 = 15;
            StartCoroutine(PlayerGetuigen15());
        }
        else
        if (G2 != 0)
        {
            G3 = 15;
            StartCoroutine(PlayerGetuigen15());
        }
        else
            StartCoroutine(PlayerGetuigen15()); // pause during attack
    }
    public void OnGetuigen16()
    {
        if (state != BattleState.PLAYERTURN || G1 == 16 || G2 == 16)
        {
            return;
        }
        else

        if (G1 == 0)
        {
            G1 = 16;
            StartCoroutine(PlayerGetuigen16());
        }
        else
        if (G2 == 0)
        {
            G2 = 16;
            StartCoroutine(PlayerGetuigen16());
        }
        else
        if (G2 != 0)
        {
            G3 = 16;
            StartCoroutine(PlayerGetuigen16());
        }
        else
            StartCoroutine(PlayerGetuigen16()); // pause during attack
    }
    public void OnGetuigen17()
    {
        if (state != BattleState.PLAYERTURN || G1 == 17 || G2 == 17)
        {
            return;
        }
        else

        if (G1 == 0)
        {
            G1 = 17;
            StartCoroutine(PlayerGetuigen17());
        }
        else
        if (G2 == 0)
        {
            G2 = 17;
            StartCoroutine(PlayerGetuigen17());
        }
        else
        if (G2 != 0)
        {
            G3 = 17;
            StartCoroutine(PlayerGetuigen17());
        }
        else
            StartCoroutine(PlayerGetuigen17()); // pause during attack
    }
    public void OnGetuigen18()
    {
        if (state != BattleState.PLAYERTURN || G1 == 18 || G2 == 18)
        {
            return;
        }
        else

        if (G1 == 0)
        {
            G1 = 18;
            StartCoroutine(PlayerGetuigen18());
        }
        else
        if (G2 == 0)
        {
            G2 = 18;
            StartCoroutine(PlayerGetuigen18());
        }
        else
        if (G2 != 0)
        {
            G3 = 18;
            StartCoroutine(PlayerGetuigen18());
        }
        else
            StartCoroutine(PlayerGetuigen18()); // pause during attack
    }

    IEnumerator PlayerGetuigen1()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Joyce te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = " Joyce het woord is aan u";
        yield return new WaitForSeconds(1f);
        textWolk.text = " Ik ben op maandagavond 5 juli 1993 bedreigd door Ali, Aldo en Abdoel. Ze hebben mij heel erg duidelijk gemaakt dat ik mijn mond moest houden over wat ik had gezien bij Golden Garden. Abdoel trok een wapen, ik schrok me dood. Er zijn al sinds het begin problemen tussen de jongens en mij. Ze drongen mijn kamer binnen en namen spullen of geld mee. Elke keer heb ik aangifte hiervan gedaan bij de politie. Nadat de jongens een keer mijn hele kamer kort en klein hadden geslagen, ben ik verhuisd. Ik denk dat Julie de jongens heeft geholpen om mij uit mijn kamer te zetten. Toen ik verhuisde naar een andere woning op de Oudeweg, toen vonden de jongens mij weer. Clarissa had namelijk het adres doorgegeven.";
        playerUnit.TakeDamage(10); // Hierbij zeg je dus 10 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Joyce";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        if (G3 != 0)
        {
            StartCoroutine(EndDag1());
        }
        else
            StartCoroutine(PlayerTurn());
    }
    IEnumerator PlayerGetuigen2()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Clarissa te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Mw Huang het woord is aan u";
        yield return new WaitForSeconds(1f);
        textWolk.text = " De jongens die vaak langskomen bij ons op de Oudeweg hebben de boel helemaal verziekt. Ze hebben zelf op Linda en Mandy geschoten en de spullen van Joyce kapot gemaakt! Ik heb nooit echt een gelijkwaardige vriendschap met Joyce gehad. Ik durfde niets te zeggen tegen Joyce, laat staan haar tegen praten. Ze is nogal moeilijk te ontwijken. Joyce praat wel vaker niet de waarheid en dat hebben we ook tegen de huisbaas gezegd om te laten weten wat er aan de hand is.";
        playerUnit.TakeDamage(10); // Hierbij zeg je dus 10 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Clarissa";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        if (G3 != 0)
        {
            StartCoroutine(EndDag1());
        }
        else
            StartCoroutine(PlayerTurn());
    }
    IEnumerator PlayerGetuigen3()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Julia te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Julia het woord is aan u";
        yield return new WaitForSeconds(1f);
        textWolk.text = "Wat er allemaal op de Oudeweg is gebeurd is voor mij echt het meest schokkende wat ik ooit heb meegemaakt. Ik denk dat de andere meiden echt door het huis zijn gecommandeerd door Aldo, Ali. Abdoel deed niks, hij gedraagt zich gewoon.";
        playerUnit.TakeDamage(7); // Hierbij zeg je dus 10 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Julia";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        if (G3 != 0)
        {
            StartCoroutine(EndDag1());
        }
        else
            StartCoroutine(PlayerTurn());
    }
    IEnumerator PlayerGetuigen4()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Davey Kok te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Davey Kok het woord is aan u";
        yield return new WaitForSeconds(1f);
        textWolk.text = "Soms als de jongens langs kwamen op de Oudeweg, dan terroriseerde de 3 jongens de meisjes. Ik heb ook het idee dat Linda door een van hen wordt mishandeld met stroomschokken. Joyce en Linda zijn door de jongens met de dood bedreigd zijn, althans dat is wat ik vernomen had.";
        playerUnit.TakeDamage(2); // Hierbij zeg je dus 10 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Davey Kok";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        if (G3 != 0)
        {
            StartCoroutine(EndDag1());
        }
        else
            StartCoroutine(PlayerTurn());
    }
    IEnumerator PlayerGetuigen5()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Linda te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Linda het woord is aan u";
        yield return new WaitForSeconds(1f);
        textWolk.text = "Ik was erbij toen Joyce werd bedreigd met een pistool door Abdoel, maar dit was niet op maandag 5 juli. Het was sowieso op een andere dag. Joyce is wel vaker bedreigd door de jongens. Ik heb het meerdere keren meegemaakt en een keer hadden de jongens zich opgesloten in Joyce’s kamer en toen gingen ze haar spullen kapot maken. Ze gooiden haar ruiten in en schreven het woord stinkdier op de muren. Uiteindelijk is ze maar verhuist. Julia en de jongens hebben altijd ruzie. Ze komt alleen naar ons huis als ze Mandy bezoekt. Ik denk wel dat Julia een oogje heeft op Abdoel, al snap ik niet waarom. Joyce is bij niemand echt geliefd. We hebben ook een keer met de meiden tegen de huisbaas gezegd dat ze soms liegt.";
        playerUnit.TakeDamage(2); // Hierbij zeg je dus 0 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Linda";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        if (G3 != 0)
        {
            StartCoroutine(EndDag1());
        }
        else
            StartCoroutine(PlayerTurn());
    }
    IEnumerator PlayerGetuigen6()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Mandy te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Mandy het woord is aan u";
        yield return new WaitForSeconds(1f);
        textWolk.text = "Ik ben doodsbang voor de jongens, vooral voor Ali toen hij een mes op mijn keel zette en me met de dood bedreigde. Ik ben niet in mijn eentje uit geweest toen ik nog met Ali had, dat mocht niet van hem. Toen ik dacht dat Ali iets te maken had met de moord op die oma in Golden Garden, wilde ik niks meer met hem te maken hebben maar ik durfde niets te doen. Ik weet dat ik niet goed lig met de jongens en dat ik een keer geruimd zal worden en iedereen weet dat. Samen met de meiden heb ik met de huisbaas over Joyce gesproken. Ze liegt namelijk vaak en praat niet de waarheid maar niemand durft daar iets aan te doen.";
        playerUnit.TakeDamage(4); // Hierbij zeg je dus 3 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Mandy";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        if (G3 != 0)
        {
            StartCoroutine(EndDag1());
        }
        else
            StartCoroutine(PlayerTurn());
    }
    IEnumerator PlayerGetuigen7()
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
        if (G3 != 0)
        {
            StartCoroutine(EndDag1());
        }
        else
            StartCoroutine(PlayerTurn());

    }
    IEnumerator PlayerGetuigen8()
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
        if (G3 != 0)
        {
            StartCoroutine(EndDag1());
        }
        else
            StartCoroutine(PlayerTurn());

    }
    IEnumerator PlayerGetuigen9()
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
        if (G3 != 0)
        {
            StartCoroutine(EndDag1());
        }
        else
            StartCoroutine(PlayerTurn());

    }
    IEnumerator PlayerGetuigen10()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Abdoel te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Abdoel het Woord is aan u.";
        yield return new WaitForSeconds(1f);
        textWolk.text = "Op 3 juli 1993 waren mijn vrouw en ik in Tongeren in België omdat wij daar een nieuw restaurant hadden ";
        playerUnit.TakeDamage(-2); // Hierbij zeg je dus -2 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Abdoel";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        if (G3 != 0)
        {
            StartCoroutine(EndDag1());
        }
        else
            StartCoroutine(PlayerTurn());
    }
    IEnumerator PlayerGetuigen11()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Ali te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Ali het woord is aan u.";
        yield return new WaitForSeconds(1f);
        textWolk.text = "Ik heb het niet gedaan, ik was sowieso die hele avond gewoon op de Oudeweg. ";
        playerUnit.TakeDamage(2); // Hierbij zeg je dus 2 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Ali";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        if (G3 != 0)
        {
            StartCoroutine(EndDag1());
        }
        else
            StartCoroutine(PlayerTurn());
    }
    IEnumerator PlayerGetuigen12()
    {
        yield return new WaitForSeconds(1f);
        UI.ListOff(); // Deze zet de lijst met getuigen uit
        UI.GetuigenOn(); // deze zet de getuigen UI (textwolk enzo aan)
        Instantiate(GPrefab1, GetuigenBattleStation); // dit laad het gameobject GPrefab1 erin. Die heb ik vervolgens weer toegekend aan het plaatje van mister zhang
        dialogueText.text = playerUnit.unitName + " kiest om Aldo te verhoren";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Aldo het woord is aan u";
        yield return new WaitForSeconds(1f);
        textWolk.text = "Ik ben onschuldig, ik was uit met Jennifer en haar vriendin.";
        playerUnit.TakeDamage(-5); // Hierbij zeg je dus 10 damage. Dit is makkelijker dan dat gezeik via de prefab.
        battleScore.SetScore(playerUnit.score);
        dialogueText.text = "Bedankt Aldo";
        yield return new WaitForSeconds(3f);
        UI.GetuigenOff(); // hiermee zet in de getuign ui weer uit, wss staat de getuigen er wel nog als ik m straks weer laad
        if (G3 != 0)
        {
            StartCoroutine(EndDag1());
        }
        else
            StartCoroutine(PlayerTurn());
    }
}
