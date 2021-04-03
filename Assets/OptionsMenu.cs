using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public GameObject OptionButtons;
    public GameObject MainButtons;
    public void ClickOptions()
    {
        if (MainButtons.activeSelf == true)
        {
            MainButtons.SetActive(false);
            OptionButtons.SetActive(true);
        }
        else
        {
            OptionButtons.SetActive(false);
            MainButtons.SetActive(true);
        }
    }
}
