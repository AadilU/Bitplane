using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlightTimeUI : MonoBehaviour
{
    private bool win1 = false;
    // Update is called once per frame
    void Update()
    {
        string m = ((int)(Time.timeSinceLevelLoad / 60)).ToString();
        string s = ((Time.timeSinceLevelLoad % 60)).ToString("F0");
        if(!win1)
            GetComponent<TextMeshProUGUI>().SetText(m + ":" + s);

        if (CheckWin.win)
            win1 = true;
    }
}
