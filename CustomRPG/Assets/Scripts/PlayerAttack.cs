using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    CharacterInfoManager CharacterInfo;
    public Component[] attackScripts;
    CharacterReader CharacterReader;
    private string[] moveTypes = new string[4];
    private int[] moveDamage = new int[4];
    // Start is called before the first frame update
    void Start()
    {
        CharacterInfo = FindObjectOfType<CharacterInfoManager>();
        CharacterReader = FindObjectOfType<CharacterReader>();
        moveTypes[0] = CharacterInfo.moves[CharacterReader.m_Move1].moveType.ToString();
        moveTypes[1] = CharacterInfo.moves[CharacterReader.m_Move2].moveType.ToString();
        moveTypes[2] = CharacterInfo.moves[CharacterReader.m_Move3].moveType.ToString();
        moveTypes[3] = CharacterInfo.moves[CharacterReader.m_Move4].moveType.ToString();
        moveDamage[0] = CharacterInfo.moves[CharacterReader.m_Move1].damage;
        moveDamage[1] = CharacterInfo.moves[CharacterReader.m_Move2].damage;
        moveDamage[2] = CharacterInfo.moves[CharacterReader.m_Move3].damage;
        moveDamage[3] = CharacterInfo.moves[CharacterReader.m_Move4].damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
