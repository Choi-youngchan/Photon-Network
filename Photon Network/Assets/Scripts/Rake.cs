using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;

public enum State
{
    WALK,
    ATTACK,
    DIE 
}

public class Rake : MonoBehaviourPunCallbacks
{
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] GameObject destination;
    [SerializeField] State state;
    [SerializeField] Animator animator;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        state = State.WALK;

        destination = GameObject.Find("Nexus");
    }

    void Update()
    {
        switch(state)
        {
            case State.WALK : Walk(); return;
            case State.ATTACK : Attack(); return;
            case State.DIE : Die(); return;
        }
    }
    public void Walk()
    {
        navMeshAgent.SetDestination(destination.transform.position);
        transform.LookAt(destination.transform.position);
    }
    public void Attack() 
    {
        animator.Play("Attack");
    }
    public void Die()
    {
        PhotonNetwork.Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
         if( other.GetComponent<Collider>().tag == "Nexus")
         {
             state = State.ATTACK;
         }
    }
}
