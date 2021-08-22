using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
    [SerializeField] private Transform target;
    [SerializeField] private float chaseRange = 5f;
    [SerializeField] private float attackCooldownInSeconds = 3f;

    private NavMeshAgent navMeshAgent;

    private bool isProvoked = false;
    private float distanceToTarget = Mathf.Infinity;
    private float remainingAttackCooldown;

    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        remainingAttackCooldown -= Time.deltaTime;
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        isProvoked = isProvoked || distanceToTarget <= chaseRange;
        if (isProvoked) {
            EngageTarget();
        }
    }

    private void EngageTarget() {
        if (distanceToTarget <= navMeshAgent.stoppingDistance) {
            Attack();
        } else {
            navMeshAgent.SetDestination(target.position);
        }
    }

    private void Attack() {
        if (remainingAttackCooldown > 0) return;
        Debug.Log("You have been attacked!");
        remainingAttackCooldown = attackCooldownInSeconds;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
