using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flight : MonoBehaviour
{
    public float thrust;
    private float lift;
    private float r;
    float maxVelocity = 10f;
    public Animator gear;

    public void GearDown()
    {
        if (GetComponent<DetectCrash>().gearDestroyed == false)
        {
            gear.SetBool("GearDown", !gear.GetBool("GearDown"));
        }
    }

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch t = Input.touches[0];
            if (t.position.x > Screen.width / 2)
            {
                r = 1;
            }
            else
                if (t.position.x < Screen.width / 2)
                {
                    r = -1;
                }
        }
        else
            r = 0;
        //print(thrust);
        if (Input.GetKey(KeyCode.DownArrow) && thrust > 0)
        {
            thrust -= 2;
        }

        if (Input.GetKey(KeyCode.UpArrow) && thrust < 40)
        {
            thrust += 2;
        }

        lift = transform.rotation.eulerAngles.z;
        //print(lift);
        
        GetComponent<Rigidbody2D>().velocity = Vector2.ClampMagnitude(GetComponent<Rigidbody2D>().velocity, maxVelocity);
        //print(GetComponent<Rigidbody2D>().velocity.magnitude);

        if (gear.GetBool("GearDown"))
            maxVelocity = 12;

    }

    void FixedUpdate()
    {
        if(lift > 0 && lift < 90)
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-lift/8, lift/4));
            else
                if(lift > 90 && lift < 180)
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(810/lift, 540/lift));

        if (transform.rotation.eulerAngles.z > 90 && transform.rotation.eulerAngles.z < 360)
            GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(thrust, 0));
        else
            GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust, 0));
        GetComponent<Rigidbody2D>().AddTorque(r*2);

        
        if (lift < 325 && lift > 200)
        {
            if (maxVelocity < 18)
                maxVelocity += 0.05f;
        }
        else
            if (lift > 20 && lift < 160)
            {
                if(maxVelocity > 14)
                    maxVelocity -= 0.05f;
            }
            else
                if(maxVelocity > 16)
                    maxVelocity -= 0.05f;
                else
                    if(maxVelocity < 16)
                        maxVelocity += 0.05f;
        
    }
}
