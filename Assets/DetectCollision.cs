using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DetectCollision : MonoBehaviour
{
    public GameObject camera1;
    private bool seaplaneCrash = false;
    public ParticleSystem water;
    private bool played = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!played)
            water.transform.position = new Vector3(collision.transform.position.x, water.transform.position.y, water.transform.position.z);

        if (!water.isPlaying && !played && collision.gameObject.GetComponent<Rigidbody2D>().velocity.y < -2f)
        {
            played = true;
            water.Play();
        }
        if (collision.transform.rotation.eulerAngles.z < 340 && collision.transform.rotation.eulerAngles.z > 180)
        {
            camera1.GetComponent<CinemachineVirtualCamera>().Follow = null;
            seaplaneCrash = true;
        }
    }

    private void Update()
    {
        if (seaplaneCrash)
        {
            GetComponent<BuoyancyEffector2D>().density = 0;
        }
    }
}
