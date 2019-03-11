using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStats : MonoBehaviour
{
    
    public float damage = 20;
    public Health hp;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlaySound("sound_playerImpact");
            hp = collision.gameObject.GetComponent<Health>();
            hp.TakeDamage(damage);
        }

        if (collision.gameObject.CompareTag("Environment"))
        {
            AudioManager.instance.PlaySound("sound_tp_impact");
        }
    }
}
