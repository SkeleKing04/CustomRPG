using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public Collider hitBox;
    CharacterReader CharacterReader;
    CharacterInfoManager CharacterInfo;
    public int damage;
    private bool attacking = false;
    // Start is called before the first frame update
    void Start()
    {
        damage = CharacterInfo.moves[CharacterReader.m_Move1 - 1].damage;
        hitBox.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && attacking == false)
        {
            attacking = true;
            CastAttack();
        }
    }
    private void CastAttack()
    {
        Debug.Log("attacking for " + damage + " damage");
        hitBox.enabled = true;
        attacking = false;
    }
}
