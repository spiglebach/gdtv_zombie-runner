using UnityEngine;

public class Pickup : MonoBehaviour {
    [SerializeField] private AmmoType ammoType = AmmoType.RifleRound;
    [SerializeField] private int ammoAmount = 5;
    
    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Player")) return;
        if (!other.TryGetComponent(out Ammo ammo)) return;
        ammo.IncreaseAmmo(ammoType, ammoAmount);
        Destroy(gameObject);
    }
}
