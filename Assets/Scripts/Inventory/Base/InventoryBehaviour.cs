using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBehaviour : MonoBehaviour
{
    [SerializeField] private List<GameObject> inventoryItems;
    private PlayerData playerData;

    private void Awake()
    {
        playerData = FindFirstObjectByType<PlayerData>();
    }

    public void PutInInventory(GameObject item)
    {
        if (inventoryItems.Count < 16){
            inventoryItems.Add(item);
            item.transform.position = new Vector2(-500f, -50f);
        }else {
            print("FULL");
        }
    }

    public void SellAllItems()
    {
        int totalPrice = 0;
        int totalEXP = 0;
        IItem iItem;
        for (int i=0; i<inventoryItems.Count; i++){
            iItem = inventoryItems[i].GetComponent<IItem>();
            (int price, int exp) = iItem.Sell();
            totalPrice += price;
            totalEXP += exp;
        }


        playerData.money += totalPrice;
        playerData.exp += totalEXP;
        inventoryItems.Clear();
        playerData.RefreshDataUI();
    }

    public List<GameObject> ReadInventory()
    {
        return inventoryItems;
    }

    public void LoadInventory()
    {
        inventoryItems.Clear();
    }
}
