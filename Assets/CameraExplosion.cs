using UnityEngine;
using System.Collections;
using Cinemachine;

public class CameraExplosion : MonoBehaviour
{
    private CinemachineVirtualCamera camer1;
    private float time;

    private void Awake()
    {
        camer1 = GetComponent<CinemachineVirtualCamera>();

    }

    public void Shake(float forceAmount, float t)
    {
        CinemachineBasicMultiChannelPerlin c1 = camer1.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        c1.m_AmplitudeGain = forceAmount;
        time = t;
    }

    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }

        if (time <= 0)
        {
            camer1.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        }
    }
}