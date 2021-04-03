using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBackgroundEffect1 : MonoBehaviour
{
    private float l, start, start1;
    public GameObject camera1;
    public float effect;
    public int layer;
    public GameObject player;
    public int offset;
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
        
        if(player.transform.position.x > 450)
        transform.position = new Vector3(start + d - offset - 3.0889f, transform.position.y, transform.position.z);
        

        if (t > start + l - offset - 3.0889f)
            start += 60;
        else
            if (t < start - l - offset - 3.0889f && transform.position.x > 516)
            start -= 60;
    }
}
