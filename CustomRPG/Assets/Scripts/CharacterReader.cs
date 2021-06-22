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
    private CharacterInfoManager CharacterInfo;
    public string m_CharacterData;
    public int m_CharacterSlot;
    private int m_CurrentIndex;
    public CharacterArray[] character = new CharacterArray[10];
    /*public MovesSO m_Move1;
    public int m_Move1CoreCount;
    public CoreSO m_Move1Core1 ;
    public CoreSO m_Move1Core2 ;
    public CoreSO m_Move1Core3 ;
    public MovesSO m_Move2 ;
    public int m_Move2CoreCount;
    public CoreSO m_Move2Core1 ;
    public CoreSO m_Move2Core2 ;
    public CoreSO m_Move2Core3 ;
    public MovesSO m_Move3 ;
    public int m_Move3CoreCount;
    public CoreSO m_Move3Core1 ;
    public CoreSO m_Move3Core2 ;
    public CoreSO m_Move3Core3 ;
    public MovesSO m_Move4 ;
    public int m_Move4CoreCount;
    public CoreSO m_Move4Core1;
    public CoreSO m_Move4Core2;
    public CoreSO m_Move4Core3;*/

    public int m_TheoreticalLength;
    public string currentDirectory;
    public Image m_ClassIconDisplay;
    public Image[] m_MoveCoreDisplay;
    private string SavedPlayersFileName = "SavedPlayers.txt";
    public string[] m_SavedCharacters = new string[5];
    //public string[] m_characterClasses = new string[99];
    //public string[] m_characterSubclasses = new string[99];
    public InputField m_CharacterSlotInputer;
    public Text m_CharacterBlerb;

    [System.Serializable]
    public class CharacterArray
    {
        public ClassesSO m_Class;
        public SubclassesSO m_Subclass;
        public MoveInfo moveInfo;
        public string m_CharacterName;
        public float HP;
        public float baseDamage;
        public float defence;
        public float speed;
    }
    [System.Serializable]
    public class MoveInfo
    {
        public MovesSO[] m_Move = new MovesSO[4];
        public int[] m_MoveCoreCount = new int[4];
        public CoreSO[] m_MoveCore1 = new CoreSO[4];
        public CoreSO[] m_MoveCore2 = new CoreSO[4];
        public CoreSO[] m_MoveCore3 = new CoreSO[4];
    }

    // Start is called before the first frame update
    void Start()
    {
        currentDirectory = Application.dataPath;
        LoadSavedPlayersFromFile();
        m_GameManager = FindObjectOfType<GameManager>();
        CharacterInfo = FindObjectOfType<CharacterInfoManager>();
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
        //m_characterClasses = File.ReadAllLines(currentDirectory + "/characterValues/characterClasses.txt");
        //m_characterSubclasses = File.ReadAllLines(currentDirectory + "/characterValues/characterSubclasses.txt");
        //Debug.Log(m_characterClasses[0].ToString());
    }
    public void LoadPlayer()
    {
        Debug.Log(Convert.ToInt32(m_CharacterSlotInputer.text) - 1);
        m_CharacterSlot = Convert.ToInt32(m_CharacterSlotInputer.text) - 1;
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
        foreach (Image image in m_MoveCoreDisplay)
        {
            image.gameObject.SetActive(false);
        }
        //Class
        //Debug.Log("Current Index - " + m_CurrentIndex);
        character[m_CharacterSlot].m_Class = CharacterInfo.classes[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
        m_ClassIconDisplay.sprite = character[m_CharacterSlot].m_Class.classIcon;
        m_CurrentIndex += 2;
        m_TheoreticalLength += 2;

        //Subclass
        //Debug.Log("Current Index - " + m_CurrentIndex);
        character[m_CharacterSlot].m_Subclass = CharacterInfo.subclasses[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
        m_ClassIconDisplay.color = character[m_CharacterSlot].m_Subclass.subclassColour;
        m_CurrentIndex += 2;
        m_TheoreticalLength += 2;

        //Moves
        for (int a = 0; a < 4; a++)
        {
            Debug.Log("a is " + a);
            //Debug.Log("Current Index - " + m_CurrentIndex);
            character[m_CharacterSlot].moveInfo.m_Move[a] = CharacterInfo.moves[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
            m_CurrentIndex += 2;
            m_TheoreticalLength += 2;
            //Debug.Log("Current Index - " + m_CurrentIndex);
            character[m_CharacterSlot].moveInfo.m_MoveCoreCount[a] = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString());
            m_CurrentIndex++;
            m_TheoreticalLength++;
            //Debug.Log("Current Index - " + m_CurrentIndex);
            for (int i = character[m_CharacterSlot].moveInfo.m_MoveCoreCount[a]; i > 0; i--)
            {
                Debug.Log(i);
                switch (i)
                {
                    case 1:
                        character[m_CharacterSlot].moveInfo.m_MoveCore1[a] = CharacterInfo.cores[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
                        //Debug.Log("11Current Index - " + m_CurrentIndex);
                        break;
                    case 2:
                        character[m_CharacterSlot].moveInfo.m_MoveCore2[a] = CharacterInfo.cores[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
                        //Debug.Log("12Current Index - " + m_CurrentIndex);
                        break;
                    case 3:
                        character[m_CharacterSlot].moveInfo.m_MoveCore3[a] = CharacterInfo.cores[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
                        //Debug.Log("13Current Index - " + m_CurrentIndex);
                        break;
                    default:
                        Debug.Log("ILLIGAL CHARACTER. ABORTING");
                        Application.Quit();
                        return;
                }
                m_CurrentIndex += 2;
                m_TheoreticalLength += 2;
                m_MoveCoreDisplay[((3 * a) + i) - 1].gameObject.SetActive(true);
            }
        }
        character[m_CharacterSlot].m_CharacterName = "";
        for (int i = m_TheoreticalLength; i < m_CharacterData.Length; i++)
        {
            //Debug.Log(m_TheoreticalLength);
            character[m_CharacterSlot].m_CharacterName += m_CharacterData[i];
            m_TheoreticalLength++;
        }
        m_CharacterBlerb.text = character[m_CharacterSlot].m_Subclass.name + " " + character[m_CharacterSlot].m_Class.name + " " + character[m_CharacterSlot].m_CharacterName;
        foreach (Image image in m_MoveCoreDisplay)
        {
            image.color = m_ClassIconDisplay.color = character[m_CharacterSlot].m_Subclass.subclassColour;
        }
        character[m_CharacterSlot].HP = character[m_CharacterSlot].m_Class.HP;
        character[m_CharacterSlot].baseDamage = character[m_CharacterSlot].m_Class.baseDamage;
        character[m_CharacterSlot].defence = character[m_CharacterSlot].m_Class.defence;
        character[m_CharacterSlot].speed = character[m_CharacterSlot].m_Class.speed;
    }
    public void SelectPlayerSlot()
    {
        int i = Convert.ToInt32(m_CharacterSlotInputer.text);
        //Debug.Log(i);
        if (i > m_SavedCharacters.Length)
        {
            //Debug.Log("TOO LONG");
            return;
        }
        m_CharacterData = m_SavedCharacters[i - 1];
        LoadPlayer();
    }

}
