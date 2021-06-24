using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleScene : MonoBehaviour
{
    CharacterReader characterReader;
    CharacterInfoManager characterInfo;
    GameManager gameManager;
    public GameObject[] optionBoxes;
    public Button[] Buttons;
    public Text infoText;
    public int enemies;
    public int selectedAttack;
    public int target;
    // Start is called before the first frame update
    void Start()
    {
        characterReader = GetComponent<CharacterReader>();
        characterInfo = GetComponent<CharacterInfoManager>();
        gameManager = FindObjectOfType<GameManager>();
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
        enemies = Random.Range(1, 4);
        for (int x = 4 + enemies; x > 3; x--)
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
            characterReader.character[x].HP = characterReader.character[x].m_Class.HP;
            characterReader.character[x].baseDamage = characterReader.character[x].m_Class.baseDamage;
            characterReader.character[x].defence = characterReader.character[x].m_Class.defence;
            characterReader.character[x].speed = characterReader.character[x].m_Class.speed;
            Buttons[x].gameObject.SetActive(true);
        }

    }
    public void selectFirstAttack()
    {
        selectedAttack = 0;
        chooseTarget();
    }
    public void selectSecondAttack()
    {
        selectedAttack = 1;
        chooseTarget();

    }
    public void selectThirdAttack()
    {
        selectedAttack = 2;
        chooseTarget();

    }
    public void selectFourthAttack()
    {
        selectedAttack = 3;
        chooseTarget();

    }
    public void selectFirstTarget()
    {
        target = 4;
        CastAttack();
    }
    public void selectSecondTarget()
    {
        target = 5;
        CastAttack();
    }
    public void selectThirdTarget()
    {
        target = 6;
        CastAttack();
    }
    public void selectFourthTarget()
    {
        target = 7;
        CastAttack();
    }
    public void CastAttack()
    {
        int sender = 0;
        int damage = 0;
        switch (characterReader.character[sender].moveInfo.m_Move[selectedAttack].moveType)
        {
            case MovesSO.MoveType.phyical:
                int rnd = Mathf.FloorToInt((Random.Range(10, 21)) / 10);
                damage = (Mathf.FloorToInt(Mathf.RoundToInt(characterReader.character[sender].baseDamage * characterReader.character[sender].moveInfo.m_Move[selectedAttack].damage / 2) / characterReader.character[target].defence)) * rnd;
                characterReader.character[target].HP -= damage;
                infoText.text = ("Used " + characterReader.character[sender].moveInfo.m_Move[selectedAttack].name + " on target " + target + "!\nIt dealt " + damage.ToString() + " damage.");
                break;
            case MovesSO.MoveType.magical:
                damage = (Mathf.FloorToInt(Mathf.RoundToInt((characterReader.character[sender].moveInfo.m_Move[selectedAttack].damage * 10) / characterReader.character[target].defence)));
                characterReader.character[target].HP -= damage;
                infoText.text = ("Used " + characterReader.character[sender].moveInfo.m_Move[selectedAttack].name + " on target " + target + "!\nIt dealt " + damage.ToString() + " damage.");
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
                        infoText.text = ("Effected yourself with " + characterReader.character[sender].moveInfo.m_Move[selectedAttack].name + ".\nYou receved " + characterReader.character[sender].moveInfo.m_Move[selectedAttack].boostAmmount + " to " + characterReader.character[sender].moveInfo.m_Move[selectedAttack].boostStat + "!");
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
                        infoText.text = ("Effected target " + target + " with " + characterReader.character[sender].moveInfo.m_Move[selectedAttack].name + ".\nThey receved " + characterReader.character[sender].moveInfo.m_Move[selectedAttack].boostAmmount + " to " + characterReader.character[sender].moveInfo.m_Move[selectedAttack].boostStat + "!");
                        break;
                }
                break;
        }
        DeathCheck(target);
        chooseMove();
    }
    public void DeathCheck(int target)
    {
        if (characterReader.character[target].HP <= 0)
        {
            if (target == 0)
            {
                infoText.text = ("The player has died... GAME OVER");
            }
            else if (target >= 4)
            {
                infoText.text = ("Target at " + target + " been killed");
                Buttons[target].gameObject.SetActive(false);
                enemies--;
            }
            else
            {
                infoText.text = ("Target at " + target + " has died");

            }
        }
        if (enemies <= 0)
        {
            gameManager.ResumeGame();
        }
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
}
