using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleScene : MonoBehaviour
{
    CharacterReader characterReader;
    CharacterInfoManager characterInfo;
    public Button[] Buttons;
    public Text infoText;
    // Start is called before the first frame update
    void Start()
    {
        characterReader = GetComponent<CharacterReader>();
        characterInfo = GetComponent<CharacterInfoManager>();
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
        characterReader.character[4].m_Class = characterInfo.classes[Random.Range(0, characterInfo.classes.Length - 1)];
        characterReader.character[4].m_Subclass = characterInfo.subclasses[Random.Range(0, characterInfo.subclasses.Length - 1)];
        for (int i = 0; i < 4; i++)
        {
            characterReader.character[4].moveInfo.m_Move[i] = characterInfo.moves[Random.Range(0, characterInfo.moves.Length - 1)];
            characterReader.character[4].moveInfo.m_MoveCoreCount[i] = Random.Range(0, 4);
            for (int a = characterReader.character[4].moveInfo.m_MoveCoreCount[i]; a > 0; a--)
            {
                Debug.Log(a);
                switch (a)
                {
                    case 1:
                        characterReader.character[4].moveInfo.m_MoveCore1[i] = characterInfo.cores[Random.Range(0, characterInfo.cores.Length - 1)];
                        //Debug.Log("11Current Index - " + m_CurrentIndex);
                        break;
                    case 2:
                        characterReader.character[4].moveInfo.m_MoveCore2[i] = characterInfo.cores[Random.Range(0, characterInfo.cores.Length - 1)];
                        //Debug.Log("12Current Index - " + m_CurrentIndex);
                        break;
                    case 3:
                        characterReader.character[4].moveInfo.m_MoveCore3[i] = characterInfo.cores[Random.Range(0, characterInfo.cores.Length - 1)];
                        //Debug.Log("13Current Index - " + m_CurrentIndex);
                        break;
                    default:
                        Debug.Log("ILLIGAL CHARACTER. ABORTING");
                        Application.Quit();
                        return;
                }
            }
        }
        characterReader.character[4].HP = characterReader.character[4].m_Class.HP;
        characterReader.character[4].baseDamage = characterReader.character[4].m_Class.baseDamage;
        characterReader.character[4].defence = characterReader.character[4].m_Class.defence;
        characterReader.character[4].speed = characterReader.character[4].m_Class.speed;
    }
    public void CastFirstAttack()
    {
        CastAttack(0, 0, 4);
    }
    public void CastSecondAttack()
    {
        CastAttack(0, 1, 4);
    }
    public void CastThirdAttack()
    {
        CastAttack(0, 2, 4);
    }
    public void CastForthAttack()
    {
        CastAttack(0, 3, 4);
    }

    public void CastAttack(int sender, int moveNum, int target)
    {
        int damage = 0;
        switch (characterReader.character[sender].moveInfo.m_Move[moveNum].moveType)
        {
            case MovesSO.MoveType.phyical:
                int rnd = Mathf.FloorToInt((Random.Range(10, 21)) / 10);
                damage = (Mathf.FloorToInt(Mathf.RoundToInt(characterReader.character[sender].baseDamage * characterReader.character[sender].moveInfo.m_Move[moveNum].damage / 2) / characterReader.character[target].defence)) * rnd;
                characterReader.character[target].HP -= damage;
                Debug.Log("Casted " + name + " " + characterReader.character[sender].moveInfo.m_Move[moveNum].moveType + " attack!\nIt dealt " + damage.ToString() + " damage." + rnd);
                break;
            case MovesSO.MoveType.magical:
                damage = (Mathf.FloorToInt(Mathf.RoundToInt((characterReader.character[sender].moveInfo.m_Move[moveNum].damage * 10) / characterReader.character[target].defence)));
                characterReader.character[target].HP -= damage;
                Debug.Log("Casted " + name + " " + characterReader.character[sender].moveInfo.m_Move[moveNum].moveType + " attack!\nIt dealt " + damage.ToString() + " damage.");
                break;
            case MovesSO.MoveType.status:
                switch (characterReader.character[sender].moveInfo.m_Move[moveNum].effectTarget)
                {
                    case false:
                        switch (characterReader.character[sender].moveInfo.m_Move[moveNum].boostStat)
                        {
                            case MovesSO.stats.HP:
                                characterReader.character[sender].HP += characterReader.character[sender].moveInfo.m_Move[moveNum].boostAmmount;
                                break;
                            case MovesSO.stats.baseDamage:
                                characterReader.character[sender].baseDamage += characterReader.character[sender].moveInfo.m_Move[moveNum].boostAmmount;
                                break;
                            case MovesSO.stats.defence:
                                characterReader.character[sender].defence += characterReader.character[sender].moveInfo.m_Move[moveNum].boostAmmount;
                                break;
                            case MovesSO.stats.speed:
                                characterReader.character[sender].speed += characterReader.character[sender].moveInfo.m_Move[moveNum].boostAmmount;
                                break;
                        }
                        break;
                    case true:
                        switch (characterReader.character[sender].moveInfo.m_Move[moveNum].boostStat)
                        {
                            case MovesSO.stats.HP:
                                characterReader.character[target].HP += characterReader.character[sender].moveInfo.m_Move[moveNum].boostAmmount;
                                break;
                            case MovesSO.stats.baseDamage:
                                characterReader.character[target].baseDamage += characterReader.character[sender].moveInfo.m_Move[moveNum].boostAmmount;
                                break;
                            case MovesSO.stats.defence:
                                characterReader.character[target].defence += characterReader.character[sender].moveInfo.m_Move[moveNum].boostAmmount;
                                break;
                            case MovesSO.stats.speed:
                                characterReader.character[target].speed += characterReader.character[sender].moveInfo.m_Move[moveNum].boostAmmount;
                                break;
                        }
                        break;
                }
                Debug.Log("Casted " + characterReader.character[sender].moveInfo.m_Move[moveNum].name + " " + characterReader.character[sender].moveInfo.m_Move[moveNum].moveType + " attack");
                break;
        }
    }
}
