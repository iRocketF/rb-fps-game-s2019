using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePickAxis : MonoBehaviour {

    public float speed;
    public Direction axis;

    public enum Direction
    {
        up,
        forward,
        right,
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        transform.Rotate(GetAxis(axis), speed * Time.deltaTime);
    }

    public Vector3 GetAxis(Direction dir)
    {
        switch (dir)
        {
            case Direction.up:
                return Vector3.up;
                break;
            case Direction.forward:
                return Vector3.forward;
                break;
            case Direction.right:
                return Vector3.right;
                break;
            default:
                return Vector3.up;
        }
    }
}

