using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCrate : MonoBehaviour
{
    [SerializeField]
    private GameObject crate1;
    
    [SerializeField]
    private GameObject crate2;

    public GameObject Tasks;

    public GameObject WinUpdate;

    public GameObject SuppliesButton;

    // Update is called once per frame

    public void DropSupplies()
    {
        if (crate1.transform.parent == transform && (transform.parent.transform.position.x >= 692 && transform.parent.transform.position.x <= 800))
        {
            crate1.SetActive(true);
            crate1.transform.parent = null;
        }
        else
            if ((transform.parent.transform.position.x >= 20 && transform.parent.transform.position.x <= 124))
        {
            crate2.SetActive(true);
            crate2.transform.parent = null;
        }
    }

    void Update()
    {
        if (transform.parent.transform.position.x >= 692 && transform.parent.transform.position.x <= 800)
            SuppliesButton.SetActive(true);
        else
            if (transform.parent.transform.position.x >= 20 && transform.parent.transform.position.x <= 124)
            SuppliesButton.SetActive(true);
        else
            SuppliesButton.SetActive(false);

        if (crate1.transform.parent != null || crate2.transform.parent != null)
            Tasks.GetComponent<UpdateTask>().changeText("Deliver the supplies (1/2)");

        if (crate1.transform.parent == null && crate2.transform.parent == null)
        {
            Tasks.GetComponent<UpdateTask>().changeText("Deliver the supplies (2/2)");
            Tasks.GetComponent<UpdateTask>().changeColor();
            WinUpdate.GetComponent<CheckWin>().tasks = true;
        }
    }
}
