using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : BasePowerup
{
    private int charges = 3;

    public void Awake() {
        base.Register("Teleport");
        charges = 3;
    }

    public override void Activate() {
        base.Activate();
    }

    public override void Tick() {
        if(charges <= 0) {
            Deactivate();
        }

        if(Input.GetMouseButtonDown(0)) {
            charges --;

            PlayerManager.instance.powerupManager.UpdatePowerupProgress(charges, 3);
            PlayerManager.instance.transform.position = Utility.GetMousePos();
            PlayerManager.instance.playerMovement.jumps = 2;
        }
    }

    public override void Deactivate() {
        base.Deactivate();
    }
}
