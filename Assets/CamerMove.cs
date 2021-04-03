using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamerMove : MonoBehaviour
{
    // Update is called once per frame
    CinemachineFramingTransposer c;

    private void Start()
    {
        c = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>();
    }
    void Update()
    {
        if (transform.position.y <= -17.8)
        {
            c.m_SoftZoneHeight = 5f;
            c.m_DeadZoneHeight = 5f;
        }
        else
        {
            c.m_SoftZoneHeight = 0.08f;
            c.m_DeadZoneHeight = 0f;
        }
    }
}
