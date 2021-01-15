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
}
