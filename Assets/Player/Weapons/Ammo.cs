using UnityEngine;

public class Ammo : MonoBehaviour {
    [SerializeField] private AmmoSlot[] ammoSlots;

    public int GetAmmoAmount(AmmoType ammoType) {
        foreach (var ammoSlot in ammoSlots) {
            if (ammoSlot.ammoType == ammoType) {
                return ammoSlot.ammoAmount;
            }
        }
        return 0;
    }
    
    public void ReduceAmmo(AmmoType ammoType) {
        foreach (var ammoSlot in ammoSlots) {
            if (ammoSlot.ammoType == ammoType) {
                ammoSlot.ammoAmount--;
            }
        }
    }

    [System.Serializable]
    private class AmmoSlot {
        public AmmoType ammoType;
        public int ammoAmount;
    }
}
