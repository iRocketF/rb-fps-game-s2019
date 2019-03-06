using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {

    public float healAmount = 50f;
    public Health hp;
    public PickUpSpawner spawner;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // ParticleSystem
        AudioManager.instance.PlaySound("Sound_pickUp");
        hp = other.gameObject.GetComponent<Health>();
        hp.IncreaseHealth(healAmount);

        spawner = gameObject.GetComponentInParent<PickUpSpawner>();

        gameObject.SetActive(false);

    }
}
