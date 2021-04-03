using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateTask : MonoBehaviour
{
    [SerializeField]
    private int TaskIndex;

    [SerializeField]
    private GameObject[] Tasks;
    // Update is called once per frame
    public void changeColor()
    {
        GetComponent<Animator>().SetBool("TaskComplete", true);
        if (TaskIndex == 1)
            Tasks[1].SetActive(true);

        if (TaskIndex == 2)
            Tasks[2].SetActive(true);

        if (TaskIndex == 3)
            Tasks[3].SetActive(true);

        if (TaskIndex == 4)
            Tasks[4].SetActive(true);

        if (TaskIndex == 5)
            Tasks[5].SetActive(true);
    }

    public void changeText(string text)
    {
        GetComponent<TMP_Text>().SetText(text);
    }

    private void Update()
    {
        if (CheckWin.win)
            GetComponent<Animator>().SetBool("TaskComplete", true);
    }
}
