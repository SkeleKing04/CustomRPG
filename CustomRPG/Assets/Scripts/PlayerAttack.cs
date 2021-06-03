using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    CharacterInfoManager CharacterInfo;
    CharacterReader CharacterReader;
    public Transform fireTransform;
    private float damage;
    public Rigidbody projectile;
    public float projectileSpeed;
    //public effectSO effect;
    public static bool attacking = false;
    // Start is called before the first frame update
    void Start()
    {
        CharacterInfo = FindObjectOfType<CharacterInfoManager>();
        CharacterReader = FindObjectOfType<CharacterReader>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Mouse0) && attacking == false)
        {
            damage = CharacterReader.m_Move1.damage;
            projectile = CharacterReader.m_Move1.projectile;
            projectile = CharacterReader.m_Move1.projectile;
            CastAttack();
        }
        if (Input.GetKeyUp(KeyCode.Mouse1) && attacking == false)
        {
            damage = CharacterReader.m_Move2.damage;
            projectile = CharacterReader.m_Move2.projectile;
            projectile = CharacterReader.m_Move2.projectile;
            CastAttack();
        }
        if (Input.GetKeyUp(KeyCode.Q) && attacking == false)
        {
            damage = CharacterReader.m_Move3.damage;
            projectile = CharacterReader.m_Move3.projectile;
            projectile = CharacterReader.m_Move3.projectile;
            CastAttack();
        }
        if (Input.GetKeyUp(KeyCode.E) && attacking == false)
        {
            damage = CharacterReader.m_Move4.damage;
            projectile = CharacterReader.m_Move4.projectile;
            projectile = CharacterReader.m_Move4.projectile;
            CastAttack();
        }
    }
    public void CastAttack()
    {

    }
}
