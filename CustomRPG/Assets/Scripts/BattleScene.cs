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

        Buttons[0].GetComponentInChildren<Text>().text = characterReader.m_Move1.name;
        Buttons[1].GetComponentInChildren<Text>().text = characterReader.m_Move2.name;
        Buttons[2].GetComponentInChildren<Text>().text = characterReader.m_Move3.name;
        Buttons[3].GetComponentInChildren<Text>().text = characterReader.m_Move4.name;
    }
}
