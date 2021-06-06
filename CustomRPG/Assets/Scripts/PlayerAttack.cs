using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    CharacterReader CharacterReader;
    GameManager gameManager;
    private float move1Cooldown;
    private float move2Cooldown;
    private float move3Cooldown;
    private float move4Cooldown;

    // Start is called before the first frame update
    void Start()
    {
        CharacterReader = FindObjectOfType<CharacterReader>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameState == GameManager.e_GameState.Playing)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0) && move1Cooldown == 0)
            {
                CharacterReader.m_Move1.CastAttack();
            }
            if (Input.GetKeyUp(KeyCode.Mouse1) && move2Cooldown == 0)
            {
                CharacterReader.m_Move2.CastAttack();
            }
            if (Input.GetKeyUp(KeyCode.Q) && move3Cooldown == 0)
            {
                CharacterReader.m_Move3.CastAttack();
            }
            if (Input.GetKeyUp(KeyCode.E) && move4Cooldown == 0)
            {
                CharacterReader.m_Move4.CastAttack();

            }
        }

    }
}
