using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbecueBeam : MonoBehaviour
{
    public int playerNumber;
    public float damage = 100f;
    public float range;
    public float fireRate = 0.5f;

    private float nextTimeToFire = 0f;
    private Camera playerCam;
    private Transform player;
    private GameObject hitObject;
    private string fireString = "Fire_Gamepad";

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Transform>();
        playerCam = GetComponentInParent<Camera>();

        fireString += playerNumber;
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (Input.GetAxis(fireString) > 0.5f && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
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
