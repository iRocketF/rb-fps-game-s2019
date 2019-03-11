using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    float respawnNumber;
    int respawnInt;
    int lastRespawnInt;

    private void Start()
    {
        MapSpawn();
    }

    public void MapSpawn()
    {

        respawnNumber = Random.Range(0, transform.childCount);
        respawnInt = Mathf.RoundToInt(respawnNumber);

        Instantiate(player1, this.gameObject.transform.GetChild(respawnInt));

        lastRespawnInt = respawnInt;

        respawnNumber = Random.Range(0, transform.childCount);
        respawnInt = Mathf.RoundToInt(respawnNumber);

        if(respawnInt == lastRespawnInt)
        {
            while(respawnInt == lastRespawnInt)
            {
                respawnNumber = Random.Range(0, transform.childCount);
                respawnInt = Mathf.RoundToInt(respawnNumber);
            }
        }

        Instantiate(player2, this.gameObject.transform.GetChild(respawnInt));
    }

    public void Respawn(GameObject player)
    {

        respawnNumber = Random.Range(0, transform.childCount);
        respawnInt = Mathf.RoundToInt(respawnNumber);

        if (respawnInt == lastRespawnInt)
        {
            while (respawnInt == lastRespawnInt)
            {
                respawnNumber = Random.Range(0, transform.childCount);
                respawnInt = Mathf.RoundToInt(respawnNumber);
            }
        }

        lastRespawnInt = respawnInt;

        player.transform.position = this.gameObject.transform.GetChild(respawnInt).position;

    }
}

    
