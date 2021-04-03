using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject plane;
    private Vector3 velocity1;

    public void pauseGame()
    {
        velocity1 = plane.GetComponent<Rigidbody2D>().velocity;
        plane.GetComponent<Rigidbody2D>().isKinematic = true;
        Time.timeScale = 0;
        pauseUI.SetActive(true);
    }

    public void resumeGame()
    {
        plane.GetComponent<Rigidbody2D>().isKinematic = false;
        plane.GetComponent<Rigidbody2D>().velocity = velocity1;
        Time.timeScale = 1;
        pauseUI.SetActive(false);
    }
}
