using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{

    public GameObject pickUp;
    public Transform pickUpPos;
    public bool pickUpActive;

    public float spawntimer = 15f;
    public float nextspawn;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPickUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pickUp.activeSelf)
        {
            pickUpActive = false;
        } else {
            pickUpActive = true;
        }

        if (!pickUpActive)
        {
            nextspawn += Time.deltaTime;
            if (nextspawn > spawntimer)
            {
                pickUp.SetActive(true);
                nextspawn = 0;
            }
        }
    }

    void SpawnPickUp()
    {
        pickUp = Instantiate(pickUp, pickUpPos.position, pickUpPos.rotation) as GameObject;
        pickUp.transform.parent = gameObject.transform;
    }

    public void SetPickUpActive()
    {
       
    }
}
