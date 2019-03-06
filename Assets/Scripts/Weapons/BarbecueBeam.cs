using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BarbecueBeam : MonoBehaviour
{
    public int playerNumber;
    public float damage = 100f;
    public float range;
    public float fireRate = 0.5f;
    public WeaponAmmo ammo;

    private bool rtPressed = false;
    private float nextTimeToFire = 0f;
    private Camera playerCam;
    private Transform player;
    private GameObject hitObject;
    public ParticleSystem laser;
    public ParticleSystem beam;
    private string fireString = "Fire1_Gamepad";


    void Start()
    {
        ammo = GetComponent<WeaponAmmo>();
        player = GetComponentInParent<Transform>();
        playerCam = GetComponentInParent<Camera>();
        laser = GetComponentInChildren<ParticleSystem>();

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
                StartCoroutine(Shoot());

            }

            if (Input.GetAxis(fireString) < 0.2f)
            {
                rtPressed = false;
            }
        }
        else if (ammo.currentAmmo == 0)
        {
            if (!rtPressed && Input.GetAxis(fireString) > 0.5f && Time.time >= nextTimeToFire)
            {
                rtPressed = true;
                AudioManager.instance.PlaySound("sound_ammoEmptyBbq");
            }
            if (Input.GetAxis(fireString) < 0.2f)
            {
                rtPressed = false;
            }
        }
    }

    IEnumerator Shoot()
    {

        laser.Play();
        AudioManager.instance.PlaySound("Sound_Bbq_Charge");
        yield return new WaitForSeconds(2);
        laser.Stop();

        beam.Play();

        ammo.currentAmmo--;

        RaycastHit hit;

        AudioManager.instance.PlaySound("Sound_Bbq_Shot");

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit))
        {
            hitObject = hit.transform.gameObject;
            Health target = hitObject.GetComponent<Health>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
        yield return new WaitForSeconds(0.25f);
        beam.Stop();

    }
}
