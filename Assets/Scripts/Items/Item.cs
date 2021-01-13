using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public enum ItemType 
    { 
        Health,
        Money,
        Speed,
        Firerate,
    }

    public ItemType itemType;
    public int amount;
}
