using UnityEngine;

public class BatteryPickup : MonoBehaviour {
    [SerializeField] private float flashlightIntensityToRestore = 2f;
    [SerializeField] private float flashlightAngleToRestore = 20f;
    
    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Player")) return;
        var flashlight = other.GetComponentInChildren<Flashlight>();
        if (!flashlight) return;
        flashlight.RestoreLightIntensity(flashlightIntensityToRestore);
        flashlight.RestoreLightAngle(flashlightAngleToRestore);
        Destroy(gameObject);
    }
}
