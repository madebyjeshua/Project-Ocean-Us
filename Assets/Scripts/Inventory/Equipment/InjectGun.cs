using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjectGun : MonoBehaviour, IEquipment
{
    private int[] prices;
    private float[] sleepDurations;
    private void Awake()
    {
        SetPrices();
        SetSleepDurations();
    }
    public void Upgrade()
    {
        EquipmentDataContainer equipmentDataContainer = FindFirstObjectByType<EquipmentDataContainer>();
        equipmentDataContainer.equipmentData.injectGunLevel += 1;
        equipmentDataContainer.playerSave.sleepDuration = sleepDurations[equipmentDataContainer.equipmentData.injectGunLevel - 1];
    }
    public int ReadLevel()
    {
        EquipmentDataContainer equipmentDataContainer = FindFirstObjectByType<EquipmentDataContainer>();
        return equipmentDataContainer.equipmentData.injectGunLevel;
    }
    public int SetPrice()
    {
        return prices[ReadLevel() - 1];
    }
    private void SetPrices()
    {
        prices = new int[]{
            1000,
            2000,
            0
        };
    }
    private void SetSleepDurations()
    {
        sleepDurations = new float[]{
            5f,
            10f,
            20f
        };
    }
}