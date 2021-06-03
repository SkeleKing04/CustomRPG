using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public Collider hitBox;
    CharacterReader CharacterReader;
    CharacterInfoManager CharacterInfo;
    PlayerAttack PlayerAttack;
    public int damage;
    public Rigidbody projectile;
    public float projectileSpeed;
    //public effectSO effect;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAttack = FindObjectOfType<PlayerAttack>();
        CharacterInfo = FindObjectOfType<CharacterInfoManager>();
        CharacterReader = FindObjectOfType<CharacterReader>();
        damage = CharacterReader.m_Move1.damage;
        
        hitBox.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CastAttack()
    {
        PlayerAttack.attacking = true;
        Debug.Log("attacking for " + damage + " damage");
        hitBox.enabled = true;
        PlayerAttack.attacking = false;
    }
}
