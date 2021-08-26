using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    private void OnEnable() {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount) {
        currentHealth -= amount;
        if (currentHealth <= 0) {
            Die();
        }
    }

    private void Die() {
        Debug.Log("Player died!");
    }
}
