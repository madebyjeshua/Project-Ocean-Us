using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net : MonoBehaviour, IItem, IQuest
{
    public int SetId()
    {
        return 5;
    }
    public (int,int) Sell()
    {
        return (300, 150);
    }
}
