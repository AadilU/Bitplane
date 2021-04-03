using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler, IUnityAdsListener
{
    private Vector3 panelLocation;
    public float percentThreshold = 0.2f;
    public float easing = 0.5f;
    public int totalPages = 1;
    private int currentPage = 1;
    public GameObject bu1, bu2, bu3, bu4, bu5;
    private Vector2 b1, b2, b3, b4, b5;
    private float scrollPage;

    public GameObject[] levels1;
    public GameObject[] adbuttons;

    public GameObject LevelLoadObject;

    private static int LevelNumber;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("LevelsCompleted"))
        {
            if (PlayerPrefs.GetInt("LevelsCompleted") >= 2)
                PlayerPrefs.SetInt("LevelsCompleted", PlayerPrefs.GetInt("LevelsCompleted"));
        }
        else
            PlayerPrefs.SetInt("LevelsCompleted", 2);

        for (int i = PlayerPrefs.GetInt("LevelsCompleted") - 2; i <= 3; i++)
        {
            levels1[i].GetComponent<Image>().color = new Color(0, 0, 0);
        }

        if(PlayerPrefs.GetInt("LevelsCompleted") - 2 <= 3)
            adbuttons[PlayerPrefs.GetInt("LevelsCompleted") - 2].SetActive(true);

        b1 = bu1.GetComponent<RectTransform>().localScale;
        b2 = bu2.GetComponent<RectTransform>().localScale;
        b3 = bu3.GetComponent<RectTransform>().localScale;
        b4 = bu4.GetComponent<RectTransform>().localScale;
        b5 = bu5.GetComponent<RectTransform>().localScale;

        panelLocation = transform.position;

        Advertisement.AddListener(this);
    }
    public void OnDrag(PointerEventData data)
    {
        float difference = data.pressPosition.x - data.position.x;
        transform.position = panelLocation - new Vector3(difference, 0, 0);
    }
    public void OnEndDrag(PointerEventData data)
    {
        float percentage = (data.pressPosition.x - data.position.x) / Screen.width;
        if (Mathf.Abs(percentage) >= percentThreshold)
        {
            Vector3 newLocation = panelLocation;
            if (percentage > 0 && currentPage < totalPages)
            {
                currentPage++;
                newLocation += new Vector3(-Screen.width, 0, 0);
            }
            else if (percentage < 0 && currentPage > 1)
            {
                currentPage--;
                newLocation += new Vector3(Screen.width, 0, 0);
            }
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelLocation = newLocation;
        }
        else
        {
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
        }
    }
    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
    {
        float t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }

    public void onRightPress()
    {
        if (currentPage < 5)
        {
            currentPage++;
            panelLocation = new Vector3(transform.position.x - Screen.width, transform.position.y, transform.position.z);
            StartCoroutine(MovePanel(transform.position, new Vector3(transform.position.x - Screen.width, transform.position.y, transform.position.z), easing));
        }
    }

    public void onLeftPress()
    {
        if (currentPage > 1)
        {
            currentPage--;
            panelLocation = new Vector3(transform.position.x + Screen.width, transform.position.y, transform.position.z);
            StartCoroutine(MovePanel(transform.position, new Vector3(transform.position.x + Screen.width, transform.position.y, transform.position.z), easing));
        }
    }

    IEnumerator MovePanel(Vector3 startpos, Vector3 endpos, float seconds)
    {
        float t = 0f;
        while (t <= 1)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }

    public void PlayAd()
    {
        AudioControl.AudioController.GetComponent<AudioSource>().Pause();
        LevelNumber = PlayerPrefs.GetInt("LevelsCompleted");
        Advertisement.Initialize("4015999", true);

        if (!Advertisement.IsReady("Rewarded_Android"))
            PlayAd();

        Advertisement.Show("Rewarded_Android");
    }

    public void OnUnityAdsDidFinish(string placementID, ShowResult adResult)
    {
        if (adResult == ShowResult.Finished)
        {
            if(LevelNumber == PlayerPrefs.GetInt("LevelsCompleted"))
                PlayerPrefs.SetInt("LevelsCompleted", PlayerPrefs.GetInt("LevelsCompleted") + 1);

            AudioControl.AudioController.GetComponent<AudioSource>().UnPause();

            if (LevelLoadObject != null)
            {
                LevelLoadObject.GetComponent<LevelLoader>().LoadLevel(1);
                LevelNumber = LevelNumber + 1;
            }
        }
    }

    void Update()
    {
        scrollPage = GetComponent<RectTransform>().localPosition.x;
        b1 = bu1.GetComponent<RectTransform>().localScale;
        b2 = bu2.GetComponent<RectTransform>().localScale;
        b3 = bu3.GetComponent<RectTransform>().localScale;
        b4 = bu4.GetComponent<RectTransform>().localScale;
        b5 = bu5.GetComponent<RectTransform>().localScale;
        if (scrollPage < 100 && scrollPage > -100)
        {
            if (b1.x < 2.6)
            {
                bu1.GetComponent<RectTransform>().localScale = new Vector2(b1.x + .05f, b1.y + .11f);
            }
        }
        else
        {
            if (b1.x > 2)
            {
                bu1.GetComponent<RectTransform>().localScale = new Vector2(b1.x - .05f, b1.y - .11f);
            }
        }

        if (scrollPage < -700 && scrollPage > -900)
        {
            if (b2.x < 3)
            {
                bu2.GetComponent<RectTransform>().localScale = new Vector2(b2.x + .05f, b2.y + .11f);
            }
        }
        else
        {
            if (b2.x > 2.4)
            {
                bu2.GetComponent<RectTransform>().localScale = new Vector2(b2.x - .05f, b2.y - .11f);
            }
        }

        if (scrollPage < -1500 && scrollPage > -1700)
        {
            if (b3.x < 2.6)
            {
                bu3.GetComponent<RectTransform>().localScale = new Vector2(b3.x + .06f, b3.y + .14f);
            }
        }
        else
        {
            if (b3.x > 1.7)
            {
                bu3.GetComponent<RectTransform>().localScale = new Vector2(b3.x - .06f, b3.y - .14f);
            }
        }

        if (scrollPage < -2300 && scrollPage > -2500)
        {
            if (b4.x < 2.6)
            {
                bu4.GetComponent<RectTransform>().localScale = new Vector2(b4.x + .05f, b4.y + .11f);
            }
        }
        else
        {
            if (b4.x > 2)
            {
                bu4.GetComponent<RectTransform>().localScale = new Vector2(b4.x - .05f, b4.y - .11f);
            }
        }

        if (scrollPage < -3100 && scrollPage > -3300)
        {
            if (b5.x < 3.6)
            {
                bu5.GetComponent<RectTransform>().localScale = new Vector2(b5.x + .05f, b5.y + .11f);
            }
        }
        else
        {
            if (b5.x > 2.8)
            {
                bu5.GetComponent<RectTransform>().localScale = new Vector2(b5.x - .05f, b5.y - .11f);
            }
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
    }

    public void OnUnityAdsDidError(string message)
    {
    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }
}