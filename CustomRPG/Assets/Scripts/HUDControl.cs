using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDControl : MonoBehaviour
{
    CharacterReader characterReader;
    public Text CharacterNameText;
    public Text CharacterStatsText;
    // Start is called before the first frame update
    void Start()
    {
        characterReader = Object.FindObjectOfType<CharacterReader>();
    }

    public void setupHUD()
    {
        CharacterNameText.text = characterReader.character[0].m_CharacterName;
        CharacterStatsText.text = characterReader.character[0].m_Class.name + "\n" +
                                  characterReader.character[0].m_Subclass.name + "\n" +
                                  characterReader.character[0].HP.ToString() + "\n" +
                                  characterReader.character[0].baseDamage.ToString() + "\n" +
                                  characterReader.character[0].defence.ToString() + "\n" +
                                  characterReader.character[0].speed.ToString();
    }
}
