using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour, IItem, IQuest
{
    public int SetId()
    {
        return 3;
    }
    public (int,int) Sell()
    {
        return (20, 10);
    }
}
