using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public GameObject stalkerEnemy;
    NavMeshAgent agent;
    public float range; //radius of sphere
    public Transform centrePoint; //centre of the area the agent wants to move around in
    public Transform player; //reference to the player's transform
    public float detectionRange = 10f; //how far the enemy can see the player
    public float chaseSpeed = 5f; //speed when chasing
    public float patrolSpeed = 2f; //speed when patrolling
    public float attackRange = 2f; //range within which the enemy will attack

    public GameObject Flash;
    public AudioSource HurtSound1;
    public AudioSource HurtSound2;
    public AudioSource HurtSound3;
    public int HurtGen;

    private bool isChasing = false;
    private Animator animator;
    private bool isAttacking = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = stalkerEnemy.GetComponent<Animator>(); // Get Animator component once
    }

    void Update()
    {
        if (isAttacking)
        {
            if (Vector3.Distance(transform.position, player.position) > attackRange)
            {
                isAttacking = false;
                agent.isStopped = false;
            }
            return;
        }

        if (CanSeePlayer())
        {
            if (Vector3.Distance(transform.position, player.position) <= attackRange)
            {
                StartCoroutine(AttackPlayer());
            }
            else
            {
                ChasePlayer();
            }
        }
        else
        {
            if (isChasing)
            {
                isChasing = false;
                agent.speed = patrolSpeed;
                animator.Play("Walking"); // Use animator directly
            }

            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                Vector3 point;
                if (RandomPoint(centrePoint.position, range, out point))
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                    agent.SetDestination(point);
                }
            }
        }
    }

    bool CanSeePlayer()
    {
        RaycastHit hit;
        if (Vector3.Distance(transform.position, player.position) <= detectionRange)
        {
            if (Physics.Raycast(transform.position, (player.position - transform.position).normalized, out hit, detectionRange))
            {
                if (hit.transform == player)
                {
                    return true;
                }
            }
        }
        return false;
    }

    void ChasePlayer()
    {
        isChasing = true;
        agent.speed = chaseSpeed;
        agent.SetDestination(player.position);
        animator.Play("Running"); // Use animator directly
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    IEnumerator AttackPlayer()
    {
        isAttacking = true;
        agent.isStopped = true; // Stop moving while attacking
        animator.Play("Zombie Attack"); // Play attack animation

        // Attack logic similar to the original ZombieAI script
        while (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            
            yield return new WaitForSeconds(2f);
            Flash.SetActive(true);
            HurtGen = Random.Range(1, 4);
            if (HurtGen == 1)
            {
                HurtSound1.Play();
            }
            else if (HurtGen == 2)
            {
                HurtSound2.Play();
            }
            else if (HurtGen == 3)
            {
                HurtSound3.Play();
            }
            yield return new WaitForSeconds(0.3f);
            Flash.SetActive(false);
            GlobalHealth.CurrentHealth -= 4;
            yield return new WaitForSeconds(2f);
        }
        agent.isStopped = false; // Resume moving
        isAttacking = false;
    }
}
