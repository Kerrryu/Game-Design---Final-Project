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
            case "Projectile":
                Destroy(other.gameObject);
                PlayerManager.instance.LoseLife();
                break;
            case "Powerup":
                if(PlayerManager.instance.powerupManager.CanPickup()) {
                    PlayerManager.instance.powerupManager.PickupPowerup(other.gameObject);
                }
                break;
        }
    }

    private void OnCollisionStay(Collision other) {
        switch(other.gameObject.tag) {
            case "Platform":
                if(transform.parent == null) {
                    var emptyObject = new GameObject();
                    emptyObject.transform.parent = other.transform;
                    transform.SetParent(emptyObject.transform);
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
                Destroy(other.gameObject.GetComponent<Collider>());
                other.gameObject.GetComponent<Animator>().Play("Collect");
                StartCoroutine(destoyCoin(other.gameObject));
                GameManager.COINS += 10;
                break;
        }
    }

    IEnumerator destoyCoin(GameObject coin) {
        yield return new WaitForSeconds(1.0f);
        Destroy(coin);
    }
}