using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    public float ammoAmount;
    public WeaponAmmo ammo;
    public PickUpSpawner spawner;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            ammo = other.gameObject.GetComponentInChildren<WeaponAmmo>();
            ammoAmount = ammo.maxAmmo / 2;

            if (ammo.currentAmmo < ammo.maxAmmo)
            {
                AudioManager.instance.PlaySound("Sound_ammoPickUp");

                ammo.IncreaseAmmo(ammoAmount);

                spawner = gameObject.GetComponentInParent<PickUpSpawner>();

                gameObject.SetActive(false);
            } 
        }
    }
}
