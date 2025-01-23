using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEquipment
{
    public int SetPrice();
    public void Upgrade();
    public int ReadLevel();

}
