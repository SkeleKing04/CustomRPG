using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//  THIS SCRIPT IS NO LONGER USED
//  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!
public class HealthManager : MonoBehaviour
{
    public float HP;
    public float baseDamage;
    public float defence;
    public float speed;
    private float damage;
    GameManager GameManager;
    CharacterReader characterReader;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = Object.FindObjectOfType<GameManager>();
        characterReader = Object.FindObjectOfType<CharacterReader>();
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
