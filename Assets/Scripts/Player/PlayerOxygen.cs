using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOxygen : MonoBehaviour
{
    [SerializeField] private float maxOxygen = 100;
    private float currentOxygen;

    void Start()
    {
        PlayerData playerData = FindFirstObjectByType<PlayerData>();
        maxOxygen = playerData.playerSave.oxygen;
        currentOxygen = maxOxygen;
    }

    public void TakeDamage(int damage)
    {
        currentOxygen -= damage;
        print($"Player took {damage} damage. Current health: {currentOxygen}");

        if (currentOxygen <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        print("Player has died!");
        // Add death logic here (e.g., restart level, show game over screen, etc.)
    }
}