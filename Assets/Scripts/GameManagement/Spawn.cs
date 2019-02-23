using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private void Start()
    {
        MapSpawn();
    }

    public void MapSpawn()
    {

        float respawnNumber = Random.Range(0, transform.childCount);
        int respawnInt = Mathf.RoundToInt(respawnNumber);

        Instantiate(player1, this.gameObject.transform.GetChild(respawnInt));

        respawnNumber = Random.Range(0, transform.childCount);
        respawnInt = Mathf.RoundToInt(respawnNumber);

        Instantiate(player2, this.gameObject.transform.GetChild(respawnInt));


    }

    public void Respawn(GameObject player)
    {

        float respawnNumber = Random.Range(0, transform.childCount);
        int respawnInt = Mathf.RoundToInt(respawnNumber);


        player.transform.position = this.gameObject.transform.GetChild(respawnInt).position;

    }
}

    
