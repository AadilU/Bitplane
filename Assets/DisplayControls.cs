using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayControls : MonoBehaviour
{
    public Animator ControlText;
    public GameObject Controls;

    private bool paused = false;

    void Start()
    {
        if (PlayerPrefs.HasKey("Tutorial"))
        {
            if (PlayerPrefs.GetInt("Tutorial") == 1)
                return;
            else
                StartCoroutine("PauseControls");
        }
        else
        {
            StartCoroutine("PauseControls");
        }
    }

    private void Update()
    {
        if (paused)
            if (Input.touchCount == 1)
            {
                Controls.SetActive(false);
                Time.timeScale = 1;
                PlayerPrefs.SetInt("Tutorial", 1);
            }
    }

    IEnumerator PauseControls()
    {
        yield return new WaitForSeconds(2);
        paused = true;
        Time.timeScale = 0;
        Controls.SetActive(true);
        ControlText.Play("TextGrow");
    }
}
