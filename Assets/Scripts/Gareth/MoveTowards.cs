using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{

    public Transform target;
    public float lag;
    public int moveSpeed;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 dif = target.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(dif, Vector3.up);

        Quaternion currentRotation = transform.rotation;

        transform.rotation = Quaternion.Lerp(currentRotation, rotation, lag);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

    }
}
