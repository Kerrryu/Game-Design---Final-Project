using UnityEngine;

public class PlayerDamageDeal : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Enemy")) {
            other.gameObject.GetComponent<BaseEnemy>().DoDeath();
        }
    }
}