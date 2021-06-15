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
    public int[] m_Character;
    private int m_CurrentIndex;
    public ClassesSO m_Class;
    public SubclassesSO m_Subclass;
    public MoveInfo moveInfo;
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
    public string m_CharacterName;
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
    public float HP;
    public float baseDamage;
    public float defence;
    public float speed;

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
        m_CurrentIndex = 0;
        m_TheoreticalLength = 0;
        m_Class = null;
        m_Subclass = null;
        for (int i = 0; i < 4; i++)
        {
            moveInfo.m_Move[i] = null;
            moveInfo.m_MoveCoreCount[i] = 0;
            moveInfo.m_MoveCore1[i] = null;
            moveInfo.m_MoveCore2[i] = null;
            moveInfo.m_MoveCore3[i] = null;
        }
        foreach (Image image in m_MoveCoreDisplay)
        {
            image.gameObject.SetActive(false);
        }
        //Class
        Debug.Log("Current Index - " + m_CurrentIndex);
        m_Class = CharacterInfo.classes[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
        m_ClassIconDisplay.sprite = m_Class.classIcon;
        m_CurrentIndex += 2;
        m_TheoreticalLength += 2;

        //Subclass
        Debug.Log("Current Index - " + m_CurrentIndex);
        m_Subclass = CharacterInfo.subclasses[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
        m_ClassIconDisplay.color = m_Subclass.subclassColour;
        m_CurrentIndex += 2;
        m_TheoreticalLength += 2;

        //Moves
        for (int a = 0; a < 4; a++)
        {
            Debug.Log("Current Index - " + m_CurrentIndex);
            moveInfo.m_Move[a] = CharacterInfo.moves[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
            m_CurrentIndex += 2;
            m_TheoreticalLength += 2;
            Debug.Log("Current Index - " + m_CurrentIndex);
            moveInfo.m_MoveCoreCount[a] = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString());
            m_CurrentIndex++;
            m_TheoreticalLength++;
            Debug.Log("Current Index - " + m_CurrentIndex);
            for (int i = moveInfo.m_MoveCoreCount[a]; i > 0; i--)
            {
                Debug.Log(i);
                switch (i)
                {
                    case 1:
                        moveInfo.m_MoveCore1[0] = CharacterInfo.cores[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
                        m_CurrentIndex += 2;
                        m_TheoreticalLength += 2;
                        Debug.Log("11Current Index - " + m_CurrentIndex);
                        m_MoveCoreDisplay[a].gameObject.SetActive(true);
                        break;
                    case 2:
                        moveInfo.m_MoveCore2[a] = CharacterInfo.cores[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
                        m_CurrentIndex += 2;
                        m_TheoreticalLength += 2;
                        Debug.Log("12Current Index - " + m_CurrentIndex);
                        m_MoveCoreDisplay[1].gameObject.SetActive(true);
                        break;
                    case 3:
                        moveInfo.m_MoveCore3[a] = CharacterInfo.cores[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
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
        }
        /*moveInfo[1].m_Move = CharacterInfo.moves[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
        m_CurrentIndex += 2;
        m_TheoreticalLength += 2;
        Debug.Log("Current Index - " + m_CurrentIndex);
        moveInfo[1].m_MoveCoreCount = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString());
        m_CurrentIndex++;
        m_TheoreticalLength++;
        Debug.Log("Current Index - " + m_CurrentIndex);
        for (int i = moveInfo[1].m_MoveCoreCount; i > 0; i--)
        {
            Debug.Log(i);
            switch (i)
            {
                case 1:
                    moveInfo[1].m_MoveCore1 = CharacterInfo.cores[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("11Current Index - " + m_CurrentIndex);
                    m_MoveCoreDisplay[3].gameObject.SetActive(true);
                    break;
                case 2:
                    moveInfo[1].m_MoveCore2 = CharacterInfo.cores[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("12Current Index - " + m_CurrentIndex);
                    m_MoveCoreDisplay[4].gameObject.SetActive(true);
                    break;
                case 3:
                    moveInfo[1].m_MoveCore3 = CharacterInfo.cores[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
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
        moveInfo[2].m_Move = CharacterInfo.moves[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
        m_CurrentIndex += 2;
        m_TheoreticalLength += 2;
        Debug.Log("Current Index - " + m_CurrentIndex);
        moveInfo[2].m_MoveCoreCount = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString());
        m_CurrentIndex++;
        m_TheoreticalLength++;
        Debug.Log("Current Index - " + m_CurrentIndex);
        for (int i = moveInfo[2].m_MoveCoreCount; i > 0; i--)
        {
            Debug.Log(i);
            switch (i)
            {
                case 1:
                    moveInfo[2].m_MoveCore1 = CharacterInfo.cores[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("11Current Index - " + m_CurrentIndex);
                    m_MoveCoreDisplay[6].gameObject.SetActive(true);
                    break;
                case 2:
                    moveInfo[2].m_MoveCore2 = CharacterInfo.cores[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("12Current Index - " + m_CurrentIndex);
                    m_MoveCoreDisplay[7].gameObject.SetActive(true);
                    break;
                case 3:
                    moveInfo[2].m_MoveCore3 = CharacterInfo.cores[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
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
        moveInfo[3].m_Move = CharacterInfo.moves[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
        m_CurrentIndex += 2;
        m_TheoreticalLength += 2;
        Debug.Log("Current Index - " + m_CurrentIndex);
        moveInfo[3].m_MoveCoreCount = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString());
        m_CurrentIndex++;
        m_TheoreticalLength++;
        Debug.Log("Current Index - " + m_CurrentIndex);
        for (int i = moveInfo[3].m_MoveCoreCount; i > 0; i--)
        {
            Debug.Log(i);
            switch (i)
            {
                case 1:
                    moveInfo[3].m_MoveCore1 = CharacterInfo.cores[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("11Current Index - " + m_CurrentIndex);
                    m_MoveCoreDisplay[9].gameObject.SetActive(true);
                    break;
                case 2:
                    moveInfo[3].m_MoveCore2 = CharacterInfo.cores[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("12Current Index - " + m_CurrentIndex);
                    m_MoveCoreDisplay[10].gameObject.SetActive(true);
                    break;
                case 3:
                    moveInfo[3].m_MoveCore3 = CharacterInfo.cores[Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString()) - 1];
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
        }*/
        m_CharacterName = "";
        for (int i = m_TheoreticalLength; i < m_CharacterData.Length; i++)
        {
            Debug.Log(m_TheoreticalLength);
            m_CharacterName += m_CharacterData[i];
            m_TheoreticalLength++;
        }
        m_CharacterBlerb.text = m_Subclass.name + " " + m_Class.name + " " + m_CharacterName;
        foreach (Image image in m_MoveCoreDisplay)
        {
            image.color = m_ClassIconDisplay.color = m_Subclass.subclassColour;
        }
        HP = m_Class.HP;
        baseDamage = m_Class.baseDamage;
        defence = m_Class.defence;
        speed = m_Class.speed;
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
