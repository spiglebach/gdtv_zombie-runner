using UnityEngine;

public class WeaponSwitcher : MonoBehaviour {
    [SerializeField] private int currentWeapon = 0;
    private int previousWeapon;

    private void Awake() {
        SetActiveWeapon();
    }

    private void SetActiveWeapon() {
        for (int weaponIndex = 0; weaponIndex < transform.childCount; weaponIndex++) {
            transform.GetChild(weaponIndex).gameObject.SetActive(weaponIndex == currentWeapon);
        }
    }

    private void Update() {
        CycleWeapons();
    }

    private void CycleWeapons() {
        previousWeapon = currentWeapon;
        ProcessKeyInput();
        ProcessScrollInput();
        if (previousWeapon != currentWeapon) {
            SetActiveWeapon();
        }
    }

    private void ProcessKeyInput() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) currentWeapon = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) currentWeapon = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3)) currentWeapon = 2;
    }

    private void ProcessScrollInput() {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0) {
            currentWeapon++;
            if (currentWeapon >= transform.childCount) currentWeapon = 0;
        } else if (scroll < 0) {
            currentWeapon--;
            if (currentWeapon < 0) currentWeapon = transform.childCount - 1;
        }
    }
}
