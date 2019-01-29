using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject player; 

    private void Start()
    {
        MapSpawn();
    }

    public void MapSpawn()
    {

        float respawnNumber = Random.Range(0, transform.childCount);
        int respawnInt = Mathf.RoundToInt(respawnNumber);

        Debug.Log(respawnNumber);

        Instantiate(player, this.gameObject.transform.GetChild(respawnInt));

    }

    public void Respawn(GameObject player)
    {

        float respawnNumber = Random.Range(0, transform.childCount);
        int respawnInt = Mathf.RoundToInt(respawnNumber);

        Debug.Log(respawnNumber);

        player.transform.position = this.gameObject.transform.GetChild(respawnInt).position;

    }
}

    
