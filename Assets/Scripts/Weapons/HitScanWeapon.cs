using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScanWeapon : MonoBehaviour
{
    public int playerNumber;
    public float damage = 10f;
    public float range;
    public float fireRate = 15f;
    public WeaponAmmo ammo;

    private bool rtPressed = false;
    private float nextTimeToFire = 0f;
    private string fireString = "Fire1_Gamepad";
    private Camera playerCam;
    private GameObject hitObject;
    private Transform player;

    void Start()
    {
        ammo = GetComponent<WeaponAmmo>();
        player = GetComponentInParent<Transform>();
        playerCam = GetComponentInParent<Camera>();
        fireString += playerNumber;
    }

    void Update()
    {

        if (ammo.currentAmmo > 0)
        {
            if (Input.GetAxis(fireString) > 0.5f && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                ammo.currentAmmo--;
                Shoot();
            } 
        }
        else if (ammo.currentAmmo == 0)
        {
            if (!rtPressed && Input.GetAxis(fireString) > 0.5f && Time.time >= nextTimeToFire)
            {
                rtPressed = true;
                AudioManager.instance.PlaySound("sound_ammoEmpty");
            }
            if (Input.GetAxis(fireString) < 0.2)
            {
                rtPressed = false;
            }
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

