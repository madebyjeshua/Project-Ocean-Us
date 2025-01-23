using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour, IItem, IQuest
{
    public int SetId()
    {
        return 0;
    }
    public (int,int) Sell()
    {
        return (500, 250);
    }
}
