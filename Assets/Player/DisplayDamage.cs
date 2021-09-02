using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour {
    [SerializeField] private Canvas damageCanvas;
    [SerializeField] private float displayDuration = .3f;

    private void Start() {
        damageCanvas.enabled = false;
    }

    public void Flash() {
        StartCoroutine(DisableWithDelay());
    }

    private IEnumerator DisableWithDelay() {
        damageCanvas.enabled = true;
        yield return new WaitForSeconds(displayDuration);
        damageCanvas.enabled = false;
    }
}
