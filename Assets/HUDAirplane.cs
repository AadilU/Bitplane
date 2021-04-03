using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDAirplane : MonoBehaviour
{
    public GameObject plane;

    private float planePos;
    // Update is called once per frame

    private void Start()
    {
        planePos = plane.transform.position.y;
    }

    void Update()
    {
        transform.rotation = plane.transform.rotation;
        if (planePos + 5 < plane.transform.position.y)
        {
            planePos += 5;
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.04f, transform.position.z);
        }
        else
            if (planePos - 5 > plane.transform.position.y)
        {
            planePos -= 5;
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.04f, transform.position.z);
        }
    }
}