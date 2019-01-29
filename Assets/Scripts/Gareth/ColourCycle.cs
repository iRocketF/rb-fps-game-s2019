using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourCycle : MonoBehaviour {

    public Transform followed;
    public Transform follower;
    private Material material;
    public string color;

    
	// Use this for initialization
	void Start () {
        material = GetComponent<Renderer>().material;
    }
	
	// Update is called once per frame
	void Update () {

        float colorValue = Vector3.Distance(followed.position, follower.position);
        
	}
}
