using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    //for any code that isnt my own, check relivent blog post for citation
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item) //spwans item clone 
    {
        Transform transform = Instantiate(ItemAssets.instance.Prefab_ItemWorld, position, Quaternion.identity); //spawns clown ato prefab location

        ItemWorld itemWorld =  transform.GetComponent<ItemWorld>(); //get itemworld component
        itemWorld.SetItem(item);//sets item value to clone

        return itemWorld; //returns value
    }

    private Item item; //gets item class 
    private SpriteRenderer spriteRenderer; //gets sprtie renderer
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //get sprtie renderer compnnetent
    }
    public void SetItem(Item item) //sets item
    {
        this.item = item; //sets item from class 
        spriteRenderer.sprite = item.GetSprite(); //get sprite from class 

    }

    public Item GetItem() //gets item from class 
    {

        Debug.Log(item); //debug checking 
        return item; //returns item 
    }

    public void DestorySelf()// destroys object once clone is spawned 
    {
        Destroy(gameObject);//destroys game object 
        Debug.Log("item"); //debug check 
    }

}
