using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //makes class serializable
public class Loot
{
    //for any code that isnt my own, check relivent blog post for citation
    public GameObject thisLoot; //loot table 
    public int lootchance; //drop chance 
}
[CreateAssetMenu] //creates inspector menu
public class LootTable : ScriptableObject
{
    public Loot[] loots; //arry for items inside loot table 
    public GameObject LootPowerup() //item spwaner function 
    {
        int cumProb = 0; //base prob 
        int currProb = Random.Range(0, 100); //chance prob
        for(int i = 0; i < loots.Length; i++) //check loot prob over all items in array
        {
            cumProb += loots[i].lootchance; //check ceack item in array
            if(currProb <= cumProb)
            {
                return loots[i].thisLoot; //if sucsessful spawns item
            }
        }
        return null; //if nothing returns spwan nothing 
    }
}
