using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCleanUp : MonoBehaviour
{

    private ParticleSystem psystem;

    private void Start()
    {
        psystem = GetComponentInParent<ParticleSystem>();
    }

    private void Update()
    {
        if(psystem)
        {
            if(!psystem.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }


}
