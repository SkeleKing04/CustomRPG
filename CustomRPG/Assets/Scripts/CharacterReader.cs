using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterReader : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
        m_CurrentIndex = 0;
        Debug.Log("Current Index - " + m_CurrentIndex);
        //Class
        m_Class = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
        m_CurrentIndex += 2;
        m_TheoreticalLength += 2;

        Debug.Log("Current Index - " + m_CurrentIndex);
        m_Subclass = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
        m_CurrentIndex += 2;
        m_TheoreticalLength += 2;

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
                    break;
                case 2:
                    m_Move1Core2 = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("12Current Index - " + m_CurrentIndex);
                    break;
                case 3:
                    m_Move1Core3 = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("13Current Index - " + m_CurrentIndex);
                    break;
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
                    break;
                case 2:
                    m_Move2Core2 = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("12Current Index - " + m_CurrentIndex);
                    break;
                case 3:
                    m_Move2Core3 = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("13Current Index - " + m_CurrentIndex);
                    break;
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
                    break;
                case 2:
                    m_Move3Core2 = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("12Current Index - " + m_CurrentIndex);
                    break;
                case 3:
                    m_Move3Core3 = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("13Current Index - " + m_CurrentIndex);
                    break;
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
                    break;
                case 2:
                    m_Move4Core2 = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("12Current Index - " + m_CurrentIndex);
                    break;
                case 3:
                    m_Move4Core3 = Convert.ToInt32(m_CharacterData[m_CurrentIndex].ToString() + m_CharacterData[m_CurrentIndex + 1].ToString());
                    m_CurrentIndex += 2;
                    m_TheoreticalLength += 2;
                    Debug.Log("13Current Index - " + m_CurrentIndex);
                    break;
            }
        }
        //for(int i = m_CharacterData.Length; )
        //m_CharacterName = 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
