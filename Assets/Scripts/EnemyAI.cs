using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]Transform target;
    [SerializeField]float range = 10f;
    Animator anim;
    NavMeshAgent agent;
    bool isProvoked = false;
    float distanceToTarget = Mathf.Infinity;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update() {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if(isProvoked) {
            EngageTarget();
            anim.SetBool("Alert", true);
        }

        if(distanceToTarget <= range) {
            isProvoked = true;
        }
    }

    void EngageTarget() {
        if(distanceToTarget >= agent.stoppingDistance) {
            ChaseTarget();
        }

        if(distanceToTarget <= agent.stoppingDistance) {
            AttackTarget();
        }
    }

    void ChaseTarget() {
        agent.SetDestination(target.position);
        anim.SetBool("Attack", false);
    }

    void AttackTarget() {
        anim.SetBool("Attack", true);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, range);
    }
}
