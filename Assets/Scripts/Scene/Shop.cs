using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject ShopUI;

    public void OpenShopUI()
    {
        if (ShopUI != null)
        {
            ShopUI.SetActive(true);
        }
    }

    public void CloseShopUI()
    {
        if (ShopUI != null)
        {
            ShopUI.SetActive(false);
        }
    }
}
