using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawn : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPoint;
    public void Awake()
    {
        spawnPoint = gameObject.transform;
    }

    public void TestRespawn(GameObject player)
    {
    
        player.transform.position = gameObject.transform.position;

    }
}
