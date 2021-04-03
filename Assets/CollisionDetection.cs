using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public bool collision1 = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision1 = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision1 = false;
    }
}
