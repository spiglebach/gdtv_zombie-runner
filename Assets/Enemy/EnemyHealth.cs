using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    [SerializeField] private int maximumHitpoints = 100;
    private int currentHitpoints;

    private void OnEnable() {
        currentHitpoints = maximumHitpoints;
    }

    public void TakeDamage(int damageAmount) {
        currentHitpoints -= damageAmount;
        if (currentHitpoints <= 0) {
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
    }
}
