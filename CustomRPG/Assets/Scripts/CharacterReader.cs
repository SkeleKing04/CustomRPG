using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using UnityEditor;

public class CharacterReader : MonoBehaviour
{
    private GameManager m_GameManager;
    public string m_CharacterData;
    public int[] m_Character;
    private int m_CurrentIndex;
    public int m_Class;
    public int m_Subclass;
    public int m_Move1;
    public int m_Move1CoreCount;
    public int m_Move1Core1;
    public int m_Move1Core2;
    public int m_Move1Core3;
    public int m_Move2;
    public int m_Move2CoreCount;
    public int m_Move2Core1;
    public int m_Move2Core2;
    public int m_Move2Core3;
    public int m_Move3;
    public int m_Move3CoreCount;
    public int m_Move3Core1;
    public int m_Move3Core2;
    public int m_Move3Core3;
    public int m_Move4;
    public int m_Move4CoreCount;
    public int m_Move4Core1;
    public int m_Move4Core2;
    public int m_Move4Core3;
    public string m_CharacterName;
    public int m_TheoreticalLength;
    public string currentDirectory;
    public Image m_ClassIconDisplay;
    public Image[] m_MoveCoreDisplay;
    public Sprite[] m_ClassIcons;
    public Color[] m_SubclassColors;
    private string SavedPlayersFileName = "SavedPlayers.txt";
    public string[] m_SavedCharacters = new string[5];
    public string[] m_characterClasses = new string[99];
    public string[] m_characterSubclasses = new string[99];
    public InputField m_CharacterSlotInputer;
    public Text m_CharacterBlerb;
    // Start is called before the first frame update
    void Start()
    {
        currentDirectory = Application.dataPath;
        LoadSavedPlayersFromFile();
        m_GameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadSavedPlayersFromFile()
    {
        Debug.Log("Looking for " + currentDirectory + "/" + SavedPlayersFileName);
        bool Exists = File.Exists(currentDirectory + "/" + SavedPlayersFileName);
        Debug.Log(Exists);
        if (Exists == true)
        {
            Debug.Log("Saved Players Found");
        }
        else
        {
            Debug.Log("Missing Saved Players file. Game will not run", this);
            return;
        }
        m_SavedCharacters = File.ReadAllLines(currentDirectory + "/" + SavedPlayersFileName);
        m_characterClasses = File.ReadAllLines(currentDirectory + "/characterValues/characterClasses.txt");
        m_characterSubclasses = File.ReadAllLines(currentDirectory + "/characterValues/characterSubclasses.txt");
        Debug.Log(m_characterClasses[0].ToString());
    }
    public void LoadPlayer()
    {
        m_CurrentIndex = 0;
        m_TheoreticalLength = 0;
        foreach (Image image in m_MoveCoreDisplay)
        {
            image.gameObject.SetActive(false);
        }
        //Class
        Debug.Log("Current Index - " + m_CurrentIndex);
        m_Class = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
        m_ClassIconDisplay.sprite = m_ClassIcons[m_Class - 1];
        m_CurrentIndex += 2;
        m_TheoreticalLength += 2;
        //Subclass
        Debug.Log("Current Index - " + m_CurrentIndex);
        m_Subclass = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
        m_ClassIconDisplay.color = m_SubclassColors[m_Subclass - 1];
        m_CurrentIndex += 2;
        m_TheoreticalLength += 2;
        //Move1
        Debug.Log("Current Index - " + m_CurrentIndex);
        m_Move1 = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
        m_CurrentIndex += 2;
        m_TheoreticalLength += 2;
        Debug.Log("Current Index - " + m_CurrentIndex);
        m_Move1CoreCount = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString());
        m_CurrentIndex++;
        m_TheoreticalLength++;
        Debug.Log("Current Index - " + m_CurrentIndex);
        for (int i = m_Move1CoreCount; i > 0; i--)
        {
            Debug.Log(i);
            switch (i)
            {
                case 1:
                    m_Move1Core1 = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("11Current Index - " + m_CurrentIndex);
                    m_MoveCoreDisplay[0].gameObject.SetActive(true);
                    break;
                case 2:
                    m_Move1Core2 = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("12Current Index - " + m_CurrentIndex);
                    m_MoveCoreDisplay[1].gameObject.SetActive(true);
                    break;
                case 3:
                    m_Move1Core3 = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("13Current Index - " + m_CurrentIndex);
                    m_MoveCoreDisplay[2].gameObject.SetActive(true);
                    break;
                default:
                    Debug.Log("ILLIGAL CHARACTER. ABORTING");
                    Application.Quit();
                    return;
            }
        }
        m_Move2 = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
        m_CurrentIndex += 2;
        m_TheoreticalLength += 2;
        Debug.Log("Current Index - " + m_CurrentIndex);
        m_Move2CoreCount = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString());
        m_CurrentIndex++;
        m_TheoreticalLength++;
        Debug.Log("Current Index - " + m_CurrentIndex);
        for (int i = m_Move2CoreCount; i > 0; i--)
        {
            Debug.Log(i);
            switch (i)
            {
                case 1:
                    m_Move2Core1 = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("11Current Index - " + m_CurrentIndex);
                    m_MoveCoreDisplay[3].gameObject.SetActive(true);
                    break;
                case 2:
                    m_Move2Core2 = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("12Current Index - " + m_CurrentIndex);
                    m_MoveCoreDisplay[4].gameObject.SetActive(true);
                    break;
                case 3:
                    m_Move2Core3 = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("13Current Index - " + m_CurrentIndex);
                    m_MoveCoreDisplay[5].gameObject.SetActive(true);
                    break;
                default:
                    Debug.Log("ILLIGAL CHARACTER. ABORTING");
                    Application.Quit();
                    return;
            }
        }
        m_Move3 = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
        m_CurrentIndex += 2;
        m_TheoreticalLength += 2;
        Debug.Log("Current Index - " + m_CurrentIndex);
        m_Move3CoreCount = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString());
        m_CurrentIndex++;
        m_TheoreticalLength++;
        Debug.Log("Current Index - " + m_CurrentIndex);
        for (int i = m_Move3CoreCount; i > 0; i--)
        {
            Debug.Log(i);
            switch (i)
            {
                case 1:
                    m_Move3Core1 = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("11Current Index - " + m_CurrentIndex);
                    m_MoveCoreDisplay[6].gameObject.SetActive(true);
                    break;
                case 2:
                    m_Move3Core2 = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("12Current Index - " + m_CurrentIndex);
                    m_MoveCoreDisplay[7].gameObject.SetActive(true);
                    break;
                case 3:
                    m_Move3Core3 = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("13Current Index - " + m_CurrentIndex);
                    m_MoveCoreDisplay[8].gameObject.SetActive(true);
                    break;
                default:
                    Debug.Log("ILLIGAL CHARACTER. ABORTING");
                    Application.Quit();
                    return;
            }
        }
        m_Move4 = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
        m_CurrentIndex += 2;
        m_TheoreticalLength += 2;
        Debug.Log("Current Index - " + m_CurrentIndex);
        m_Move4CoreCount = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString());
        m_CurrentIndex++;
        m_TheoreticalLength++;
        Debug.Log("Current Index - " + m_CurrentIndex);
        for (int i = m_Move4CoreCount; i > 0; i--)
        {
            Debug.Log(i);
            switch (i)
            {
                case 1:
                    m_Move4Core1 = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("11Current Index - " + m_CurrentIndex);
                    m_MoveCoreDisplay[9].gameObject.SetActive(true);
                    break;
                case 2:
                    m_Move4Core2 = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("12Current Index - " + m_CurrentIndex);
                    m_MoveCoreDisplay[10].gameObject.SetActive(true);
                    break;
                case 3:
                    m_Move4Core3 = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("13Current Index - " + m_CurrentIndex);
                    m_MoveCoreDisplay[11].gameObject.SetActive(true);
                    break;
                default:
                    Debug.Log("ILLIGAL CHARACTER. ABORTING");
                    Application.Quit();
                    return;
            }
        }
        m_CharacterName = "";
        for (int i = m_TheoreticalLength; i < m_CharacterData.Length; i++)
        {
            Debug.Log(m_TheoreticalLength);
            m_CharacterName += m_CharacterData[i];
            m_TheoreticalLength++;
        }
        m_CharacterBlerb.text = m_characterSubclasses[m_Subclass - 1] + " " + m_characterClasses[m_Class - 1] + " " + m_CharacterName;
        foreach (Image image in m_MoveCoreDisplay)
        {
            image.color = m_SubclassColors[m_Subclass - 1];
        }

    }
    public void SelectPlayerSlot()
    {
        int i = Convert.ToInt32(m_CharacterSlotInputer.text);
        Debug.Log(i);
        if (i > m_SavedCharacters.Length)
        {
            Debug.Log("TOO LONG");
            return;
        }
        m_CharacterData = m_SavedCharacters[i - 1];
        LoadPlayer();
    }

}
