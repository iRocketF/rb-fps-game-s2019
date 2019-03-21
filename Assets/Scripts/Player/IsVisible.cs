using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class IsVisible : MonoBehaviour
{
    public Renderer m_Renderer;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (m_Renderer.isVisible)
        {
            Debug.Log("Object is visible");
        }
        else Debug.Log("Object is no longer visible");
    }
}