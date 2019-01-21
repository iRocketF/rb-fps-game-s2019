using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingTransform : MonoBehaviour {

    public Transform target;
    public float lag;
   

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 relativePos = target.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);

        Quaternion currentRotation = transform.rotation;

        transform.rotation = Quaternion.Lerp(currentRotation, rotation, lag);
		
	}
}
