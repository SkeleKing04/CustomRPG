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
            Buttons[i].GetComponentInChildren<Text>().text = characterReader.moveInfo.m_Move[i].name;
        }
    }
    public void initializeFight()
    {

    }
    public void CastFirstAttack()
    {
        characterReader.moveInfo.m_Move[0].CastAttack();
    }
    public void CastSecondAttack()
    {
        characterReader.moveInfo.m_Move[1].CastAttack();
    }
    public void CastThirdAttack()
    {
        characterReader.moveInfo.m_Move[2].CastAttack();
    }
    public void CastForthAttack()
    {
        characterReader.moveInfo.m_Move[3].CastAttack();
    }

}
