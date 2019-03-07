using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBoxTrigger : MonoBehaviour
{
    public Health hp;
    public float damage = 100f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            hp = other.gameObject.GetComponent<Health>();
            hp.TakeDamage(damage);
        }
        if(other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
        }
    }
}
