using UnityEngine;

public class Knife : MonoBehaviour, IEquipment
{
    private int[] prices, damages;
    private void Awake()
    {
        SetPrices();
        SetDamages();
    }
    public void Upgrade()
    {
        EquipmentDataContainer equipmentDataContainer = FindFirstObjectByType<EquipmentDataContainer>();
        equipmentDataContainer.equipmentData.knifeLevel += 1;
        equipmentDataContainer.playerSave.damage = damages[equipmentDataContainer.equipmentData.knifeLevel - 1];
    }
    public int ReadLevel()
    {
        EquipmentDataContainer equipmentDataContainer = FindFirstObjectByType<EquipmentDataContainer>();
        return equipmentDataContainer.equipmentData.knifeLevel;
    }
    public int SetPrice()
    {
        return prices[ReadLevel() - 1];
    }
    private void SetPrices()
    {
        prices = new int[]{
            200,
            400,
            0
        };
    }
    private void SetDamages()
    {
        damages = new int[]{
            5,
            10,
            20
        };
    }
}
