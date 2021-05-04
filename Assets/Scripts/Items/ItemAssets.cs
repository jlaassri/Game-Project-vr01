using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
  public static ItemAssets instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    public Transform Prefab_ItemWorld;

    public Sprite HealthSprite;
    public Sprite SpeedSprite;
    public Sprite FirerateSprite;
    public Sprite DmgSprite;
    public Sprite SpreadSprite;
    public Sprite VerlocitySprite;
    public Sprite ChainSprite;
    public Sprite LifetapSprite;
    public Sprite LifeSprite;

}
