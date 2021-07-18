using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script keeps track of the player's stats & info
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
        //Set the name of player's Character to the name text box
        CharacterNameText.text = characterReader.character[0].m_CharacterName;
        //Set the rest of player's Character's stats to the smaller box
        CharacterStatsText.text = characterReader.character[0].m_Class.name + "\n" +
                                  characterReader.character[0].m_Subclass.name + "\n" +
                                  characterReader.character[0].HP.ToString() + "\n" +
                                  characterReader.character[0].baseDamage.ToString() + "\n" +
                                  characterReader.character[0].defence.ToString() + "\n" +
                                  characterReader.character[0].speed.ToString();
    }
}
