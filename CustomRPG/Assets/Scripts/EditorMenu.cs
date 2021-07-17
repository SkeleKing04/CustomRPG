using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorMenu : MonoBehaviour
{
    //public ScriptableObject[] AvalibleClasses;
    //public ScriptableObject[] AvalibleSubclasses;
    //public ScriptableObject[] AvalibleMoves;
    //public ScriptableObject[] AvalibleCores;
    public Dropdown[] Dropdowns;
    private int localConuter;
    CharacterReader characterReader;
    CharacterInfoManager CharacterInfo;
    public string softSave;
    // Start is called before the first frame update

    void Start()
    {
        characterReader = Object.FindObjectOfType<CharacterReader>();
        CharacterInfo = Object.FindObjectOfType<CharacterInfoManager>();

    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
    public void LoadEditor()
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
    public void quickSave()
    {
        softSave = null;
        for(int i = 0; i < 6; i++)
        {
            if (Dropdowns[i].value < 10)
            {
                softSave += "0" + (Dropdowns[i].value + 1).ToString();
            }
            else
            {
                softSave += (Dropdowns[i].value + 1).ToString();
            }
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
}
