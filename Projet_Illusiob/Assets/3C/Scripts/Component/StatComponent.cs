using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatComponent : MonoBehaviour
{
    public event Action OnDeath = null;
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
            SetDamages _damage = collision.gameObject.GetComponent<SetDamages>();
            if (_damage == null) return;

            transform.position = _damage.PositionForRespawn;
        }
    }

    void LoseHealth()
    {
        health--;
        OnDeath?.Invoke();
    }
    
    void VerifyHealthCount()
    {
        if (health == 0)
            transform.position = Vector3.zero;
        else return;
    }
}
