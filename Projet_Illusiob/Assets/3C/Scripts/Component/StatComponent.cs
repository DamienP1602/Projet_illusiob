using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatComponent : MonoBehaviour
{
    public event Action OnDeath = null;
    public Action OnLoseHealth = null;

    [SerializeField] int health = 5;
    public int Health => health;

    private void Start()
    {
        OnDeath += VerifyHealthCount;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Spike"))
        {
            Debug.Log("Collision");
            SetDamages _damage = collision.gameObject.GetComponentInParent<SetDamages>();
            if (_damage == null) return;

            transform.position = _damage.PositionForRespawn;
            LoseHealth();
        }
    }

    void LoseHealth()
    {
        health--;
        OnLoseHealth?.Invoke();
    }

    void VerifyHealthCount()
    {
        if (health == 0)
            transform.position = Vector3.zero;
        else return;
    }
}
