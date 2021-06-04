using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    CharacterInfoManager CharacterInfo;
    CharacterReader CharacterReader;
    GameManager gameManager;
    public Transform fireTransform;
    private float damage;
    public Rigidbody projectile;
    public float projectileSpeed;
    //public effectSO effect;
    public static bool attacking = false;
    public Component meleeScript;
    public Component physicsRangedScript;
    public Component rangedScript;
    public Component boostScript;
    public Component summonScript;

    // Start is called before the first frame update
    void Start()
    {
        CharacterInfo = FindObjectOfType<CharacterInfoManager>();
        CharacterReader = FindObjectOfType<CharacterReader>();
        gameManager = FindObjectOfType<GameManager>();
        meleeScript = GetComponent<Melee>();
        physicsRangedScript = GetComponent<physicsRanged>();
        rangedScript = GetComponent<Ranged>();
        boostScript = GetComponent<Boost>();
        summonScript = GetComponent<Summon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameState == GameManager.e_GameState.Playing)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0) && attacking == false)
            {
                meleeScript.gameObject.SetActive(true);
                physicsRangedScript.gameObject.SetActive(true);
                rangedScript.gameObject.SetActive(true);
                boostScript.gameObject.SetActive(true);
                summonScript.gameObject.SetActive(true);
                //damage = CharacterReader.m_Move1.damage;
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
    }
    public void CastAttack()
    {

    }
}
