using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDMovement : MonoBehaviour
{
    public GameObject plane;

    private float planePos;
    // Update is called once per frame

    private void Start()
    {
        planePos = plane.transform.position.x;
    }

    void Update()
    {
        if (planePos + 10 < plane.transform.position.x)
        {
            planePos += 10;
            transform.position = new Vector3(transform.position.x - 0.11f, transform.position.y, transform.position.z);
        }
        else
            if (planePos - 10 > plane.transform.position.x)
            {
                planePos -= 10;
                transform.position = new Vector3(transform.position.x + 0.11f, transform.position.y, transform.position.z);
            }
    }
}
