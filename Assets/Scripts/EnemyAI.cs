using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]Transform target;
    [SerializeField]float range = 10f;
    [SerializeField]float turnSpeed = 10f;
    [SerializeField]ParticleSystem muzzleFlash;
    [SerializeField]AudioSource gunshot;
    [SerializeField]float fireRate = 2f;
    [SerializeField]GameObject bullet;
    [SerializeField]Transform shooter;
    float nextTimeToFire = 0f;
    Animator anim;
    NavMeshAgent agent;
    public bool isProvoked = false;
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
        FaceTarget();
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
        if(Time.time >= nextTimeToFire) {
            nextTimeToFire = Time.time + 1f/fireRate;
            anim.SetBool("Attack", true);
            muzzleFlash.Play();
            gunshot.Play();
            GameObject shot = Instantiate(bullet, shooter.position, shooter.rotation);
        }
    }

    void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, range);
    }
}
