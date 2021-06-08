using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float HP;
    public float baseDamage;
    public float defence;
    public float speed;
    private float damage;
    GameManager GameManager;
    CharacterReader characterReader;
    AttackManager atkManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = Object.FindObjectOfType<GameManager>();
        characterReader = Object.FindObjectOfType<CharacterReader>();
        atkManager = Object.FindObjectOfType<AttackManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<AttackManager>().Attacking == true)
        {
            calculateDamage(characterReader.baseDamage, characterReader.m_Move1.damage, defence);
        }
    }
    public void calculateDamage(float baseDamage, float moveDamage, float defence)
    {
        damage = (baseDamage * moveDamage)/ defence;
        takeDamage();
    }
    public void takeDamage()
    {
        HP -= damage;
        deathCheck();
    }
    public void deathCheck()
    {
        if (HP <= 0)
        {
            Debug.Log(gameObject.name + " is dead...\n( o< o)");
            if (gameObject.tag != "Player")
            {
                Destroy(gameObject);
            }
            else
            {
                GameManager.gameState = GameManager.e_GameState.Paused;
                GameManager.MenuState = GameManager.e_MenuState.ChooseCharacter;
            }
        }
    }
}
