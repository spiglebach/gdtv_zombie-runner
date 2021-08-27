using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour {
    [SerializeField] private float zoomedInSensitivityX = 1f;
    [SerializeField] private float zoomedInSensitivityY = 1f;
    [SerializeField] private float zoomFOV = 20f;
    
    [SerializeField] private Camera playerCamera;
    [SerializeField] private RigidbodyFirstPersonController fpsController;
    
    private float defaultFOV;
    private bool isZoomed;
    private float defaultSensitivityX;
    private float defaultSensitivityY;

    private void Awake() {
        defaultSensitivityX = fpsController.mouseLook.XSensitivity;
        defaultSensitivityY = fpsController.mouseLook.YSensitivity;
        defaultFOV = playerCamera.fieldOfView;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            isZoomed = !isZoomed;
            ApplyCurrentZoomEffects();
        }
    }

    private void ApplyCurrentZoomEffects() {
        playerCamera.fieldOfView = isZoomed ? zoomFOV : defaultFOV;
        fpsController.mouseLook.XSensitivity =
            isZoomed ? zoomedInSensitivityX : defaultSensitivityX;
        fpsController.mouseLook.YSensitivity =
            isZoomed ? zoomedInSensitivityY : defaultSensitivityY;
    }

    public void OnDisable() {
        isZoomed = false;
        ApplyCurrentZoomEffects();
    }
}
