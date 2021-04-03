using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public void LoadLevel(int level)
    {
        if ((PlayerPrefs.GetInt("LevelsCompleted") >= level) || (level == 0 || level == 1 || level == 2 || level == 7))
            StartCoroutine(LoadLevel1(level));
    }

    IEnumerator LoadLevel1(int level)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 1;
        
        SceneManager.LoadScene(level);
    }
}
