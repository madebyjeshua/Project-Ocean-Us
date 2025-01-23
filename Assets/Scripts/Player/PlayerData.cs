using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    [SerializeField] public PlayerSave playerSave;
    private InventoryBehaviour inventoryBehaviour;

    [SerializeField] private Text moneyText;

    public int money;
    public int exp;
    public float range;

    private void Awake()
    {
        inventoryBehaviour = FindFirstObjectByType<InventoryBehaviour>();
        Load();
    }

    private void Update()
    {
        Save();
    }

    private void Save()
    {
        playerSave.money = money;
        playerSave.exp = exp;
        playerSave.range = range;
        playerSave.inventory = inventoryBehaviour.ReadInventory();
    }

    private void Load()
    {
        money = playerSave.money;
        exp = playerSave.exp;
        range = playerSave.range;
        playerSave.inventory.Clear();
        inventoryBehaviour.LoadInventory();
        RefreshDataUI();
    }

    public void RefreshDataUI()
    {
        moneyText.text = money.ToString();
    }
}
