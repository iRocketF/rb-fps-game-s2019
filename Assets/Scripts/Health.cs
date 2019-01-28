using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 50f;
    public float maxhealth = 100f;

    public void Update()
    {
        if(health >= maxhealth)
        {
            health = maxhealth;
        }
    }

    public void IncreaseHealth(float amount)
    {
        //ParticleSystem/ShaderGraph
        health += amount;
    }

    public void TakeDamage(float amount)
    {
        //particle system/shader
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {

        //ShaderGraph here
        Debug.Log("Player death...");
        Destroy(this.gameObject, 1f);
    }
}
