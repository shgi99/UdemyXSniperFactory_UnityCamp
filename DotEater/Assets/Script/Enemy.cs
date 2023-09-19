using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    NavMeshAgent agent;
    Animator anim;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.transform.position;
        anim.SetFloat("Speed", agent.velocity.magnitude);
    }
}
