using System.Collections;
using UnityEngine;

public class ExtraJumps : BasePowerup {
    private int jumpsLeft = 5;

    public void Awake() {
        base.Register("Jumper");
    }

    public override void Activate() {
        base.Activate();
        jumpsLeft = 5;
        PlayerManager.instance.transform.Find("Model").GetComponent<Renderer>().material.color = Color.green;
    }

    public override void Tick() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            if(PlayerManager.instance.playerMovement.jumps <= 0) {
                jumpsLeft--;
                PlayerManager.instance.playerMovement.jumps++;
            }

            PlayerManager.instance.powerupManager.UpdatePowerupProgress(jumpsLeft, 5);
        }

        if(jumpsLeft <= 0) {
            Deactivate();
        }
    }

    public override void Deactivate() {
        base.Deactivate();
        PlayerManager.instance.transform.Find("Model").GetComponent<Renderer>().material.color = Color.white;
    }
}