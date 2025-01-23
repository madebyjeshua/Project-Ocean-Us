using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP : MonoBehaviour
{
    public GameObject ExpUI;

    public void OpenExpUI()
    {
        if (ExpUI != null)
        {
            ExpUI.SetActive(true);
        }
    }

    public void CloseInventoryUI()
    {
        if (ExpUI != null)
        {
            ExpUI.SetActive(false);
        }
    }
}
