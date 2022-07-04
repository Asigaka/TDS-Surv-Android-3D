using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : Interactable
{
    [SerializeField] private ItemWithAmount item;

    public override void Interactive()
    {
        ItemsHandler.AddItem(item.ItemInfo, item.Amount);
        Destroy(gameObject);
    }
}
