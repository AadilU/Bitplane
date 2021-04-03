using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCrash : MonoBehaviour
{
    public GameObject explosion;
    public GameObject planeComponents;

    public float radius;
    public float f;

    public LayerMask planeLayer;

    public GameObject camera1;
    public GameObject planeWithoutTail;
    public GameObject planeWithoutTail1;
    public GameObject tail;

    private bool decelerate = false;
    private bool smokeEffect = false;

    public ParticleSystem smoke;

    public bool gearDestroyed = false;

    public int layer;

    public GameObject trailrenederer;

    public GameObject AudioEffect;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.rotation.eulerAngles.z < 340 && transform.rotation.eulerAngles.z > 180)
        {
            AudioEffect.GetComponent<PlayExplosion>().PlaySound();
            explosion.transform.position = new Vector3(transform.position.x, -18.92f, transform.position.z);
            explosion.SetActive(true);
            gameObject.SetActive(false);
            planeComponents.SetActive(true);
            foreach (Transform child in planeComponents.transform)
            {
                child.parent = null;
            }
            explodeForce();
            camera1.GetComponent<CameraExplosion>().Shake(6f, 0.1f);
        }
        else
            if (transform.rotation.eulerAngles.z > 29 && transform.rotation.eulerAngles.z < 152)
        {
            CheckWin.stars -= 2;
            GetComponent<SpriteRenderer>().enabled = false;
            if (!GetComponent<flight>().gear.GetBool("GearDown"))
            {
                planeWithoutTail.SetActive(true);
                foreach (Transform child in planeWithoutTail.transform)
                {
                    child.parent = null;
                }
                trailrenederer.SetActive(false);
            }
            else
                {
                    planeWithoutTail1.SetActive(true);
                    foreach (Transform child in planeWithoutTail1.transform)
                    {
                        child.parent = null;
                    }
                    trailrenederer.SetActive(false);
            }
            Destroy(tail);
        }
        else
            if(layer == 1)
                decelerate = true;

        if (!GetComponent<flight>().gear.GetBool("GearDown"))
        {
            smokeEffect = true;
            gearDestroyed = true;
            CheckWin.stars -= 1;
        }

        if (GetComponent<flight>().gear.GetBool("GearDown") && GetComponent<Rigidbody2D>().velocity.y < -6)
        {
            CheckWin.stars -= 1;
            GetComponent<flight>().gear.SetBool("GearDown", false);
            gearDestroyed = true;

        }
    }

    private void explodeForce()
    {
        Collider2D[] o = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y + 4), radius, planeLayer);

        foreach(Collider2D o1 in o)
        {
            Vector2 d = o1.transform.position - transform.position;

            o1.GetComponent<Rigidbody2D>().AddForce(d * f);
        }
    }

    private void Update()
    {
        if (decelerate && GetComponent<flight>().thrust > 0 && GetComponent<flight>().gear.GetBool("GearDown"))
            GetComponent<flight>().thrust -= 0.04f;
        else
            if (decelerate && GetComponent<flight>().thrust > 0 && !GetComponent<flight>().gear.GetBool("GearDown"))
                GetComponent<flight>().thrust -= 0.03f;

        if (smokeEffect)
            if (!smoke.isPlaying)
                smoke.Play();

        if (!smokeEffect)
            if (smoke.isPlaying)
                smoke.Stop();

        if (GetComponent<Rigidbody2D>().velocity.x < 1)
            smokeEffect = false;
    }
}
