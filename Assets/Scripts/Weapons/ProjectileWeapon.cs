using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    public int playerNumber;
    public Rigidbody projectile;
    public Transform shotPos;
    public float shotForce = 1000f;
    public float fireRate = 1f;
    public WeaponAmmo ammo;

    private float nextTimeToFire;
    private bool rtPressed = false;
    private string fireString = "Fire1_Gamepad";

    void Start()
    {
        ammo = GetComponent<WeaponAmmo>();
        fireString += playerNumber;
    }

    void Update()
    {

        if (ammo.currentAmmo > 0)
        {
            if (!rtPressed && Input.GetAxis(fireString) > 0.5f && Time.time >= nextTimeToFire)
            {
                rtPressed = true;
                nextTimeToFire = Time.time + 1f / fireRate;
                ammo.currentAmmo--;
                Shoot();
            }

            if (Input.GetAxis(fireString) < 0.2)
            {
                rtPressed = false;
            }
        } else if (ammo.currentAmmo == 0)
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
        AudioManager.instance.PlaySound("Sound_Launcher");
        Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
        shot.AddForce(shotPos.forward * shotForce);
    }
}
