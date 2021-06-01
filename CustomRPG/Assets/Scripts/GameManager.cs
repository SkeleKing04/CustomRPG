using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] m_Menus;
    public Dropdown dropdown;
    EditorMenu editorMenu;
    public enum e_MenuState
    {
        Off,
        ChooseCharacter,
        EditCharacter
    };
    public e_MenuState MenuState;
    // Start is called before the first frame update
    void Start()
    {
        //MenuState = e_MenuState.ChooseCharacter;
        UpdateMenu();
        editorMenu = Object.FindObjectOfType<EditorMenu>();
        Dropdown.OptionData fire = new Dropdown.OptionData();
        fire.text = "Fire";
        //dropdown.AddOptions(fire);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateMenu()
    {
        foreach(GameObject menu in m_Menus)
        {
            menu.SetActive(false);
        }
        switch (MenuState)
        {
            case e_MenuState.Off:
                break;
            case e_MenuState.ChooseCharacter:
                m_Menus[0].SetActive(true);
                break;
            case e_MenuState.EditCharacter:
                m_Menus[1].SetActive(true);
                editorMenu.LoadEditor();
                break;
        }
    }
    public void OpenEditor()
    {
        MenuState = e_MenuState.EditCharacter;
        UpdateMenu();
    }
}
