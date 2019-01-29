using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDistance : MonoBehaviour {

    public Transform follower;
    public Transform followed;
    public float distance;
    public float desiredDist;

    public GameObject psystem;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        distance = Vector3.Distance(follower.position, followed.position);

        if(distance < desiredDist) {
            psystem.SetActive(true);
        }
       
	}
}
