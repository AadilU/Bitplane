using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckWin : MonoBehaviour
{
    public GameObject player;

    [SerializeField]
    private int pos1;

    [SerializeField]
    private int pos2;

    private Transform[] UI1;
    public static bool win = false;
    public static int stars = 3;

    [SerializeField]
    private GameObject[] starsUI;

    [SerializeField]
    private Sprite s;
    
    public GameObject retryButton;

    public GameObject UIControl;

    public bool tasks = false;

    private void Awake()
    {
        win = false;
        stars = 3;
        if (SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 6)
            tasks = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (RestrictCamera.CameraOut)
        {
            StartCoroutine(RetryButton());
        }

        if (player.transform.position.x > pos1 && player.transform.position.x < pos2 && tasks && player.gameObject.activeSelf)
        {
            if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                StartCoroutine(Check());
            }
            if (Mathf.Approximately(player.GetComponent<Rigidbody2D>().velocity.x, 0) && player.gameObject.activeSelf)
            {
                win = true;
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    if (PlayerPrefs.GetInt("LevelsCompleted") == 2)
                        PlayerPrefs.SetInt("LevelsCompleted", 3);
                }
                for (int i = 0; i < stars; i++)
                {
                    starsUI[i].GetComponent<Image>().sprite = s;
                }

                SetUIActive();
            }
        }
        else
             if (Mathf.RoundToInt(player.GetComponent<Rigidbody2D>().velocity.x) == 0 || !player.gameObject.activeSelf || player.transform.position.y < -20)
            {
                StartCoroutine(RetryButton());
            }
            else
                if (SceneManager.GetActiveScene().buildIndex == 4)
                    StartCoroutine(RetryButton());
    }

    IEnumerator Check()
    {
        yield return new WaitForSeconds(0.5f);
        if (Mathf.RoundToInt(player.GetComponent<Rigidbody2D>().velocity.x) == 0)
        {
            win = true;
            for (int i = 0; i < stars; i++)
            {
                starsUI[i].GetComponent<Image>().sprite = s;
            }

            SetUIActive();
        }
    }

    IEnumerator RetryButton()
    {
        yield return new WaitForSeconds(0.25f);
            if ((player.GetComponent<CollisionDetection>().collision1 && player.GetComponent<Rigidbody2D>().velocity.x > -1f && player.GetComponent<Rigidbody2D>().velocity.x < 1f) || player.transform.position.y < -20 || RestrictCamera.CameraOut)
                retryButton.SetActive(true);

    }

    void SetUIActive()
    {
        int i2 = 0;
        foreach (Transform u in gameObject.transform)
        {
            StartCoroutine(UIActive(u, i2));
            i2 += 1;
        }
    }

    IEnumerator UIActive(Transform u1, int seconds)
    {
        yield return new WaitForSeconds(seconds);
        u1.gameObject.SetActive(true);
    }
}
