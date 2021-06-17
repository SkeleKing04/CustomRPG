using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleScene : MonoBehaviour
{
    CharacterReader characterReader;
    public Button[] Buttons;
    public Text infoText;
    // Start is called before the first frame update
    void Start()
    {
        characterReader = GetComponent<CharacterReader>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void LoadMoves()
    {
        for(int i = 0; i < 4; i++)
        {
            Buttons[i].GetComponentInChildren<Text>().text = characterReader.moveInfo[0].m_Move[i].name;
        }
    }
    public void initializeFight()
    {

    }
    public void CastFirstAttack()
    {
        characterReader.moveInfo[0].m_Move[0].CastAttack(characterReader.HP[0], characterReader.baseDamage[0], characterReader.defence[0], characterReader.speed[0], characterReader.moveInfo[0].m_Move[0].damage, 10, 10, 10, 10);
    }
    public void CastSecondAttack()
    {
        characterReader.moveInfo[0].m_Move[1].CastAttack(characterReader.HP[0], characterReader.baseDamage[0], characterReader.defence[0], characterReader.speed[0], characterReader.moveInfo[0].m_Move[0].damage, 10, 10, 10, 10);
    }
    public void CastThirdAttack()
    {
        characterReader.moveInfo[0].m_Move[2].CastAttack(characterReader.HP[0], characterReader.baseDamage[0], characterReader.defence[0], characterReader.speed[0], characterReader.moveInfo[0].m_Move[0].damage, 10, 10, 10, 10);
    }
    public void CastForthAttack()
    {
        characterReader.moveInfo[0].m_Move[3].CastAttack(characterReader.HP[0], characterReader.baseDamage[0], characterReader.defence[0], characterReader.speed[0], characterReader.moveInfo[0].m_Move[0].damage, 10, 10, 10, 10);
    }

}
