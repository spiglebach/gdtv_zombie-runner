using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
    [SerializeField] private Transform target;
    [SerializeField] private float chaseRange = 5f;
    [SerializeField] private float attackCooldownInSeconds = 3f;

    private NavMeshAgent navMeshAgent;
    private Animator animator;

    private bool isProvoked = false;
    private float distanceToTarget = Mathf.Infinity;
    private float remainingAttackCooldown;
    
    private static readonly int MoveTrigger = Animator.StringToHash("Move");
    private static readonly int AttackBool = Animator.StringToHash("Attack");

    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
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
        animator.SetTrigger(MoveTrigger);
        if (distanceToTarget <= navMeshAgent.stoppingDistance) {
            Attack();
        } else {
            navMeshAgent.SetDestination(target.position);
        }
    }

    private void Attack() {
        if (remainingAttackCooldown > 0) {
            animator.SetBool(AttackBool, false);
            return;
        }
        animator.SetBool(AttackBool, true);
        remainingAttackCooldown = attackCooldownInSeconds;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
