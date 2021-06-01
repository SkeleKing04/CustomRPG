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
        for (int i = 2; i < 14; i += 4)
        {
            foreach (ScriptableObject Move in CharacterInfo.moves)
            {
                Dropdown.OptionData option = new Dropdown.OptionData();
                option.text = CharacterInfo.moves[localConuter].name.ToString(); ;
                Dropdowns[i].options.Add(option);
            }

        }

    }
}
