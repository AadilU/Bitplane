using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RestrictCamera : MonoBehaviour
{
    public float xPos;
    public float xPos1;
    public static bool CameraOut;

    private void Awake()
    {
        CameraOut = false;
    }

    private void Update()
    {
        if (transform.position.x < xPos)
        {
            GetComponent<CinemachineVirtualCamera>().Follow = null;
            CameraOut = true;
        }
        else
            if (transform.position.x > xPos1)
            {
                GetComponent<CinemachineVirtualCamera>().Follow = null;
                CameraOut = true;
            }
    }
}
