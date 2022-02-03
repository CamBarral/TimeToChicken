using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10.0f;

    //Attack
    public int damage;
    private float cooldown = 1.0f;
    private float timeSinceAttack = 1.0f;


    Transform target;
    NavMeshAgent agent;
    PlayerHealth playerHealth;

    private Animator chickenAnimator;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

        playerHealth = PlayerManager.instance.player.GetComponent<PlayerHealth>();

        chickenAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        timeSinceAttack += Time.deltaTime;

        chickenAnimator.SetBool("Run", true);

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
        }

        if (distance <= agent.stoppingDistance)
        {
            FaceTarget();

            if (playerHealth.currentHealth >= 0 && timeSinceAttack >= cooldown)
            {
                timeSinceAttack = 0;
                Attack();
            }

        }
    }
    void Attack()
    {
        chickenAnimator.SetTrigger("Attack");
        playerHealth.TakeDamage(damage);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        /*transform.rotation = lookRotation;*/
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5.0f); //Smooth rotation.
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
