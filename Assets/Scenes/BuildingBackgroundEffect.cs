using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBackgroundEffect : MonoBehaviour
{
    private float l, start, start1;
    public GameObject camera1;
    public float effect;
    public int layer;
    public GameObject player;

    public float pos;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position.x;


        l = GetComponent<SpriteRenderer>().bounds.size.x;
        if (layer == 1)
            l = 30;

    }

    // Update is called once per frame
    void Update()
    {
        float t = (camera1.transform.position.x * (1 - effect));
        float d = (camera1.transform.position.x * effect);
        
        if((transform.position.y <= 16.8 && layer != 1 && layer != 2 && layer != 3) || (player.transform.position.x < pos && layer == 1))
            transform.position = new Vector3(start + d, transform.position.y, transform.position.z);

        if(player.transform.position.x > pos && layer == 2)
            transform.position = new Vector3(start + d, transform.position.y, transform.position.z);
        else
            if(player.transform.position.x > pos && layer == 3 && player.transform.position.x < 710f)
                transform.position = new Vector3(start + d + 40, transform.position.y, transform.position.z);

        if (t > start + l && layer == 1)
            start += 60;
        else
            if (t < start - l && layer == 1)
            start -= 60;
        else
            if (t > start + l)
                start += l;
        else
            if (t < start - l)
                start -= l;
    }
}
