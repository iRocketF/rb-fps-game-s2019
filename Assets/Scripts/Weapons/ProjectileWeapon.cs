using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    public int playerNumber;
    public Rigidbody projectile;
    public Transform shotPos;
    public float shotForce = 1000f;

    private bool rtPressed = false;
    private string fireString = "Fire1_Gamepad";

    // Start is called before the first frame update
    void Start()
    {
        fireString += playerNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if (!rtPressed && Input.GetAxis(fireString) > 0.5f)
        {
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
