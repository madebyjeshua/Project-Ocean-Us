using UnityEngine;

public class Fishnet : MonoBehaviour, IEquipment
{
    private int [] prices;
    private float[] ranges;
    private void Awake(){
        SetPrices();
        SetRanges();
    }
    public void Upgrade(){
        EquipmentDataContainer equipmentDataContainer = FindFirstObjectByType<EquipmentDataContainer>();
        equipmentDataContainer.equipmentData.fishnetLevel+=1;
        equipmentDataContainer.playerSave.range = ranges[equipmentDataContainer.equipmentData.fishnetLevel - 1];
    }
    public int ReadLevel()
    {
        EquipmentDataContainer equipmentDataContainer = FindFirstObjectByType<EquipmentDataContainer>();
        return equipmentDataContainer.equipmentData.fishnetLevel;
    }
    public int SetPrice(){
        return prices[ReadLevel() - 1];
    }
    private void SetPrices(){
        prices=new int []{
            100,
            200,
            0
        };
    }
    private void SetRanges(){
        ranges=new float []{
            5f,
            10f,
            20f
        };
    }
}
