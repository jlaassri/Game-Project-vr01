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
        Spread,
        Verlocity,
        Chain,
        Life,
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
            case ItemType.Damage:   return ItemAssets.instance.DmgSprite;
            case ItemType.Verlocity:return ItemAssets.instance.VerlocitySprite;
            case ItemType.Spread:   return ItemAssets.instance.SpreadSprite;
            case ItemType.Chain:    return ItemAssets.instance.ChainSprite;
            case ItemType.LifeTap:  return ItemAssets.instance.LifetapSprite;
            case ItemType.Life:  return ItemAssets.instance.LifeSprite;
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
            case ItemType.Damage:
            case ItemType.Spread:
            case ItemType.Chain:
            case ItemType.LifeTap:
            case ItemType.Life:
                return true;
        }
    }
}
