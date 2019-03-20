using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HitScanWeapon : MonoBehaviour
{
    public int playerNumber;
    public float damage = 10f;
    public float range;
    public float fireRate = 15f;
    public float m_fRandomAngle;
    public WeaponAmmo ammo;
    public Animator animator;
    public Transform m_tTarget = null;
    public ParticleSystem hitParticle_env;
    public ParticleSystem hitParticle_player;
    public P1_Hud player1_Hud;
    
   

    private bool rtPressed = false;
    public bool isShooting = false;
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
                rtPressed = true;
                isShooting = true;

                nextTimeToFire = Time.time + 1f / fireRate;

                ammo.currentAmmo--;

                if(ammo.currentAmmo == 0)
                {
                    isShooting = false;
                    AudioManager.instance.PlaySound("sound_ammoEmpty");
                }
                Shoot();

            } if(Input.GetAxis(fireString) < 0.2)
            {
                isShooting = false;
                rtPressed = false;
            }
        }
        else if (ammo.currentAmmo == 0)
        {
            if (!rtPressed && Input.GetAxis(fireString) > 0.5f && Time.time >= nextTimeToFire)
            {
                rtPressed = true;
                isShooting = false;
                AudioManager.instance.PlaySound("sound_ammoEmpty");
            }
            if (Input.GetAxis(fireString) < 0.2)
            {
                isShooting = false;
                rtPressed = false;
            }
        }

        if(isShooting)
        {
            animator.SetBool("isShooting", true);
        } else {
            animator.SetBool("isShooting", false);
        }

    }

    void Shoot()
    {
        AudioManager.instance.PlaySound("Sound_Shot");

        Vector3 tDirection = playerCam.transform.forward;
        Quaternion qRandomRecoil = Quaternion.identity
                                   * Quaternion.AngleAxis(Random.Range(-m_fRandomAngle, m_fRandomAngle), Vector3.up)
                                   * Quaternion.AngleAxis(Random.Range(-m_fRandomAngle, m_fRandomAngle), Vector3.right);
        tDirection = qRandomRecoil * tDirection;

        RaycastHit hit;

        if (Physics.Raycast(playerCam.transform.position, tDirection, out hit))
        {
            hitObject = hit.transform.gameObject;
            Health target = hitObject.GetComponent<Health>();

            if (target != null)
            {
               
                Instantiate(hitParticle_player, hit.point, Quaternion.LookRotation(hit.normal));
                AudioManager.instance.PlaySound("sound_playerImpact");

                target.TakeDamage(damage);

                //player1_Hud.hitMarked();
               
                
            } else if (hitObject.CompareTag("Environment")) {
                Instantiate(hitParticle_env, hit.point, Quaternion.LookRotation(hit.normal));
               
            }
        }
    }
}

