using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleBinder : MonoBehaviour, IItem, IQuest
{
    public int SetId()
    {
        return 2;
    }
    public (int,int) Sell()
    {
        return (20, 10);
    }
}
