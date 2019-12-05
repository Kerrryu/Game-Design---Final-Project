using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    private float health = 100f;
    public float maxHealth = 100f;

    private Transform _target;

    public virtual void Move() {

    }

    public virtual void Damage(float damage) {
        health -= damage;
        CheckDeath();
    }

    public virtual void CheckDeath() {

    }
}
