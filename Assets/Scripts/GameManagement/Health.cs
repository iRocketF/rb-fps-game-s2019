using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject player;
    public float health = 50f;
    public float maxhealth = 100f;

    public void Start()
    {
        player = this.gameObject;
    }
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
        //Give a point/kill/round to the killer

        Debug.Log("Player death...");
        health = maxhealth;

        player.GetComponent<Spawn>().Respawn(player);

    }
}
