﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] m_Menus;
    EditorMenu editorMenu;
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
        EditCharacter
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
                Time.timeScale = 0;
                break;
            case e_GameState.Start:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                m_Player.GetComponent<HealthManager>().HP = characterReader.HP;
                m_Player.GetComponent<HealthManager>().baseDamage = characterReader.baseDamage;
                m_Player.GetComponent<HealthManager>().defence = characterReader.defence;
                m_Player.GetComponent<HealthManager>().speed = characterReader.speed;
                m_Player.GetComponent<CharacterMovement>().MoveSpeed = characterReader.speed / 200;
                //m_Player.SetActive(true); ;
                //MainCamera.gameObject.SetActive(true);
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
        }
    }
    public void StartGame()
    {
        gameState = e_GameState.Start;
        MenuState = e_MenuState.Off;
        UpdateMenu();
    }
    public void OpenEditor()
    {
        MenuState = e_MenuState.EditCharacter;
        UpdateMenu();
    }
}
