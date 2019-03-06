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

    private float nextTimetoFire;
    private bool rtPressed = false;
    private string fireString = "Fire1_Gamepad";

    void Start()
    {
        fireString += playerNumber;
    }

    void Update()
    {
        if (!rtPressed && Input.GetAxis(fireString) > 0.5f && Time.time >= nextTimetoFire)
        {
            nextTimetoFire = Time.time + 1f / fireRate;
            Shoot();
            rtPressed = true;
        }

        if (Input.GetAxis(fireString) < 0.2)
        {
            rtPressed = false;
        }
    }

    void Shoot()
    {
        AudioManager.instance.PlaySound("Sound_Launcher");
        Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
        shot.AddForce(shotPos.forward * shotForce);
    }
}
