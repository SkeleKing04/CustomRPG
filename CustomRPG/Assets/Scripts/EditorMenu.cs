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
    // Start is called before the first frame update

    void Start()
    {
        characterReader = Object.FindObjectOfType<CharacterReader>();

    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
    public void LoadEditor()
    {
        localConuter = 0;
        foreach (ScriptableObject Class in characterReader.m_Classes)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = characterReader.m_Classes[localConuter].name.ToString();
            Dropdowns[0].options.Add(option);
            localConuter++;
        }
        localConuter = 0;
        foreach (ScriptableObject Subclass in characterReader.m_Subclasses)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = characterReader.m_Subclasses[localConuter].name.ToString();
            Dropdowns[1].options.Add(option);
            localConuter++;
        }

    }
}
