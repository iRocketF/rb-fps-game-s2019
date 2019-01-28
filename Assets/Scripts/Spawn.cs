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

        float respawnNumber = Random.Range(0, 7f);
        int respawnInt = Mathf.RoundToInt(respawnNumber);

        Debug.Log(respawnNumber);

        Instantiate(player, this.gameObject.transform.GetChild(respawnInt));

    }
}

    
