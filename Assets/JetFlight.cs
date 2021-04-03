using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JetFlight : MonoBehaviour
{
    public float thrust;
    private float lift = 0;
    private float r;
    float maxVelocity = 20f;
    public Animator gear;

    [HideInInspector]
    public bool engineOff = false;

    private bool liftOff = false;

    public GameObject tasks;

    public void GearDown()
    {
        if (GetComponent<DetectJetCrash>().gearDestroyed == false)
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

        if (liftOff)
        {
            GetComponent<DetectJetCrash>().layer = 1;
            lift = transform.rotation.eulerAngles.z;
            tasks.GetComponent<UpdateTask>().changeColor();
        }
        else
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, r * GetComponent<Rigidbody2D>().velocity.x));

        GetComponent<Rigidbody2D>().velocity = Vector2.ClampMagnitude(GetComponent<Rigidbody2D>().velocity, maxVelocity);
        //print(GetComponent<Rigidbody2D>().velocity.magnitude);

        if (gear.GetBool("GearDown"))
            maxVelocity = 14;

        if (transform.position.y > -16)
        {
            liftOff = true;
        }
    }

    void FixedUpdate()
    {
        if (engineOff)
            return;
        if (lift > 0 && lift < 90)
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-lift / 8, lift / 4 + 8));
        else
                if (lift > 90 && lift < 180)
            GetComponent<Rigidbody2D>().AddForce(new Vector2(810 / lift, 1518 / lift + 8));

        if (transform.rotation.eulerAngles.z > 90 && transform.rotation.eulerAngles.z < 360)
            GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(thrust, 0));
        else
            GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust, 0));
        GetComponent<Rigidbody2D>().AddTorque(r * 3);


        if (lift < 325 && lift > 200)
        {
            if (maxVelocity < 20)
                maxVelocity += 0.05f;
        }
        else
            if (lift > 20 && lift < 160)
        {
            if (maxVelocity > 14)
                maxVelocity -= 0.05f;
        }
        else
                if (maxVelocity > 18)
            maxVelocity -= 0.05f;
        else
                    if (maxVelocity < 18)
            maxVelocity += 0.05f;

    }
}
