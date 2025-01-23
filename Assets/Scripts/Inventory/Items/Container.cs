using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour, IItem
{
    public (int,int) Sell()
    {
        return (20, 10);
    }
}
