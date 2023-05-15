using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent = null;
    private Animator animator;
    private Enemy enemy;

    [SerializeField] private Transform target;
    private void Start()
    {
        GetReferences();
    }

    private void Update()
    {
        float destination = Vector3.Distance(target.position, animator.transform.position);

       
        if (destination <= 2.5f)
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
            MoveToTarget();
        }
        
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
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
    }
}
