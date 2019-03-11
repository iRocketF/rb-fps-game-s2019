using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnhandler;
    [HideInInspector]
    public WeaponAmmo wpAmmoBbq;
    [HideInInspector]
    public WeaponAmmo wpAmmoVege;
    [HideInInspector]
    public WeaponAmmo wpAmmoTP;
    public PlayerMovement pMov;


    public int playerNum;
    public float health = 100f;
    public float maxhealth = 100f;

    public void Start()
    {
        player = this.gameObject;
        spawnhandler = GameObject.Find("SpawnHandler");
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

        GameManager.instance.GivePoint(playerNum);

        health = maxhealth;
        wpAmmoBbq.currentAmmo = wpAmmoBbq.maxAmmo;
        wpAmmoTP.currentAmmo = wpAmmoTP.maxAmmo;
        wpAmmoVege.currentAmmo = wpAmmoVege.maxAmmo;
        pMov.currentBlinks = pMov.maxBlinks;


        spawnhandler.GetComponent<Spawn>().Respawn(player);
        
    }
}
