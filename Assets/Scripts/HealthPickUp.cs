using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {

    public float healAmount = 25f;
    public Health hp;

    private void OnTriggerEnter(Collider other)
    {
        // ParticleSystem
        hp = other.gameObject.GetComponent<Health>();
        hp.IncreaseHealth(healAmount);
  
        Destroy(gameObject);
    }
}
