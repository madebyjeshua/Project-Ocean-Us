using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentBehaviour : MonoBehaviour
{
    private void Start()
    {
        RefreshUI();
    }

    public void LevelUp(){
        IEquipment equipment = GetComponent<IEquipment>();
        EquipmentDataContainer equipmentDataContainer = FindFirstObjectByType<EquipmentDataContainer>();

        if (equipmentDataContainer.playerSave.money >= equipment.SetPrice() && equipment.ReadLevel() < 3){
            equipmentDataContainer.playerSave.money -= equipment.SetPrice();
            equipment.Upgrade();
        } else{
            print("money not enough or level max");
        }

        RefreshUI();
    }

    private void RefreshUI()
    {
        EquipmentDataContainer equipmentDataContainer = FindFirstObjectByType<EquipmentDataContainer>();
        Text priceText = GetComponentInChildren<Text>();
        Text moneyText = GameObject.Find("Currency").GetComponent<Text>();
        IEquipment equipment = GetComponent<IEquipment>();

        priceText.text = equipment.SetPrice().ToString();
        moneyText.text = equipmentDataContainer.playerSave.money.ToString();
    }
}
