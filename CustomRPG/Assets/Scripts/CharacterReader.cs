using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using UnityEditor;

//Script for reading & loading player characters
public class CharacterReader : MonoBehaviour
{
    private GameManager m_GameManager;
    private CharacterInfoManager CharacterInfo;
    //Used to hold strings from a .txt
    public string m_CharacterData;
    //Used to tell where a Character is saved
    public int m_CharacterSlot;
    //Used to tell which character of a Character is being read
    private int m_CurrentIndex;
    //An array of all the Characters 
    public CharacterArray[] character = new CharacterArray[10];
    //Used to check for illegal Characters
    public int m_TheoreticalLength;
    public string currentDirectory;
    //Used for display
    public Image m_ClassIconDisplay;
    public Image[] m_MoveCoreDisplay;
    //File name
    private string SavedPlayersFileName = "SavedPlayers.txt";
    //Number of Characters that can be loaded in the game from the "SavedPlayers.txt" file
    public string[] m_SavedCharacters = new string[5];
    //Input Field on main screen
    public InputField m_CharacterSlotInputer;
    //A little Character description
    public Text m_CharacterBlerb;

    //All the variables that make up one Character
    [System.Serializable]
    public class CharacterArray
    {
        //Character Class
        public ClassesSO m_Class;
        //Character Subclass
        public SubclassesSO m_Subclass;
        //Character Moves
        public MoveInfo moveInfo;
        //Character Name
        public string m_CharacterName;
        //Character Stats
        public float HP;
        public float baseDamage;
        public float defence;
        public float speed;
    }
    //Arrays of all the moves & cores a player can have
    //A player will all ways have 4 moves
    [System.Serializable]
    public class MoveInfo
    {
        //The 4 moves
        public MovesSO[] m_Move = new MovesSO[4];
        //The number of cores each move can have
        public int[] m_MoveCoreCount = new int[4];
        //The possible 3 cores that the 4 moves can have
        public CoreSO[] m_MoveCore1 = new CoreSO[4];
        public CoreSO[] m_MoveCore2 = new CoreSO[4];
        public CoreSO[] m_MoveCore3 = new CoreSO[4];
    }

    void Start()
    {
        //Sets the current directory then loads all the players in the file
        currentDirectory = Application.dataPath;
        LoadSavedPlayersFromFile();
        //Accesses the GameManager and CharacterInfoManager Scripts
        m_GameManager = FindObjectOfType<GameManager>();
        CharacterInfo = FindObjectOfType<CharacterInfoManager>();
    }
    public void LoadSavedPlayersFromFile()
    {
        Debug.Log("Looking for " + currentDirectory + "/" + SavedPlayersFileName);
        //Check to see if the file exists
        bool Exists = File.Exists(currentDirectory + "/" + SavedPlayersFileName);
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
        m_SavedCharacters = File.ReadAllLines(currentDirectory + "/" + SavedPlayersFileName);
    }
    public void LoadPlayer()
    {
        Debug.Log(Convert.ToInt32(m_CharacterSlotInputer.text) - 1);
        //Select the Character to load
        m_CharacterSlot = Convert.ToInt32(m_CharacterSlotInputer.text) - 1;
        //Reset Variables
        m_CurrentIndex = 0;
        m_TheoreticalLength = 0;
        /*m_Class[m_CharacterSlot] = null;
        m_Subclass[m_CharacterSlot] = null;
        for (int i = 0; i < 4; i++)
        {
            moveInfo[m_CharacterSlot].m_Move[i] = null;
            moveInfo[m_CharacterSlot].m_MoveCoreCount[i] = 0;
            moveInfo[m_CharacterSlot].m_MoveCore1[i] = null;
            moveInfo[m_CharacterSlot].m_MoveCore2[i] = null;
            moveInfo[m_CharacterSlot].m_MoveCore3[i] = null;
        }*/
        //Hide all the little diamonds that appear on the Character select screen
        foreach (Image image in m_MoveCoreDisplay)
        {
            image.gameObject.SetActive(false);
        }
        //Class
        //Get the Class
        character[m_CharacterSlot].m_Class = CharacterInfo.classes[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
        //Load the Class icon
        m_ClassIconDisplay.sprite = character[m_CharacterSlot].m_Class.classIcon;
        m_CurrentIndex += 2;
        m_TheoreticalLength += 2;

        //Subclass
        //Get the Subclass
        character[m_CharacterSlot].m_Subclass = CharacterInfo.subclasses[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
        //Load the Subclass colour
        m_ClassIconDisplay.color = character[m_CharacterSlot].m_Subclass.subclassColour;
        m_CurrentIndex += 2;
        m_TheoreticalLength += 2;

        //Moves
        for (int a = 0; a < 4; a++)
        {
            Debug.Log("a is " + a);
            //Get the Move
            character[m_CharacterSlot].moveInfo.m_Move[a] = CharacterInfo.moves[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
            m_CurrentIndex += 2;
            m_TheoreticalLength += 2;
            //Get the Moves core count
            character[m_CharacterSlot].moveInfo.m_MoveCoreCount[a] = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString());
            m_CurrentIndex++;
            m_TheoreticalLength++;
            //Repeat the following until i is 0
            for (int i = character[m_CharacterSlot].moveInfo.m_MoveCoreCount[a]; i > 0; i--)
            {
                Debug.Log(i);
                switch (i)
                {
                    case 1:
                        //Get the Core
                        character[m_CharacterSlot].moveInfo.m_MoveCore1[a] = CharacterInfo.cores[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
                        break;
                    case 2:
                        //Get the Core
                        character[m_CharacterSlot].moveInfo.m_MoveCore2[a] = CharacterInfo.cores[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
                        break;
                    case 3:
                        //Get the Core
                        character[m_CharacterSlot].moveInfo.m_MoveCore3[a] = CharacterInfo.cores[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
                        break;
                    //If the core count is higher then 3, the Character is illegal and will stop loading
                    default:
                        Debug.Log("ILLIGAL CHARACTER. ABORTING");
                        //Application.Quit();
                        return;
                }
                m_CurrentIndex += 2;
                m_TheoreticalLength += 2;
                //Display the correct cores
                m_MoveCoreDisplay[((3 * a) + i) - 1].gameObject.SetActive(true);
            }
        }
        //Reset the Character Name
        character[m_CharacterSlot].m_CharacterName = "";
        //The rest of the Character Data is the name
        for (int i = m_TheoreticalLength; i < m_CharacterData.Length; i++)
        {
            character[m_CharacterSlot].m_CharacterName += m_CharacterData[i];
            m_TheoreticalLength++;
        }
        //Character name + Subclass + Class
        m_CharacterBlerb.text = character[m_CharacterSlot].m_Subclass.name + " " + character[m_CharacterSlot].m_Class.name + " " + character[m_CharacterSlot].m_CharacterName;
        //Set the colour of the core display to match the subclass
        foreach (Image image in m_MoveCoreDisplay)
        {
            image.color = m_ClassIconDisplay.color = character[m_CharacterSlot].m_Subclass.subclassColour;
        }
        //Set the Characters stats
        character[m_CharacterSlot].HP = character[m_CharacterSlot].m_Class.HP * 10;
        character[m_CharacterSlot].baseDamage = character[m_CharacterSlot].m_Class.baseDamage;
        character[m_CharacterSlot].defence = character[m_CharacterSlot].m_Class.defence;
        character[m_CharacterSlot].speed = character[m_CharacterSlot].m_Class.speed;
    }
    //When the Input field is updated, run this
    public void SelectPlayerSlot()
    {
        //Convert the text in the input field to an int
        int i = Convert.ToInt32(m_CharacterSlotInputer.text);
        //If the int is too big, stop
        if (i > m_SavedCharacters.Length)
        {
            Debug.Log("That Character does not exist");
            return;
        }
        else
        {
            //Load the Character from the corresponding array of saved Characters
            m_CharacterData = m_SavedCharacters[i - 1];
            LoadPlayer();
        }

    }

}
