using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plastic : MonoBehaviour, IItem, IQuest
{
    public int SetId()
    {
        return 4;
    }
    public (int,int) Sell()
    {
        return (20, 10);
    }
}
