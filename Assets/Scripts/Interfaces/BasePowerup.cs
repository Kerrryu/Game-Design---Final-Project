using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePowerup : MonoBehaviour
{
    [HideInInspector]
    public string powerupName;
    private float timer = 0.0f;
    private float baseTimer = 2.0f;
    private bool bActivated = false;

    public void Register(string newName) {
        powerupName = newName;
    }

    public virtual void Activate() {
        Debug.Log(powerupName + " used");
        bActivated = true;

        PlayerManager.instance.powerupManager.ShowVisual(powerupName);
    }

    private void Update() {
        if(bActivated) {
            Tick();
        }
    }

    public virtual void Tick() {
        timer += Time.deltaTime;

        if(timer >= baseTimer) {
            timer = 0.0f;
            Deactivate();
        }
    }

    public virtual void Deactivate() {
        Debug.Log(powerupName + " complete");
        bActivated = false;

        PlayerManager.instance.powerupManager.HideActiveVisual();
        PlayerManager.instance.powerupManager.HidePowerupUI();
    }
}
