using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChanged;
    public List<Item> itemList;



    public Inventory()
    {
        itemList = new List<Item>();

        //AddItem(new Item { itemType = Item.ItemType.Firerate, amount = 1 });
        //AddItem(new Item { itemType = Item.ItemType.Health, amount = 1 });
        //AddItem(new Item { itemType = Item.ItemType.Speed, amount = 1 });
        Debug.Log(itemList.Count);

        /*
        foreach (item in itemList)
        {
            funcX(item)
        }
        */
        // if (itemList.Contains(x => x.itemType.ItemType.Health))


        //if (itemList.Contains(this.itemType.ItemType.Health))
        //{
        //    Debug.Log("found it");
        //}


        Debug.Log("inventroy");

    }



    public void AddItem(Item item)
    {
        if (item.IsStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory)
            {
                itemList.Add(item);
            }

        }
        else
        {
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

    
    public float FindItemHeal()
    {
        float heal = 0;
        foreach (Item itemEnumerator in itemList)
        {
            if (itemEnumerator.itemType== Item.ItemType.Health)
            {
                heal++;
            }
        }

        // String interpolation for easier display.
        Debug.Log($"You have {heal} Health");

        return heal;
    }

    public float FindItemSpeed()
    {
        float speed = 0;
        foreach (Item itemEnumerator in itemList)
        {
            if (itemEnumerator.itemType == Item.ItemType.Speed)
            {
                speed++;
            }
        }

        // String interpolation for easier display.
        Debug.Log($"You have {speed} Health");

        return speed;
    }

    /*
    public funcX(Item item)
    {
      int heal;
      int speed;
      int fire;
      switch(item.itemType)
      {
        case: Health
        {
          heal++;
          break;
        }
        case: Speed
        {
          speed++; 
          break;
        }
        case: Firerate
        {
          fire++;
          break;
        }
      }
    }
    return fire, heal, speed;
    }
    */
}