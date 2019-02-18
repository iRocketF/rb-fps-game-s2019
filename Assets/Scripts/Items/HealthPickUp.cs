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

        gameObject.SetActive(false);

        StartCoroutine(Respawn());

    }

    private IEnumerator Respawn()
    {
        Debug.Log("Health cooldown 15 sec...");
        yield return new WaitForSeconds(15);
        gameObject.SetActive(true);
    }
}
