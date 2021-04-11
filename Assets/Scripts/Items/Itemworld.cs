using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.instance.Prefab_ItemWorld, position, Quaternion.identity);

        ItemWorld itemWorld =  transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    private Item item;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();

    }

    public Item GetItem()
    {

        Debug.Log(item);
        return item;
    }

    public void DestorySelf()
    {
        Destroy(gameObject);
        Debug.Log("item");
    }

}
