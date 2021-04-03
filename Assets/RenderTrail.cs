using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTrail : MonoBehaviour
{
    public GameObject plane;
    void Update()
    {
        transform.localEulerAngles = plane.transform.localEulerAngles;
    }
}
