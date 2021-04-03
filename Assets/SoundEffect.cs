using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    void Update()
    {
        if (Time.timeScale == 0)
        {
            GetComponent<AudioSource>().volume = 0;
            return;
        }
        else
            GetComponent<AudioSource>().volume = GetComponent<Rigidbody2D>().velocity.x/12;
    }
}
