using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BarbecueBeam : MonoBehaviour
{
    public int playerNumber;
    public float damage = 100f;
    public float range;
    public float fireRate = 1f;
    public WeaponAmmo ammo;
    public Animator animator;
    public ParticleSystem charge;
    public ParticleSystem beam;
    public ParticleSystem smoke;
    public ParticleSystem hitParticle_player;


    private bool rtPressed = false;
    private float nextTimeToFire = 0f;
    private Camera playerCam;
    private Transform player;
    private GameObject hitObject;
    private string fireString = "Fire1_Gamepad";


    void Start()
    {
        ammo = GetComponent<WeaponAmmo>();
        player = GetComponentInParent<Transform>();
        playerCam = GetComponentInParent<Camera>();
        charge = GetComponentInChildren<ParticleSystem>();

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

        charge.Play();
        AudioManager.instance.PlaySound("Sound_Bbq_Charge");
        animator.Play("BbqCharge");
        yield return new WaitForSeconds(1);
        charge.Stop();

        beam.Play();

        ammo.currentAmmo--;

        RaycastHit hit;

        AudioManager.instance.PlaySound("Sound_Bbq_Shot");
        animator.Play("BbqShoot");

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit))
        {
            hitObject = hit.transform.gameObject;
            Health target = hitObject.GetComponent<Health>();
            AudioManager.instance.PlaySound("sound_playerImpact");

            if (target != null)
            {
                Instantiate(hitParticle_player, hit.point, Quaternion.LookRotation(hit.normal));
                AudioManager.instance.PlaySound("sound_playerImpact");
                target.TakeDamage(damage);
            } else if (hitObject.CompareTag("Environment"))
            {
                Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
        yield return new WaitForSeconds(0.1f);
        beam.Stop();

    }
}
