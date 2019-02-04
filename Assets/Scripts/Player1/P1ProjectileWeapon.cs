using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1ProjectileWeapon : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform shotPos;
    public float shotForce = 1000f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1_Gamepad1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        AudioManager.instance.PlaySound("Sound_Launcher");
        Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
        shot.AddForce(shotPos.forward * shotForce);
    }
}
