using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerupManager : MonoBehaviour
{
#region Visuals
    public Transform visualPowerupParent;
    private GameObject activeVisual = null;

    public void ResetPowerup() {
        HideActiveVisual();
        HidePowerupUI();
        currentPowerup = null;
    }

    public void ShowVisual(string parentName) {
        HideActiveVisual();

        activeVisual = visualPowerupParent.Find(parentName).gameObject;
        if(activeVisual) {
            activeVisual.gameObject.SetActive(true);
        }
    }

    public void HideActiveVisual() {
        if(activeVisual) {
            activeVisual.gameObject.SetActive(false);
            activeVisual = null;
        }
    }
#endregion

#region Powerups
    [HideInInspector]
    public GameObject currentPowerupObj;
    private BasePowerup currentPowerup;

    public GameObject powerupCanvasParent;
    public TextMeshProUGUI powerupNameText;
    public Slider powerupProgressSlider;

    private void Awake() {
        powerupCanvasParent.SetActive(false);
    }

    public bool CanPickup() {
        return currentPowerup == null;
    }

    public void PickupPowerup(GameObject powerupObject) {
        currentPowerup = powerupObject.GetComponent<BasePowerup>();
        currentPowerupObj = powerupObject.gameObject;
        powerupObject.transform.position = new Vector3(-9999,-9999,-9999);

        currentPowerup.Activate();
        ShowPowerupUI();
    }

    public void ShowPowerupUI() {
        powerupCanvasParent.SetActive(true);
        powerupNameText.text = currentPowerup.powerupName;
        powerupProgressSlider.value = 1;
    }

    public void HidePowerupUI() {
        powerupCanvasParent.SetActive(false);
    }

    public void UpdatePowerupProgress(float minValue, float maxValue) {
        var progress = minValue/maxValue;
        powerupProgressSlider.value = progress;
    }
#endregion
}
