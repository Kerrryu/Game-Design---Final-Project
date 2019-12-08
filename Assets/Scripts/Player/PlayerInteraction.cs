using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {
    private void OnCollisionEnter(Collision other) {
        switch(other.gameObject.tag) {
            case "Enemy":
                other.gameObject.GetComponent<BaseEnemy>().Damage(10.0f);
                break;
        }
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