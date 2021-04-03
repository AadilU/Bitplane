using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneStunts : MonoBehaviour
{
    int i = 0;
    private bool stunt = false;
    private bool stunt1 = false;

    private bool groundStunt = false;
    private bool groundStunt1 = false;

    private bool upsidedownstunt = false;
    private bool upsidedownstunt1 = false;

    private bool diveStunt = false;
    private bool diveStunt1 = false;

    public GameObject tasks1;
    public GameObject tasks2;
    public GameObject tasks3;
    public GameObject tasks4;

    public GameObject UpdateWin;

    void Update()
    {
        if (transform.rotation.eulerAngles.z < 110 && transform.rotation.eulerAngles.z > 60 && !stunt)
        {
            stunt = true;
            StartCoroutine(VerticalStunt());
        }
        
        if ((transform.rotation.eulerAngles.z > 110 || transform.rotation.eulerAngles.z < 60) && stunt)
        {
            stunt1 = true;
        }

        if (transform.position.y > -19 && transform.position.y < -10 && !groundStunt && diveStunt)
        {
            groundStunt = true;
            StartCoroutine(GroundStunt());
        }

        if ((transform.position.y < -19 || transform.position.y > -10) && groundStunt && diveStunt)
        {
            groundStunt1 = true;
        }

        if (transform.rotation.eulerAngles.z > 140 && transform.rotation.eulerAngles.z < 190 && !upsidedownstunt && groundStunt)
        {
            upsidedownstunt = true;
            StartCoroutine(UpsideDownStunt());
        }

        if ((transform.rotation.eulerAngles.z < 140 || transform.rotation.eulerAngles.z > 190) && upsidedownstunt && groundStunt)
        {
            upsidedownstunt1 = true;
        }

        if (transform.rotation.eulerAngles.z < 298 && transform.rotation.eulerAngles.z > 240 && !diveStunt && stunt)
        {
            diveStunt = true;
            StartCoroutine(DiveStunt());
        }

        if ((transform.rotation.eulerAngles.z > 298 || transform.rotation.eulerAngles.z < 240) && diveStunt && stunt)
        {
            diveStunt1 = true;
        }


    }

    IEnumerator VerticalStunt()
    {
        for (float t = 10; t >= 0; t -= Time.deltaTime)
        {
            if (stunt1)
            {
                stunt1 = false;
                stunt = false;
                yield break;
            }
            yield return null;
        }
        tasks1.GetComponent<UpdateTask>().changeColor();
    }

    IEnumerator GroundStunt()
    {
        for (float t = 10; t >= 0; t -= Time.deltaTime)
        {
            if (groundStunt1)
            {
                groundStunt1 = false;
                groundStunt = false;
                yield break;
            }
            yield return null;
        }
        tasks3.GetComponent<UpdateTask>().changeColor();
    }

    IEnumerator UpsideDownStunt()
    {
        for (float t = 10; t >= 0; t -= Time.deltaTime)
        {
            if (upsidedownstunt1)
            {
                upsidedownstunt1 = false;
                upsidedownstunt = false;
                yield break;
            }
            yield return null;
        }
        tasks4.GetComponent<UpdateTask>().changeColor();
        UpdateWin.GetComponent<CheckWin>().tasks = true;
    }

    IEnumerator DiveStunt()
    {
        for (float t = 8; t >= 0; t -= Time.deltaTime)
        {
            if (diveStunt1)
            {
                diveStunt1 = false;
                diveStunt = false;
                yield break;
            }
            yield return null;
        }
        tasks2.GetComponent<UpdateTask>().changeColor();
    }
}
