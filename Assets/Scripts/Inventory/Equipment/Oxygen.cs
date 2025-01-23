using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : MonoBehaviour, IEquipment
{
    private int[] prices;
    private float[] oxygens;
    private void Awake()
    {
        SetPrices();
        SetOxygens();
    }
    public void Upgrade()
    {
        EquipmentDataContainer equipmentDataContainer = FindFirstObjectByType<EquipmentDataContainer>();
        equipmentDataContainer.equipmentData.OxygenLevel += 1;
        equipmentDataContainer.playerSave.oxygen = oxygens[equipmentDataContainer.equipmentData.OxygenLevel - 1];
    }
    public int ReadLevel()
    {
        EquipmentDataContainer equipmentDataContainer = FindFirstObjectByType<EquipmentDataContainer>();
        return equipmentDataContainer.equipmentData.OxygenLevel;
    }
    public int SetPrice()
    {
        return prices[ReadLevel() - 1];
    }
    private void SetPrices()
    {
        prices = new int[]{
            500,
            1000,
            0
        };
    }
    private void SetOxygens()
    {
        oxygens = new float[]{
            100f,
            150f,
            200f
        };
    }
}