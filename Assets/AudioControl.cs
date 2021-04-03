using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioControl : MonoBehaviour
{
    public AudioClip[] music;
    public GameObject AudioSource1;

    public static GameObject AudioController;

    public static float volume1 = 1;

    public static bool played = false;

    public int levelnumber1 = 0;

    public static int levelnumber2 = 1;

    void Start()
    {
        if (AudioController == null)
            AudioController = gameObject;
        else
            Destroy(gameObject);

        if (SceneManager.GetActiveScene().buildIndex == 0 && AudioControl.played)
            return;

        levelnumber1 = SceneManager.GetActiveScene().buildIndex;

        if (levelnumber1 == levelnumber2)
            return;
        else
            levelnumber2 = levelnumber1;

        if (music[SceneManager.GetActiveScene().buildIndex] != null)
        {
            AudioController.GetComponent<AudioSource>().Stop();
            AudioController.GetComponent<AudioSource>().clip = AudioController.GetComponent<AudioControl>().music[SceneManager.GetActiveScene().buildIndex];
            AudioController.GetComponent<AudioSource>().loop = true;
            AudioController.GetComponent<AudioSource>().Play();
            AudioControl.played = true;
            if (SceneManager.GetActiveScene().buildIndex != 0)
                AudioControl.played = false;
        }
        
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        AudioController.GetComponent<AudioSource>().volume = volume1;
    }
}
