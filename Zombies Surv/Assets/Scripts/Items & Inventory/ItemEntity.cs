using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemEntity
{
    [SerializeField] private ItemInfo itemInfo;
    [SerializeField] private int amount;

    public ItemEntity(ItemInfo itemInfo, int amount)
    {
        this.itemInfo = itemInfo;
        this.amount = amount;
    }

    public ItemInfo ItemInfo { get => itemInfo; }
    public int Amount { get => amount; set => amount = value; }
}
