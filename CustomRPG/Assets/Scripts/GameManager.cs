using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] m_Menus;
    EditorMenu editorMenu;
    BattleScene battleScene;
    HUDControl HUDController;
    public GameObject m_Player;
    public Camera MainCamera;
    PlayerInfomation playerInfo;
    CharacterReader characterReader;
    CharacterMovement movement;
    HealthManager healthManager;
    public enum e_MenuState
    {
        Off,
        ChooseCharacter,
        EditCharacter,
        BattleScene,
        OverworldHUD
    };
    public e_MenuState MenuState;
    public enum e_GameState
    {
        Paused,
        Start,
        Playing
    };
    public e_GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        //MenuState = e_MenuState.ChooseCharacter;
        UpdateMenu();
        editorMenu = Object.FindObjectOfType<EditorMenu>();
        playerInfo = Object.FindObjectOfType<PlayerInfomation>();
        characterReader = Object.FindObjectOfType<CharacterReader>();
        battleScene = Object.FindObjectOfType<BattleScene>();
        HUDController = Object.FindObjectOfType<HUDControl>();
        Dropdown.OptionData fire = new Dropdown.OptionData();
        fire.text = "Fire";
        //dropdown.AddOptions(fire);
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case e_GameState.Paused:
                //m_Player.SetActive(false);
                //MainCamera.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
                break;
            case e_GameState.Start:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
                gameState = e_GameState.Playing;
                break;
        }
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
            case e_MenuState.BattleScene:
                m_Menus[2].SetActive(true);
                battleScene.LoadMoves();
                battleScene.initializeFight();
                break;
            case e_MenuState.OverworldHUD:
                m_Menus[3].SetActive(true);
                HUDController.setupHUD();
                break;
        }
    }
    public void StartGame()
    {
        gameState = e_GameState.Start;
        MenuState = e_MenuState.OverworldHUD;
        UpdateMenu();
    }
    public void OpenEditor()
    {
        gameState = e_GameState.Paused;
        MenuState = e_MenuState.EditCharacter;
        UpdateMenu();
    }
    public void OpenSelect()
    {
        gameState = e_GameState.Paused;
        MenuState = e_MenuState.ChooseCharacter;
        UpdateMenu();
    }
    public void beginBattle()
    {
        gameState = e_GameState.Paused;
        MenuState = e_MenuState.BattleScene;
        UpdateMenu();
    }
}
