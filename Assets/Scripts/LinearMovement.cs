using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour {

    public float time;
    public Transform point1;
    public Transform point2;
    public int direction = 1;
    public float timer;
    public float lerpTime = 1;


	// Use this for initialization
	void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime * direction;
        transform.position = Vector3.Lerp(point1.position, point2.position, timer / lerpTime);

        if(timer >= lerpTime || timer <= 0)
        {
            direction *= -1;
        }
	}
}
