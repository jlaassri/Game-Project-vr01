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
        Speed,
        Firerate,
        Damage,
        LifeTap,
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
                //case ItemType.Damage: return ItemAssets.instance.DamageSprite;
                //case ItemType.LifeTap: return ItemAssets.instance.LifeTapSprite;
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
            //case ItemType.Damage;
            //case ItemType.LifeTap;
                return true;
        }
    }
}
