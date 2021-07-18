using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Array of all the menus
    public GameObject[] m_Menus;
    //Scripts for each menu
    EditorMenu editorMenu;
    BattleScene battleScene;
    HUDControl HUDController;
    //The player & camera
    public GameObject m_Player;
    public Camera MainCamera;
    //All the different menu states
    public enum e_MenuState
    {
        Off,
        ChooseCharacter,
        EditCharacter,
        BattleScene,
        OverworldHUD
    };
    public e_MenuState MenuState;
    //All tje different game stats
    public enum e_GameState
    {
        Paused,
        Start,
        Playing,
        Resume
    };
    public e_GameState gameState;
    void Start()
    {
        //Update the menu to display the right one
        UpdateMenu();
        editorMenu = Object.FindObjectOfType<EditorMenu>();
        battleScene = Object.FindObjectOfType<BattleScene>();
        HUDController = Object.FindObjectOfType<HUDControl>();
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
            case e_GameState.Playing:
                break;
            case e_GameState.Resume:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
                gameState = e_GameState.Playing;
                break;


        }
    }
    public void UpdateMenu()
    {
        //Hide all the menus
        foreach(GameObject menu in m_Menus)
        {
            menu.SetActive(false);
        }
        //Load the current MenuStat
        switch (MenuState)
        {
            case e_MenuState.Off:
                break;
            case e_MenuState.ChooseCharacter:
                m_Menus[0].SetActive(true);
                break;
            case e_MenuState.EditCharacter:
                m_Menus[1].SetActive(true);
                ///Load the editor script
                editorMenu.LoadEditor();
                break;
            case e_MenuState.BattleScene:
                m_Menus[2].SetActive(true);
                m_Menus[3].SetActive(true);
                //Start the Battle Scene
                battleScene.LoadMoves();
                battleScene.initializeFight();
                break;
            case e_MenuState.OverworldHUD:
                m_Menus[3].SetActive(true);
                //Setup the HUD
                HUDController.setupHUD();
                break;
        }
    }
    //Set the gameState and MenuState
    //Then update the menu
    public void StartGame()
    {
        gameState = e_GameState.Start;
        MenuState = e_MenuState.OverworldHUD;
        UpdateMenu();
    }
    public void ResumeGame()
    {
        gameState = e_GameState.Resume;
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
