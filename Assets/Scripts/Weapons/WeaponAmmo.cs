using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAmmo : MonoBehaviour
{
    public float maxAmmo;
    public float currentAmmo;

    void Start()
    {
        if (currentAmmo <= 0)
        {
            currentAmmo = maxAmmo;
        }
    }

    void Update()
    {
        if (currentAmmo >= maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
    }

    public void IncreaseAmmo(float amount)
    {
        currentAmmo += amount;
    }
}
