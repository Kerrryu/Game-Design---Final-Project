using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {
    private void OnCollisionEnter(Collision other) {
        switch(other.gameObject.tag) {
            case "Enemy":
                PlayerManager.instance.LoseLife();
                break;
            case "Deathzone":
                PlayerManager.instance.InstantKill();
                break;

        }
    }

    private void OnCollisionStay(Collision other) {
        switch(other.gameObject.tag) {
            case "Platform":
                if(transform.parent == null) {
                    transform.SetParent(other.transform);
                }
                break;
        }
    }

    private void OnCollisionExit(Collision other) {
        switch(other.gameObject.tag) {
            case "Platform":
                transform.SetParent(null);
                break;
        }
    }

    private void OnTriggerEnter(Collider other) {
        switch(other.gameObject.tag) {
            case "Coin":
                Destroy(other.gameObject);
                GameManager.COINS += 10;
                break;
        }
    }
}