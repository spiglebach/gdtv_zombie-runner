using System;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    private PlayerHealth target;
    [SerializeField] private int damage = 40;

    private void Awake() {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent() {
        if (target == null) return;
        target.TakeDamage(damage);
        Debug.Log("bang bang");
    }
}
