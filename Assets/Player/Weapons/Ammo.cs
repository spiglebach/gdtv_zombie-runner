using UnityEngine;

public class Ammo : MonoBehaviour {
    [SerializeField] private int ammoAmount = 10;

    public int AmmoAmount => ammoAmount;

    public void ReduceAmmo() {
        ammoAmount--;
    }

}
