using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class EditorMenu : MonoBehaviour
{
    public Dropdown[] Dropdowns;
    private int localConuter;
    CharacterReader characterReader;
    CharacterInfoManager CharacterInfo;
    public string softSave;

    void Start()
    {
        characterReader = Object.FindObjectOfType<CharacterReader>();
        CharacterInfo = Object.FindObjectOfType<CharacterInfoManager>();
    }
    public void LoadEditor() //Loads all of the Classes, Subclass, Moves & Cores into the dropdown boxes
                             //The is a bug where the value in a dropdown box appear blank but still have a value
                             //This is only a visual bug, however I don't know how to fix it
    {
        localConuter = 0;
        foreach (ScriptableObject Class in CharacterInfo.classes)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = CharacterInfo.classes[localConuter].name.ToString();
            Dropdowns[0].options.Add(option);
            localConuter++;
        }
        localConuter = 0;
        foreach (ScriptableObject Subclass in CharacterInfo.subclasses)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = CharacterInfo.subclasses[localConuter].name.ToString();
            Dropdowns[1].options.Add(option);
            localConuter++;
        }
        for (int i = 2; i < 6; i++)
        {
            localConuter = 0;
            foreach (ScriptableObject Move in CharacterInfo.moves)
            {
                Dropdown.OptionData option = new Dropdown.OptionData();
                option.text = CharacterInfo.moves[localConuter].name.ToString();
                Dropdowns[i].options.Add(option);
                localConuter++;
            }

        }
        for (int i = 6; i < 18; i++)
        {
            localConuter = 0;
            foreach (ScriptableObject Cove in CharacterInfo.cores)
            {
                Dropdown.OptionData option = new Dropdown.OptionData();
                option.text = CharacterInfo.cores[localConuter].name.ToString();
                Dropdowns[i].options.Add(option);
                localConuter++;
            }
        }
    }
    public void quickSave() //Create a quick save of the Character when a dropdown box is updated
    {
        softSave = null;
        for(int i = 0; i < 6; i++)
        {
            //If the value of the dropdown is a single digit, add a 0 to the start of it
            if (Dropdowns[i].value < 10)
            {
                softSave += "0" + (Dropdowns[i].value + 1).ToString();
            }
            else
            {
                softSave += (Dropdowns[i].value + 1).ToString();
            }
            //When the cores need to be added, do the following
            if (i == 2 || i == 3 || i == 4 || i == 5)
            {
                softSave += CharacterInfo.moves[Dropdowns[i].value].coreSlots.ToString();
                for (int a = 0; a < CharacterInfo.moves[Dropdowns[i].value].coreSlots - 1; a++)
                {
                    if (Dropdowns[i * 3 + a].value < 10)
                    {
                        softSave += "0" + (Dropdowns[i * 3 + a].value + 1).ToString();
                    }
                    else
                    {
                        softSave += (Dropdowns[i * 3 + a].value + 1).ToString();
                    }
                }
            }
        }
    }
    public void saveCharacter() //save the edited character to the slot
    {
        LoadSavedPlayersFromFile();
        StreamWriter fileWriter = new StreamWriter(characterReader.currentDirectory + "/" + characterReader.SavedPlayersFileName);
        fileWriter.WriteLine(softSave);
    }
    public void LoadSavedPlayersFromFile()
    {
        Debug.Log("Looking for " + characterReader.currentDirectory + "/" + characterReader.SavedPlayersFileName);
        //Check to see if the file exists
        bool Exists = File.Exists(characterReader.currentDirectory + "/" + characterReader.SavedPlayersFileName);
        Debug.Log(Exists);
        if (Exists == true)
        {
            Debug.Log("Saved Players Found");
        }
        else
        {
            //Stop if the file does not exist
            Debug.Log("Missing Saved Players file. Game will not run", this);
            return;
        }
        //Read all the lines in the file
        characterReader.m_SavedCharacters = File.ReadAllLines(characterReader.currentDirectory + "/" + characterReader.SavedPlayersFileName);
    }
}
