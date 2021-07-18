using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

//A basic script for enemyAI
public class EnemyAi : MonoBehaviour
{
    //Area the player can be found in
    public float m_DetectArea;
    GameManager gameManager;
    private NavMeshAgent m_NavAgent;
    private Rigidbody m_rigidbody;
    public GameObject self;
    private bool following;
    private bool dead;
    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
        m_NavAgent = GetComponent<NavMeshAgent>();
        following = false;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    { //is the player is within the DetectArea value, follow the player
        float distance = (gameManager.m_Player.transform.position - transform.position).magnitude;
        if (distance < m_DetectArea)
        {
            m_NavAgent.SetDestination(gameManager.m_Player.transform.position);
            m_NavAgent.isStopped = false;
        }
        else
        {
            //m_NavAgent.isStopped = true;
        }
        if (dead == true)
        {
            Destroy(self);
        }
    }
    public void OnTriggerEnter(Collider other) // When colliding with the player, begin the battle
    {
        if (other.CompareTag("Player") && dead == false)
        {
            dead = true;
            gameManager.beginBattle();
        }   
    }
}
