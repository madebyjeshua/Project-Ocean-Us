using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControls : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI;
    private float clickCooldown;

    void Update()
    {
        clickCooldown -= Time.deltaTime;

        if (OpenInventory())
        {
            clickCooldown = .2f;
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    public bool OpenInventory()
    {
        return Input.GetKeyDown(KeyCode.I) && clickCooldown <= .2f;
    }

    public bool OpenShop()
    {
        return Input.GetKeyDown(KeyCode.Q) && clickCooldown <= .2f;
    }

    public bool PickItems()
    {
        return Input.GetKeyDown(KeyCode.LeftShift);
    }
    
    public bool Attack()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
    public bool SwitchEquip()
    {
        return Input.GetKeyDown(KeyCode.Tab);
    }
}
