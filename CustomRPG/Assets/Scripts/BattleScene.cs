using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleScene : MonoBehaviour
{
    CharacterReader characterReader;
    CharacterInfoManager characterInfo;
    GameManager gameManager;
    HUDControl hudControl;
    public GameObject[] optionBoxes;
    public GameObject[] infoBoxes;
    public Text[] infoBoxesNameText;
    public Text[] infoBoxesMainText;
    public Button[] Buttons;
    public Text infoText;
    public int enemies;
    public int enemiesdefeated;
    public int selectedAttack;
    public int playerTarget;
    public int target;
    public int[] turnOrder;
    // Start is called before the first frame update
    void Start()
    {
        characterReader = GetComponent<CharacterReader>();
        characterInfo = GetComponent<CharacterInfoManager>();
        gameManager = FindObjectOfType<GameManager>();
        hudControl = GetComponent<HUDControl>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void LoadMoves()
    {
        for(int i = 0; i < 4; i++)
        {
            Buttons[i].GetComponentInChildren<Text>().text = characterReader.character[0].moveInfo.m_Move[i].name;
        }
    }
    public void initializeFight()
    {
        enemies = Random.Range(1, 5);
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
            Buttons[x].gameObject.SetActive(true);
            Debug.Log(x);
            infoBoxes[x - 4].SetActive(true);
        }
        updateInfoBoxes();
        hudControl.setupHUD();
    }
    public void selectFirstAttack()
    {
        selectedAttack = 0;
        infoText.text = "Select a target.";
        chooseTarget();
    }
    public void selectSecondAttack()
    {
        selectedAttack = 1;
        infoText.text = "Select a target.";
        chooseTarget();
    }
    public void selectThirdAttack()
    {
        selectedAttack = 2;
        infoText.text = "Select a target.";
        chooseTarget();
    }
    public void selectFourthAttack()
    {
        selectedAttack = 3;
        infoText.text = "Select a target.";
        chooseTarget();
    }
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
                switch (characterReader.character[sender].moveInfo.m_Move[selectedAttack].effectTarget)
                {
                    case false:
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
        hudControl.setupHUD();
        updateInfoBoxes();
        DeathCheck(target);
        chooseMove();
    }
    public void DeathCheck(int target)
    {
        if (characterReader.character[target].HP <= 0)
        {
            if (target == 0)
            {
                infoText.text = (characterReader.character[target].m_CharacterName + " has died... GAME OVER");
            }
            else if (target >= 4)
            {
                infoText.text = ("Target at " + characterReader.character[target].m_CharacterName + " been killed");
                Buttons[target].gameObject.SetActive(false);
                enemiesdefeated++;
                infoBoxes[target - 4].gameObject.SetActive(false);
            }
            else
            {
                infoText.text = ("Target at " + characterReader.character[target].m_CharacterName + " has died");

            }
        }
        if (enemiesdefeated == enemies)
        {
            gameManager.ResumeGame();
        }
        Debug.Log(enemies);
    }
    public void chooseMove()
    {
        optionBoxes[1].gameObject.SetActive(false);
        optionBoxes[0].gameObject.SetActive(true);
    }
    public void chooseTarget()
    {
        optionBoxes[0].gameObject.SetActive(false);
        optionBoxes[1].gameObject.SetActive(true);
    }
    public void setTurnOrder()
    {
        turnOrder = new int[1 + enemies];
        turnOrder[0] = 0;
        for (int i = 0; i < enemies; i++)
        {
            turnOrder[i + 1] = i + 4; 
        }
        startTurn();
    }
    public void aiStartAttack(int x)
    {
        if (characterReader.character[target].HP > 0)
        {
            selectedAttack = Random.Range(0, 3);
            target = 0;
            CastAttack(x, 0);
        }
    }
    public void startTurn()
    {
        for(int i = 0; i < turnOrder.Length; i++)
        {
            if (turnOrder[i] == 0)
            {
                CastAttack(0, playerTarget);
            }
            else
            {
                aiStartAttack(turnOrder[i]);
            }
        }

    }
    public void updateInfoBoxes()
    {
        for(int i = 0; i < enemies; i++)
        {
            Debug.Log(enemies);
            infoBoxesNameText[i].text = characterReader.character[i + 4].m_CharacterName;
            infoBoxesMainText[i].text = characterReader.character[i + 4].m_Class.name + "\n" +
                                        characterReader.character[i + 4].m_Subclass.name + "\n" +
                                        characterReader.character[i + 4].HP.ToString() + "\n" +
                                        characterReader.character[i + 4].baseDamage.ToString() + "\n" +
                                        characterReader.character[i + 4].defence.ToString() + "\n" + characterReader.character[i + 4].speed.ToString();
        }


    }
}
