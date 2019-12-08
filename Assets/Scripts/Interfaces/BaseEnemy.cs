using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class BaseEnemy : MonoBehaviour
{
    private static string EnemyInfoPath = "Prefabs/EnemyInfo";
    private Slider UI_healthBar;
    private TextMeshProUGUI UI_nameText;

    private float health = 100f;
    public float maxHealth = 100f;

    public float speed = 1.0f;
    public float step {
        get {
            return speed * Time.deltaTime;
        }
    }

    private Transform _target;
    public Transform target {
        get {
            if(_target == null) {
                var go = GameObject.FindGameObjectWithTag("Player");
                _target = go.transform;
            }

            return _target;
        }
    }
    
    public virtual void Awake() {
        var enemyInfoObj = Resources.Load<GameObject>(EnemyInfoPath);
        var enemyInfoInstance = GameObject.Instantiate(enemyInfoObj, transform.position + new Vector3(0,1.21f,0), Quaternion.identity);
        enemyInfoInstance.transform.SetParent(transform);

        UI_healthBar = enemyInfoInstance.GetComponentInChildren<Slider>();
        UI_nameText = enemyInfoInstance.GetComponentInChildren<TextMeshProUGUI>();

        UI_nameText.text = Utility.GenerateName();
    }

    private void Update() {
        Move();
    }

    public virtual void Move() {
        if(target != null) {
            transform.LookAt(target);

            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }

    public void Damage(float damage) {
        health -= damage;
        CheckDeath();
        UpdateHealthBar();
    }

    public void UpdateHealthBar() {
        UI_healthBar.maxValue = maxHealth;
        UI_healthBar.value = health;
    }

    public void CheckDeath() {
        if(health <= 0) {
            DoDeath();
        }
    }

    public virtual void DoDeath() {
        Destroy(gameObject);
    }
}
