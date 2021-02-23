using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
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

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Health:   return ItemAssets.instance.HealthSprite;
            case ItemType.Speed:    return ItemAssets.instance.SpeedSprite;
            case ItemType.Firerate: return ItemAssets.instance.FirerateSprite;
        }
    }

    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.Health:
            case ItemType.Speed:
            case ItemType.Firerate:
                return true;
        }
    }
}
