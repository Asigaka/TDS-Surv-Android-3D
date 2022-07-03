using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private ItemWithAmount[] startItems;
    [SerializeField] private List<ItemEntity> inventory;

    public List<ItemEntity> Inventory { get => inventory; }

    public void Initialize()
    {
        ItemsHandler.AddItems(startItems);
    }
}
