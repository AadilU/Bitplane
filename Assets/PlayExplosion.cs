using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayExplosion : MonoBehaviour
{
    public void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }
}