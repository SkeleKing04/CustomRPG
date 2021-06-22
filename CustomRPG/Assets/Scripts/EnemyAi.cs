using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public float m_DetectArea;
    GameManager gameManager;
    private NavMeshAgent m_NavAgent;
    private Rigidbody m_rigidbody;
    private bool following;
    // Start is called before the first frame update
    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
        m_NavAgent = GetComponent<NavMeshAgent>();
        following = false;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = (gameManager.m_Player.transform.position - transform.position).magnitude;
        if (distance > m_DetectArea)
        {
            m_NavAgent.SetDestination(gameManager.m_Player.transform.position);
            m_NavAgent.isStopped = false;
        }
        else
        {
            //m_NavAgent.isStopped = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            gameManager.beginBattle();
        }

    }
}
