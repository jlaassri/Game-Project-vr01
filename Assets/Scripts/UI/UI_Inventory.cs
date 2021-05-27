using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    //for any code that isnt my own, check relivent blog post for citation
    private Inventory inventory; //gets invetory script 
    private Transform itemSlotContainer; //gets item container pso
    private Transform itemSlotTemplate; //gets item temp pos
    

    private void Awake()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer"); //sets container  
        itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate"); //sets template
    }

    public void SetInventory(Inventory inventory) //set iventory function
    {
        this.inventory = inventory; //set inventory to current 
        inventory.OnItemListChanged += Inventory_OnItemListChanged; //if list changed
        RefreshInventoryItems(); //calls refesh inventoy function
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e) //on list change function 
    {
        RefreshInventoryItems(); //runs referesh invtory function
    }

    private void RefreshInventoryItems() //refresh invtroy funcition
    {
        foreach (Transform child in itemSlotContainer) //for each contain
        {
            if (child == itemSlotTemplate) continue; //if template is a child of container
            Destroy(child.gameObject); //destroy child 
        }

        int x = 0; //sets x
        int y = 0; //sets y
        float itemSlotCellSize = 30f; //cell siz

        foreach (Item item in inventory.GetItemList()) //gets item list 
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>(); //get slot trasfrom
            itemSlotRectTransform.gameObject.SetActive(true); //sets item slot gameobject to true
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize); //sets slot size to cell size 
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>(); //gets image compment 
            image.sprite = item.GetSprite(); //sets image to relivent item asset

     
            TextMeshProUGUI uiText = itemSlotRectTransform.Find("amountText").GetComponent<TextMeshProUGUI>(); //amount text 
            
            if (item.amount > 1) //if item amount  > 1
            {
                uiText.SetText(item.amount.ToString()); //sets amount text ot he amount of item 
            }
            else
            {
                uiText.SetText(""); //sets item text 2 empty
            }
            
            x++; //increase x when called 
            if(x > 4) //if x = 4
            {
                x = 0; //reset x
                y++; //increase y
            }
        }
    }
}
