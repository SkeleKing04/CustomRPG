using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyAi : MonoBehaviour
{
    public float m_DetectArea;
    GameManager gameManager;
    private NavMeshAgent m_NavAgent;
    private Rigidbody m_rigidbody;
    public GameObject self;
    private bool following;
    public UnityEvent onTrigger;
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
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            die();
            onTrigger.Invoke();
        }   
    }
    public void die()
    {
        Destroy(self);
    }
}
