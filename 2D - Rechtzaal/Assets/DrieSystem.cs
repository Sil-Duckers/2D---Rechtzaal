using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public enum BattleState { START, PLAYERTURN, ENEMYTURN, END}

public class DrieSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    

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
    int G1; /*
    int G2 = 0;
    int G3;
    */

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

        dialogueText.text = "Welkom bij de derde zitting in de zaak: De zes van Breda" + "\r\n";
         // Dit is voor de void uit te oefenen
        
        yield return new WaitForSeconds(1f); //coroutine, 5 seconde delay 
        playerUnit.score = Score.HScore;
        battleScore.SetSlider(playerUnit);
        state = BattleState.PLAYERTURN; // verander state naar volgende
        StartCoroutine(PlayerTurn()); // functie PlayerTurn uitoefenen
    }

    IEnumerator PlayerAttack1()
    {   // Aanval 1
        if (PT == 0)
        {
            dialogueText.text = playerUnit.unitName + "zegt " + "Het OM is er van overtuigd dat Ali, Abdoel, Aldo, Julia, Joyce en Clarissa daders zijn van de moord op oma Zhang.";
            yield return new WaitForSeconds(1f);

            int isDead = playerUnit.TakeDamage(10); // Start de TakeDamage funcite (aantal damage komt van player)
            battleScore.SetScore(playerUnit.score);
                        yield return new WaitForSeconds(1f);
            dialogueText.text = "Kies het volgende gedeelte van het starpleidooi.";
            Button1.text = "Het dagboekfragment van Jennifer is vervalst en pleit niet voor Aldo’s alibi.";
            Button2.text = "De verklaring van Annabel plaatst Abdoel in Sittard, terwijl meerdere getuigen verklaren dat hij in Breda was.";
            Button3.text = "De brief van Ting bewijst dat Ali, Abdoel en Aldo aanwezig waren in Breda.";
            PT += 1;
        } else if (PT == 1)
        {
            dialogueText.text = playerUnit.unitName + "zegt " + "Op basis van het verhaal van de patholoog-anatoom en de recherches …";
            yield return new WaitForSeconds(1f);

            int isDead = playerUnit.TakeDamage(5); // Start de TakeDamage funcite (aantal damage komt van player)
            battleScore.SetScore(playerUnit.score);
            
            yield return new WaitForSeconds(1f);
            dialogueText.text = "Kies het volgende gedeelte van het starpleidooi.";
            Button1.text = "Daarom eist het OM voor alle verdachten een gevangenisstraf van ten minste 10 jaar onvoorwaardelijk. ";
            Button2.text = "Daarom eist het OM voor alle verdachten een gevangenisstraf van ten minste 5 jaar onvoorwaardelijk.";
            Button3.text = "Daarom eist het OM voor Ali, Abdoel en Aldo een gevangenisstraf van ten minste 10 jaar onvoorwaardelijk en voor Julia, Joyce en Clarissa eist het OM ten minste 2 jaar onvoorwaardelijk.";
            PT += 1;
        } else if (PT == 2)
        {
            dialogueText.text = playerUnit.unitName + "zegt " + "en op basis van de huidige wetboeken eist het OM voor alle verdachten een gevangenisstraf van ten minste 15 jaar onvoorwaardelijk.";
            yield return new WaitForSeconds(1f);

            int isDead = playerUnit.TakeDamage(0); // Start de TakeDamage funcite (aantal damage komt van player)
            battleScore.SetScore(playerUnit.score);
            
            yield return new WaitForSeconds(1f);
            dialogueText.text = "Dit was het starpleidooi.";
            Button1.text = "";
            Button2.text = "";
            Button3.text = "";
            PT += 1;

            state = BattleState.ENEMYTURN;
            StartCoroutine(EndDag1());
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

            int isDead = playerUnit.TakeDamage(5); // Start de TakeDamage funcite (aantal damage komt van player)
            battleScore.SetScore(playerUnit.score);
            
            
            yield return new WaitForSeconds(1f);
            dialogueText.text = "Kies het volgende gedeelte van het starpleidooi.";
            Button1.text = "Het dagboekfragment van Jennifer is vervalst en pleit niet voor Aldo’s alibi.";
            Button2.text = "De verklaring van Annabel plaatst Abdoel in Sittard, terwijl meerdere getuigen verklaren dat hij in Breda was.";
            Button3.text = "De brief van Ting bewijst dat Ali, Abdoel en Aldo aanwezig waren in Breda.";
            PT += 1;
        }
        else if (PT == 1)
        {
            dialogueText.text = playerUnit.unitName + "zegt " + "Op basis van het verhaal van Mw. Boonstra en het dagboekfragment van Jennifer … ";
            yield return new WaitForSeconds(1f);

            int isDead = playerUnit.TakeDamage(10); // Start de TakeDamage funcite (aantal damage komt van player)
            battleScore.SetScore(playerUnit.score);
            
            
            yield return new WaitForSeconds(1f);
            dialogueText.text = "Kies het volgende gedeelte van het starpleidooi.";
            Button1.text = "Daarom eist het OM voor alle verdachten een gevangenisstraf van ten minste 10 jaar onvoorwaardelijk. ";
            Button2.text = "Daarom eist het OM voor alle verdachten een gevangenisstraf van ten minste 5 jaar onvoorwaardelijk.";
            Button3.text = "Daarom eist het OM voor Ali, Abdoel en Aldo een gevangenisstraf van ten minste 10 jaar onvoorwaardelijk en voor Julia, Joyce en Clarissa eist het OM ten minste 2 jaar onvoorwaardelijk.";
            PT += 1;
        }
        else if (PT == 2)
        {
            dialogueText.text = playerUnit.unitName + "zegt " + "en op basis van de huidige wetboeken eist het OM voor alle verdachten een gevangenisstraf van ten minste 10 jaar voorwaardelijk.";
            yield return new WaitForSeconds(1f);

            int isDead = playerUnit.TakeDamage(0); // Start de TakeDamage funcite (aantal damage komt van player)
            battleScore.SetScore(playerUnit.score);
            
            
            yield return new WaitForSeconds(1f);
            dialogueText.text = "Dit was het starpleidooi.";
            Button1.text = "";
            Button2.text = "";
            Button3.text = "";
            PT += 1;

            state = BattleState.ENEMYTURN;
            StartCoroutine(EndDag1());
        } 

    }
    IEnumerator PlayerAttack3()
    {   // Aanval 3
        if (PT == 0)
        {
            dialogueText.text = playerUnit.unitName + "zegt " + "Het OM is er van overtuigd dat Ali, Abdoel, Aldo, Julia, Joyce en Clarissa onschuldig zijn. ";
            yield return new WaitForSeconds(1f);

            int isDead = playerUnit.TakeDamage(5); // Start de TakeDamage funcite (aantal damage komt van player)
            battleScore.SetScore(playerUnit.score);
           
            yield return new WaitForSeconds(1f);
            dialogueText.text = "Kies het volgende gedeelte van het starpleidooi.";
            Button1.text = "Het dagboekfragment van Jennifer is vervalst en pleit niet voor Aldo’s alibi.";
            Button2.text = "De verklaring van Annabel plaatst Abdoel in Sittard, terwijl meerdere getuigen verklaren dat hij in Breda was.";
            Button3.text = "De brief van Ting bewijst dat Ali, Abdoel en Aldo aanwezig waren in Breda.";
            PT += 1;
        }
        else if (PT == 1)
        {
            dialogueText.text = playerUnit.unitName + "zegt " + "Op basis van de verklaringen van Joyce, Clarissa en Julia …";
            yield return new WaitForSeconds(1f);

            int isDead = playerUnit.TakeDamage(0); // Start de TakeDamage funcite (aantal damage komt van player)
            battleScore.SetScore(playerUnit.score);
            
            
            yield return new WaitForSeconds(1f);
            dialogueText.text = "Kies het volgende gedeelte van het starpleidooi.";
            Button1.text = "Daarom eist het OM voor alle verdachten een gevangenisstraf van ten minste 10 jaar onvoorwaardelijk. ";
            Button2.text = "Daarom eist het OM voor alle verdachten een gevangenisstraf van ten minste 5 jaar onvoorwaardelijk.";
            Button3.text = "Daarom eist het OM voor Ali, Abdoel en Aldo een gevangenisstraf van ten minste 10 jaar onvoorwaardelijk en voor Julia, Joyce en Clarissa eist het OM ten minste 2 jaar onvoorwaardelijk.";
            PT += 1;
        }
        else if (PT == 2)
        {
            dialogueText.text = playerUnit.unitName + "zegt " + "en op basis van de huidige wetboeken eist het OM voor Ali, Abdoel en Aldo een gevangenisstraf van ten minste 15 jaar onvoorwaardelijk en voor Julia, Joyce en Clarissa eist het OM ten minste 5 jaar onvoorwaardelijk.";
            yield return new WaitForSeconds(1f);

            int isDead = playerUnit.TakeDamage(10); // Start de TakeDamage funcite (aantal damage komt van player)
            battleScore.SetScore(playerUnit.score);
            
            yield return new WaitForSeconds(1f);
            dialogueText.text = "Dit was het slotleidooi.";
            Button1.text = "";
            Button2.text = "";
            Button3.text = "";
            PT += 1;

            state = BattleState.ENEMYTURN;
            StartCoroutine(EndDag1());
        } 
    }
    
    IEnumerator EnemyTurn()
    {
        if (PT == 3)
        {
            dialogueText.text = enemyUnit.unitName + " verteld zijn slotpleidooi."; // Aangeven van aanval
            yield return new WaitForSeconds(1f);

            dialogueText.text = enemyUnit.unitName + "Geachte Hof, mijn cliënten zijn onschuldig. Dit redeneren wij op basis van verklaringen en sporenonderzoek. " + "Mijn cliënten zijn onschuldig";
            yield return new WaitForSeconds(1f);

            dialogueText.text = enemyUnit.unitName + "De verklaringen van Jennifer en Annabel bevestigen duidelijk dat geen van mijn cliënten in Breda waren op het moment van deze afgrijselijke moord. " + "Het sporenonderzoek van de politie laat geen relatie zien tussen mijn cliënten en de moord op oma Zhang.";
            yield return new WaitForSeconds(1f);

            dialogueText.text = enemyUnit.unitName + "Het sporenonderzoek van Mw. Evers laat zien dat er absoluut geen relatie is tussen de gevonden sporen op het plaats delict en mijn cliënten, zij zijn onschuldig. " + "De verklaring van Annabel plaats mijn cliënten niet op de plaats en tijd van de moord, dus zij kunnen het niet gedaan hebben.";
            yield return new WaitForSeconds(1f);


            dialogueText.text = "Dit was het slotpleidooi van de Advocaat";
            int isDead = playerUnit.TakeDamage(enemyUnit.OP1A); // damage de player
            battleScore.SetScore(playerUnit.score); //playerHUD.SetHP, slider verzetten
            yield return new WaitForSeconds(1f);
            PT = 4;

            /*
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
            */
        }
    }

    IEnumerator EndDag1()
    {
        UI.GetuigenOff();
        dialogueText.text = "Het is nu tijd voor het eindvonnis";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "beetje tussenin. We hebben nog nietecht bepaald wat hier moet vgm";
        yield return new WaitForSeconds(5f);
        dialogueText.text = "Dit was de derde en laatste zittingzitting";
        
        yield return new WaitForSeconds(5f);
    }

    IEnumerator PlayerTurn()
    {
            dialogueText.text = "Het is tijd voor het slot van het OM" + "\r\n" + "Kies een slotpleidooi";
            Button1.text = "De verklaringen van Joyce, Clarissa en Julia bevestigen dat de meisjes geen actieve rol in de moord hebben gespeeld maar alleen medeplichtig zijn.";
            Button2.text = "De verklaringen van Mw. Boonstra plaatst de verdachten allemaal rond het tijdstip van de moord in Breda.";
            Button3.text = "De verklaringen van koks van Golden Garden bevestigd onze verdenkingen.";
        yield return new WaitForSeconds(1f);
            // Vanuit hier ga je dus naar de player attack als je op de knop drukt
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
    
   
}
