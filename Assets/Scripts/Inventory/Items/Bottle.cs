using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour, IItem, IQuest
{
    public int SetId()
    {
        return 1;
    }
    public (int,int) Sell()
    {
        return (20, 10);
    }
}
