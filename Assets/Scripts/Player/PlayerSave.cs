using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSave", menuName = "Game/PlayerSave")]
public class PlayerSave : ScriptableObject
{
    public int money;
    public int exp;

    public float range;
    public int damage;
    public float oxygen;
    public float sleepDuration;
    
    public List<GameObject> inventory;
}
