using UnityEngine;

public class Weapon : MonoBehaviour {
    [SerializeField] private Camera FPCamera;
    [SerializeField] private float range = 100f;
    [SerializeField] private int damage = 30;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject hitImpact;
    [SerializeField] private float shotCooldownInSeconds = 1f;
    private float remainingShotCooldown;

    
    void Update() {
        remainingShotCooldown -= Time.deltaTime;
        if (Input.GetButton("Fire1")) {
            Shoot();
        }
    }

    private void Shoot() {
        if (remainingShotCooldown > 0) return;
        remainingShotCooldown = shotCooldownInSeconds;
        PlayMuzzleFlash();
        HitTarget();
    }

    private void HitTarget() {
        if (!Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, 
                out RaycastHit hit, range)) 
            return;
        HitEffect(hit);
        EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
        if (!enemyHealth) return;
        enemyHealth.TakeDamage(damage);
    }

    private void HitEffect(RaycastHit hitInfo) {
        GameObject hitEffect = Instantiate(hitImpact, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
        Destroy(hitEffect, .1f);
    }

    private void PlayMuzzleFlash() {
        if (!muzzleFlash) return;
        muzzleFlash.Play();
    }
}
