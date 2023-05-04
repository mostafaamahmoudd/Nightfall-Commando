using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent = null;
    private Animator animator;

    private Vector3 destination;

    [SerializeField] private Transform target;

    //private bool isWalking = false;
    public float idleTime = 3f;

    private void Start()
    {
        GetReferences();
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
        animator.SetBool("isWalking", true);

        //if (Vector3.Distance(transform.position, destination) < 0.5f)
        //{
        //    if (isWalking)
        //    {
        //        isWalking = false;
                
        //        Invoke("SetNewDestination", idleTime);
        //    }
        //}
        //else
        //{
        //    if (!isWalking)
        //    {
        //        isWalking = true;
        //        animator.SetBool("isWalking", true);
        //    }
        //}
    }

    private void RotateToTarget()
    {
        transform.LookAt(target);

        Vector3 dir = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(dir, Vector3.up);

        transform.rotation = rotation;
    }

    private void GetReferences()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        destination = agent.destination;
    }
}
