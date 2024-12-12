using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabsManagement : MonoBehaviour
{
    public GameObject greenTab;
    public GameObject blueTab;
    public GameObject yellowTab;

    public void PutGreenTabInFront()
    {
        greenTab.transform.SetAsLastSibling();
    }

    public void PutBlueTabInFront()
    {
        blueTab.transform.SetAsLastSibling();
    }

    public void PutYellowTabInFront()
    {
        yellowTab.transform.SetAsLastSibling();
    }
}
