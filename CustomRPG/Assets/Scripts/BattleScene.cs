using UnityEngine;
using UnityEngine.UI;

//The Script of the battle scene
public class BattleScene : MonoBehaviour
{
    CharacterReader characterReader;
    CharacterInfoManager characterInfo;
    GameManager gameManager;
    HUDControl hudControl;
    //Arrays of the move & enemy option boxes, enemy infomation boxes, text boxes in the enemy info boxes and buttons 
    public GameObject[] optionBoxes;
    public GameObject[] infoBoxes;
    public Text[] infoBoxesNameText;
    public Text[] infoBoxesMainText;
    public Button[] Buttons;
    public Text infoText;
    //Number of enemies
    public int enemies;
    //Number of defeated enemies
    public int enemiesdefeated;
    //The attack & target chooen by the player
    public int selectedAttack;
    public int playerTarget;
    //The target chooen by the enemy
    public int target;
    //The order that everyone in the battle attacks
    public int[] turnOrder;
    void Start()
    {
        characterReader = GetComponent<CharacterReader>();
        characterInfo = GetComponent<CharacterInfoManager>();
        gameManager = FindObjectOfType<GameManager>();
        hudControl = GetComponent<HUDControl>();
    }
    public void LoadMoves()
    {
        //Loads the players move in
        for (int i = 0; i < 4; i++)
        {
            Buttons[i].GetComponentInChildren<Text>().text = characterReader.character[0].moveInfo.m_Move[i].name;
        }
    }
    public void initializeFight()
    {
        //Choose a random number of enemies
        enemies = Random.Range(1, 5);
        //Give each of the enemies their Class, Subclass, Moves and Cores
        //Works in a simmilar fashion to the Character Loader
        for (int x = 4; x < 4 + enemies; x++)
        {
            characterReader.character[x].m_Class = characterInfo.classes[Random.Range(0, characterInfo.classes.Length - 1)];
            characterReader.character[x].m_Subclass = characterInfo.subclasses[Random.Range(0, characterInfo.subclasses.Length - 1)];
            for (int i = 0; i < 4; i++)
            {
                characterReader.character[x].moveInfo.m_Move[i] = characterInfo.moves[Random.Range(0, characterInfo.moves.Length - 1)];
                characterReader.character[x].moveInfo.m_MoveCoreCount[i] = Random.Range(0, 4);
                for (int a = characterReader.character[x].moveInfo.m_MoveCoreCount[i]; a > 0; a--)
                {
                    Debug.Log(a);
                    switch (a)
                    {
                        case 1:
                            characterReader.character[x].moveInfo.m_MoveCore1[i] = characterInfo.cores[Random.Range(0, characterInfo.cores.Length - 1)];
                            //Debug.Log("11Current Index - " + m_CurrentIndex);
                            break;
                        case 2:
                            characterReader.character[x].moveInfo.m_MoveCore2[i] = characterInfo.cores[Random.Range(0, characterInfo.cores.Length - 1)];
                            //Debug.Log("12Current Index - " + m_CurrentIndex);
                            break;
                        case 3:
                            characterReader.character[x].moveInfo.m_MoveCore3[i] = characterInfo.cores[Random.Range(0, characterInfo.cores.Length - 1)];
                            //Debug.Log("13Current Index - " + m_CurrentIndex);
                            break;
                        default:
                            Debug.Log("ILLIGAL CHARACTER. ABORTING");
                            Application.Quit();
                            return;
                    }
                }
            }
            characterReader.character[x].HP = Mathf.RoundToInt(characterReader.character[x].m_Class.HP);
            characterReader.character[x].baseDamage = Mathf.RoundToInt(characterReader.character[x].m_Class.baseDamage);
            characterReader.character[x].defence = Mathf.RoundToInt(characterReader.character[x].m_Class.defence);
            characterReader.character[x].speed = Mathf.RoundToInt(characterReader.character[x].m_Class.speed);
            characterReader.character[x].m_CharacterName = "Enemy " + characterReader.character[x].m_Subclass.name + " " + characterReader.character[x].m_Class.name;
            //For each enemy, enable a button & infobox
            Buttons[x].gameObject.SetActive(true);
            Debug.Log(x);
            infoBoxes[x - 4].SetActive(true);
        }
        //Update the info boxes and player HUD
        updateInfoBoxes();
        hudControl.setupHUD();
    }
    //Run if the first move is selected
    public void selectFirstAttack()
    {
        //If the move does not need a target, skip choosing a target
        selectedAttack = 0;
        if (characterReader.character[0].moveInfo.m_Move[selectedAttack].moveType == MovesSO.MoveType.status && characterReader.character[0].moveInfo.m_Move[selectedAttack].effectTarget == false)
        {
            playerTarget = 0;
            setTurnOrder();
        }
        else
        {
            infoText.text = "Select a target.";
            chooseTarget();
        }

    }
    //Run if the Second move is selected
    public void selectSecondAttack()
    {
        //If the move does not need a target, skip choosing a target
        selectedAttack = 1;
        if (characterReader.character[0].moveInfo.m_Move[selectedAttack].moveType == MovesSO.MoveType.status && characterReader.character[0].moveInfo.m_Move[selectedAttack].effectTarget == false)
        {
            playerTarget = 0;
            setTurnOrder();
        }
        else
        {
            infoText.text = "Select a target.";
            chooseTarget();
        }
    }
    //Run if the Third move is selected
    public void selectThirdAttack()
    {
        //If the move does not need a target, skip choosing a target
        selectedAttack = 2;
        if (characterReader.character[0].moveInfo.m_Move[selectedAttack].moveType == MovesSO.MoveType.status && characterReader.character[0].moveInfo.m_Move[selectedAttack].effectTarget == false)
        {
            playerTarget = 0;
            setTurnOrder();
        }
        else
        {
            infoText.text = "Select a target.";
            chooseTarget();
        }
    }
    //Run if the Fourth move is selected
    public void selectFourthAttack()
    {
        //If the move does not need a target, skip choosing a target
        selectedAttack = 3;
        if (characterReader.character[0].moveInfo.m_Move[selectedAttack].moveType == MovesSO.MoveType.status && characterReader.character[0].moveInfo.m_Move[selectedAttack].effectTarget == false)
        {
            playerTarget = 0;
            setTurnOrder();
        }
        else
        {
            infoText.text = "Select a target.";
            chooseTarget();
        }
    }
    //Choose a target then set the turn order
    public void selectFirstTarget()
    {
        playerTarget = 4;
        setTurnOrder();
    }
    public void selectSecondTarget()
    {
        playerTarget = 5;
        setTurnOrder();
    }
    public void selectThirdTarget()
    {
        playerTarget = 6;
        setTurnOrder();
    }
    public void selectFourthTarget()
    {
        playerTarget = 7;
        setTurnOrder();
    }
    public void CastAttack(int sender, int target)
    {
        int damage = 0;
        //Check the type of move sent
        switch (characterReader.character[sender].moveInfo.m_Move[selectedAttack].moveType)
        {
            case MovesSO.MoveType.phyical:
                //int rnd = Mathf.FloorToInt((Random.Range(10, 21)) / 10);
                damage = (Mathf.FloorToInt(Mathf.RoundToInt(characterReader.character[sender].baseDamage * characterReader.character[sender].moveInfo.m_Move[selectedAttack].damage / 2) / characterReader.character[target].defence));
                Debug.Log("The damage is " + damage);
                characterReader.character[target].HP -= damage;
                infoText.text = (characterReader.character[sender].m_CharacterName + " used " + characterReader.character[sender].moveInfo.m_Move[selectedAttack].name + "!\n" + characterReader.character[target].m_CharacterName + " took " + damage.ToString() + " damage.");
                break;
            case MovesSO.MoveType.magical:
                damage = (Mathf.FloorToInt(Mathf.RoundToInt((characterReader.character[sender].moveInfo.m_Move[selectedAttack].damage * 3) / characterReader.character[target].defence)));
                Debug.Log("The damage is " + damage);
                characterReader.character[target].HP -= damage;
                infoText.text = (characterReader.character[sender].m_CharacterName + " used " + characterReader.character[sender].moveInfo.m_Move[selectedAttack].name + "!\n" + characterReader.character[target].m_CharacterName + " took " + damage.ToString() + " damage.");
                break;
            case MovesSO.MoveType.status:
                //Check if the move targets a target or the caster
                switch (characterReader.character[sender].moveInfo.m_Move[selectedAttack].effectTarget)
                {
                    case false:
                        //Check the stat boosted & boost that stat on the sender
                        switch (characterReader.character[sender].moveInfo.m_Move[selectedAttack].boostStat)
                        {
                            case MovesSO.stats.HP:
                                characterReader.character[sender].HP += characterReader.character[sender].moveInfo.m_Move[selectedAttack].boostAmmount;
                                break;
                            case MovesSO.stats.baseDamage:
                                characterReader.character[sender].baseDamage += characterReader.character[sender].moveInfo.m_Move[selectedAttack].boostAmmount;
                                break;
                            case MovesSO.stats.defence:
                                characterReader.character[sender].defence += characterReader.character[sender].moveInfo.m_Move[selectedAttack].boostAmmount;
                                break;
                            case MovesSO.stats.speed:
                                characterReader.character[sender].speed += characterReader.character[sender].moveInfo.m_Move[selectedAttack].boostAmmount;
                                break;
                        }
                        infoText.text = (characterReader.character[sender].m_CharacterName + " used " + characterReader.character[sender].moveInfo.m_Move[selectedAttack].name + ".\n" + characterReader.character[sender].m_CharacterName + " receved " + characterReader.character[sender].moveInfo.m_Move[selectedAttack].boostAmmount + " to " + characterReader.character[sender].moveInfo.m_Move[selectedAttack].boostStat + "!");
                        break;
                    case true:
                        //Check the stat boosted & boost that stat on the target
                        switch (characterReader.character[sender].moveInfo.m_Move[selectedAttack].boostStat)
                        {
                            case MovesSO.stats.HP:
                                characterReader.character[target].HP += characterReader.character[sender].moveInfo.m_Move[selectedAttack].boostAmmount;
                                break;
                            case MovesSO.stats.baseDamage:
                                characterReader.character[target].baseDamage += characterReader.character[sender].moveInfo.m_Move[selectedAttack].boostAmmount;
                                break;
                            case MovesSO.stats.defence:
                                characterReader.character[target].defence += characterReader.character[sender].moveInfo.m_Move[selectedAttack].boostAmmount;
                                break;
                            case MovesSO.stats.speed:
                                characterReader.character[target].speed += characterReader.character[sender].moveInfo.m_Move[selectedAttack].boostAmmount;
                                break;
                        }
                        infoText.text = (characterReader.character[sender].m_CharacterName + " used " + characterReader.character[sender].moveInfo.m_Move[selectedAttack].name + ".\n" + characterReader.character[target].m_CharacterName + " receved " + characterReader.character[sender].moveInfo.m_Move[selectedAttack].boostAmmount + " to " + characterReader.character[sender].moveInfo.m_Move[selectedAttack].boostStat + "!");
                        break;
                }
                break;
        }
        //Update the HUD and run a death check
        hudControl.setupHUD();
        updateInfoBoxes();
        DeathCheck(target);
        chooseMove();
    }
    public void DeathCheck(int target)
    {
        //Check the target is dead
        if (characterReader.character[target].HP <= 0)
        {
            //If its the player, end the game
            if (target == 0)
            {
                infoText.text = (characterReader.character[target].m_CharacterName + " has died... GAME OVER");
            }
            //If its and enemy, remove the button to attack them and their info box & increase the number of enemies defeated
            else if (target >= 4)
            {
                infoText.text = ("Target at " + characterReader.character[target].m_CharacterName + " been killed");
                Buttons[target].gameObject.SetActive(false);
                enemiesdefeated++;
                infoBoxes[target - 4].gameObject.SetActive(false);
            }
            //Notify the player if anything inbetween dies
            else
            {
                infoText.text = ("Target at " + characterReader.character[target].m_CharacterName + " has died");

            }
        }
        //If all the enemies are dead, leave the battle and resume the game
        if (enemiesdefeated == enemies)
        {
            gameManager.ResumeGame();
        }
        Debug.Log(enemies);
    }
    //Enable the move options
    public void chooseMove()
    {
        optionBoxes[1].gameObject.SetActive(false);
        optionBoxes[0].gameObject.SetActive(true);
    }
    //Enable the target options

    public void chooseTarget()
    {
        optionBoxes[0].gameObject.SetActive(false);
        optionBoxes[1].gameObject.SetActive(true);
    }
    //Set which order everyone in the battle goes
    //This is supposed to use the speeds of the battlers but doesn't yet
    public void setTurnOrder()
    {
        //The array lenght is the number of enemies + 1
        turnOrder = new int[1 + enemies];
        //The player goes first
        turnOrder[0] = 0;
        //Add all the enemies to the order
        for (int i = 0; i < enemies; i++)
        {
            turnOrder[i + 1] = i + 4;
        }
        //Start the turn
        startTurn();
    }
    public void aiStartAttack(int x)
    {
        //If the enemy is alive, select a random move and target, then attack
        if (characterReader.character[target].HP > 0)
        {
            selectedAttack = Random.Range(0, 3);
            target = 0;
            CastAttack(x, 0);
        }
    }
    public void startTurn()
    {
        for (int i = 0; i < turnOrder.Length; i++)
        {
            //If it is the players turn to attack, use playerTarget, then attack
            if (turnOrder[i] == 0)
            {
                CastAttack(0, playerTarget);
            }
            else //Let the ai choose moves and targets
            {
                aiStartAttack(turnOrder[i]);
            }
        }
    }
    public void updateInfoBoxes()
    {
        //For each enemy, put their infomation into and info box
        for (int i = 0; i < enemies; i++)
        {
            Debug.Log(enemies);
            infoBoxesNameText[i].text = characterReader.character[i + 4].m_CharacterName;
            infoBoxesNameText[i + 4].text = characterReader.character[i + 4].m_CharacterName;
            infoBoxesMainText[i].text = characterReader.character[i + 4].m_Class.name + "\n" +
                                        characterReader.character[i + 4].m_Subclass.name + "\n" +
                                        characterReader.character[i + 4].HP.ToString() + "\n" +
                                        characterReader.character[i + 4].baseDamage.ToString() + "\n" +
                                        characterReader.character[i + 4].defence.ToString() + "\n" + characterReader.character[i + 4].speed.ToString();
        }
    }
}
