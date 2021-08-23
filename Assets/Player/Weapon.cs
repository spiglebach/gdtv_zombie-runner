using UnityEngine;

public class Weapon : MonoBehaviour {
    [SerializeField] private Camera FPCamera;
    [SerializeField] private float range = 100f;
    
    void Update()
    {
        if (Input.GetButton("Fire1")) {
            Shoot();
        }
    }

    private void Shoot() {
        if (Physics.Raycast(FPCamera.transform.position,
            FPCamera.transform.forward, out RaycastHit hit, range)) {
            Debug.Log($"{hit.transform.gameObject.name} hit!");
        }
    }
}
