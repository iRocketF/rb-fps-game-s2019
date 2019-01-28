using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject player;

    private void Start()
    {
        Respawn();
    }

    public void Respawn()
    {
        Instantiate(player, spawnPoint.position, spawnPoint.rotation);
    }
}

    
