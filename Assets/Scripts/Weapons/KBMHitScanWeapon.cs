using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KBMHitScanWeapon : MonoBehaviour {

    public Camera playerCam;
    public GameObject hitObject;
    public Transform player;

    public float damage = 10f;
    public float range;
    public float fireRate = 15f;

    private float nextTimeToFire = 0f;
    void Start()
    {
        player = GetComponentInParent<Transform>();
        playerCam = GetComponentInParent<Camera>();
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire){
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        AudioManager.instance.PlaySound("Sound_Shot");

        RaycastHit hit;

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit))
        {
            hitObject = hit.transform.gameObject;
            Health target = hitObject.GetComponent<Health>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
