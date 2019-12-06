using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {
    private void OnCollisionEnter(Collision other) {
        
    }

    private void OnCollisionStay(Collision other) {
        
    }

    private void OnCollisionExit(Collision other) {
        
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