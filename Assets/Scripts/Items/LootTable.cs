using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Loot
{
    public GameObject thisLoot;
    public int lootchance;
}
[CreateAssetMenu]
public class LootTable : ScriptableObject
{
    public Loot[] loots;

    public GameObject LootPowerup()
    {
        int cumProb = 0;
        int currProb = Random.Range(0, 100);
        for(int i = 0; i < loots.Length; i++)
        {
            cumProb += loots[i].lootchance;
            if(currProb <= cumProb)
            {
                return loots[i].thisLoot;
            }
        }
        return null;
    }

}
