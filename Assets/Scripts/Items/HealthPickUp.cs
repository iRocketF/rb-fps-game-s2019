using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{

    public float healAmount = 50f;
    public Health hp;
    public PickUpSpawner spawner;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            hp = other.gameObject.GetComponent<Health>();
            if(hp.health < hp.maxhealth)
            {
                AudioManager.instance.PlaySound("Sound_pickUp");

                hp.IncreaseHealth(healAmount);

                spawner = gameObject.GetComponentInParent<PickUpSpawner>();

                gameObject.SetActive(false);
            }
        }
    }
}
