using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundEffect : MonoBehaviour
{
    private float l, l1, start, start1;
    public GameObject camera1;
    public float effect;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position.x;
        start1 = transform.position.y;


        l = GetComponent<SpriteRenderer>().bounds.size.x;
        l1 = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        float t = (camera1.transform.position.x * (1 - effect));
        float d = (camera1.transform.position.x * effect);

        float t1 = (camera1.transform.position.y * (1 - effect));
        float d1 = (camera1.transform.position.y * effect);

        if (transform.position.y >= 16.8 || player.transform.position.y >= 16.8)
            transform.position = new Vector3(start, start1, transform.position.z);
        else
            transform.position = new Vector3(start, transform.position.y, transform.position.z);





        if (t > start + l)
            start += l;
        else
            if (t < start - l)
                start -= l;

        if (t1 > start1 + l1)
        {
            //transform.position = new Vector3(transform.position.x, start1 + l1, transform.position.z);
            start1 += l1;
        }
        else
            if (t1 < start1 - l1)
            {
                //transform.position = new Vector3(transform.position.x, start1 - l1, transform.position.z);
                start1 -= l1;
            }

    }
}
