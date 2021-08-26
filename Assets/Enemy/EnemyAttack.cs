using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    [SerializeField] private Transform target;
    [SerializeField] private int damage = 40;

    public void AttackHitEvent() {
        if (target == null) return;
        Debug.Log("bang bang");
    }
}
