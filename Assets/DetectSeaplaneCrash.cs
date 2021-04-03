using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectSeaplaneCrash : MonoBehaviour
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

    [HideInInspector]
    public bool decelerate = false;
    private bool smokeEffect = false;

    public ParticleSystem smoke;

    public bool gearDestroyed = false;

    public int layer;

    public GameObject tail2;

    public GameObject trailrenderer;

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
            int i = 0;
            planeComponents.transform.DetachChildren();
            explodeForce();
            camera1.GetComponent<CameraExplosion>().Shake(6f, 0.1f);
        }
        else
            if (transform.rotation.eulerAngles.z > 20 && transform.rotation.eulerAngles.z < 152)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            if (!GetComponent<CargoPlaneFlight>().gear.GetBool("GearDown"))
            {
                planeWithoutTail.SetActive(true);
                foreach (Transform child in planeWithoutTail.transform)
                {
                    child.parent = null;
                }
                trailrenderer.SetActive(false);
            }
            else
            {
                GetComponent<CargoPlaneFlight>().gear.SetBool("GearDown", true);
                planeWithoutTail1.SetActive(true);
                foreach (Transform child in planeWithoutTail1.transform)
                {
                    child.parent = null;
                }
                Destroy(tail2);
                trailrenderer.SetActive(false);
            }
            Destroy(tail);
            GetComponent<BoxCollider2D>().enabled = false;
            decelerate = true;
        }
        else
            if (layer == 1)
            decelerate = true;

        if (!GetComponent<CargoPlaneFlight>().gear.GetBool("GearDown"))
        {
            smokeEffect = true;
            gearDestroyed = true;
            decelerate = true;
        }

        if (GetComponent<CargoPlaneFlight>().gear.GetBool("GearDown") && GetComponent<Rigidbody2D>().velocity.y < -4)
        {
            GetComponent<CargoPlaneFlight>().gear.SetBool("GearDown", false);
            gearDestroyed = true;
            decelerate = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<CargoPlaneFlight>().engineOff = true;
        decelerate = true;
    }

    private void explodeForce()
    {
        Collider2D[] o = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y + 4), radius, planeLayer);

        foreach (Collider2D o1 in o)
        {
            Vector2 d = o1.transform.position - transform.position;

            o1.GetComponent<Rigidbody2D>().AddForce(d * f);
        }
    }

    private void Update()
    {
        if (decelerate && GetComponent<CargoPlaneFlight>().thrust > 0 && GetComponent<CargoPlaneFlight>().gear.GetBool("GearDown"))
            if (GetComponent<CargoPlaneFlight>().thrust > 0)
                GetComponent<CargoPlaneFlight>().thrust -= 0.5f;
        else
            if (decelerate && GetComponent<CargoPlaneFlight>().thrust > 0 && !GetComponent<CargoPlaneFlight>().gear.GetBool("GearDown"))
            if (GetComponent<CargoPlaneFlight>().thrust > 0)
                GetComponent<CargoPlaneFlight>().thrust -= 0.4f;

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
