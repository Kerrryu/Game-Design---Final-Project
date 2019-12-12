using System.Collections;
using UnityEngine;

public class Bomber : BasePowerup {
    private GameObject explosion;

    public void Awake() {
        base.Register("Bomber (Press Q)");
    }

    public override void Activate() {
        base.Activate();
        PlayerManager.instance.transform.Find("Model").GetComponent<Renderer>().material.color = Color.black;
    }

    public override void Tick() {
        if(Input.GetKeyDown(KeyCode.Q)) {
            var explosionPrefab = Resources.Load<GameObject>("Prefabs/Explosion");
            explosion = GameObject.Instantiate(explosionPrefab, PlayerManager.instance.transform.position, Quaternion.identity);
            explosion.GetComponent<ParticleSystem>().Play();
            StartCoroutine(delayDeactive());

            Collider[] objs = Physics.OverlapSphere(PlayerManager.instance.transform.position, 5.0f);
            for(int i = 0; i < objs.Length; i++) {
                if(objs[i].gameObject.CompareTag("Enemy")) {
                    Destroy(objs[i].gameObject);
                }
            }
        }
    }

    IEnumerator delayDeactive() {
        yield return new WaitForSeconds(1.0f);
        Destroy(explosion);
        Deactivate();
    }

    public override void Deactivate() {
        base.Deactivate();
        PlayerManager.instance.transform.Find("Model").GetComponent<Renderer>().material.color = Color.white;
    }
}