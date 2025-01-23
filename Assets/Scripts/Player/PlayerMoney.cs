using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public static PlayerMoney instance;
    public int CurrentMoney { get; private set; }

    private void Awake()
    {
        instance = this;
        CurrentMoney = 100; // Example starting amount
    }

    public void SpendMoney(int amount)
    {
        if (amount <= CurrentMoney)
        {
            CurrentMoney -= amount;
            Debug.Log($"Money spent: {amount}. Remaining: {CurrentMoney}");
        }
        else
        {
            Debug.LogWarning("Not enough money!");
        }
    }

    public void AddMoney(int amount)
    {
        CurrentMoney += amount;
        Debug.Log($"Money added: {amount}. Total: {CurrentMoney}");
    }
}