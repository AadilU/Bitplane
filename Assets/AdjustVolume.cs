using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustVolume : MonoBehaviour
{
    void Start()
    {
        GetComponent<Slider>().value = AudioControl.volume1;
    }

    void Update()
    {
        AudioControl.volume1 = GetComponent<Slider>().value;
    }
}
