using UnityEngine;

public class Flashlight : MonoBehaviour {
    [SerializeField] private float intensityDecay = .1f;
    [SerializeField] private float angleDecay = 1f;
    [SerializeField] private float minAngle = 60f;
    [SerializeField] private float maxAngle = 100f;
    [SerializeField] private float maxIntensity = 3;
    
    private Light flashlight;

    private void Awake() {
        flashlight = GetComponent<Light>();
    }
    
    void Update() {
        DecreaseLightIntensity();
        DecreaseLightAngle();
    }

    private void DecreaseLightAngle() {
        var newAngle = flashlight.spotAngle - Time.deltaTime * angleDecay;
        flashlight.spotAngle = Mathf.Clamp(newAngle, minAngle, maxAngle);
    }

    private void DecreaseLightIntensity() {
        var newIntensity = flashlight.intensity - Time.deltaTime * intensityDecay;
        flashlight.intensity = Mathf.Clamp(newIntensity, 0, maxIntensity);
    }

    public void RestoreLightAngle(float amount) {
        var newAngle = flashlight.spotAngle + amount;
        flashlight.spotAngle = Mathf.Clamp(newAngle, minAngle, maxAngle);
    }

    public void RestoreLightIntensity(float amount) {
        var newIntensity = flashlight.intensity + amount;
        flashlight.intensity = Mathf.Clamp(newIntensity, 0, maxIntensity);
    }
}
