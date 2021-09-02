using System;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    private PlayerHealth target;
    private DisplayDamage damageDisplayer;
    [SerializeField] private int damage = 40;

    private void Awake() {
        target = FindObjectOfType<PlayerHealth>();
        damageDisplayer = FindObjectOfType<DisplayDamage>();
    }

    public void AttackHitEvent() {
        if (target == null) return;
        target.TakeDamage(damage);
        if (!damageDisplayer) return;
        damageDisplayer.Flash();
    }
}
