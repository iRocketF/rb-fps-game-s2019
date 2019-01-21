using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitTransform : MonoBehaviour {

    public Transform orbited;
    public Transform orbiter;
    public float speed = 0;
    public float distance = 0;

    public float angle;

	// Use this for initialization
	void Start () {
        orbiter = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        angle += speed * Time.deltaTime;
        Vector3 newPos = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle)) * distance;
        orbiter.position = orbited.position + newPos;
	}
} 
