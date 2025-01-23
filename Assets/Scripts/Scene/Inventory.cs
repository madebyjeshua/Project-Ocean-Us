using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryUI;

    public void OpenInventoryUI()
    {
        if (inventoryUI != null)
        {
            inventoryUI.SetActive(true);
        }
    }

    public void CloseInventoryUI()
    {
        if (inventoryUI != null)
        {
            inventoryUI.SetActive(false);
        }
    }
}