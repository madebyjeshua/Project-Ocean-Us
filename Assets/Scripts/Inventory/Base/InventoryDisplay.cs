using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private List<Image> displays;
    [SerializeField] private InventoryBehaviour inventoryBehaviour;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip sellSound;

    private void Awake()
    {
        inventoryBehaviour = FindFirstObjectByType<InventoryBehaviour>();
        for(int i = 0; i<16; i++){
            displays[i] = GameObject.Find($"InventoryIcon ({i})").GetComponentsInChildren<Image>()[1];
        }
    }

    private void OnEnable()
    {
        RefreshUI();
    }

    private void RefreshUI()
    {
        for(int i = 0; i<inventoryBehaviour.ReadInventory().Count; i++){
            displays[i].sprite = inventoryBehaviour.ReadInventory()[i].GetComponentInChildren<SpriteRenderer>().sprite;
            displays[i].color = new Color(displays[i].color.r, displays[i].color.g, displays[i].color.b, 1f);
        }

        for(int i = inventoryBehaviour.ReadInventory().Count; i < 16; i++){
            displays[i].sprite = null;
            displays[i].color = new Color(displays[i].color.r, displays[i].color.g, displays[i].color.b, 0f);
        }
    }

    public void SellOnClick()
    {
        inventoryBehaviour.SellAllItems();
        PlaySellSound();
        RefreshUI();
    }

    private void PlaySellSound()
    {
        if (audioSource != null && sellSound != null)
        {
            audioSource.PlayOneShot(sellSound);
        }
    }
}
