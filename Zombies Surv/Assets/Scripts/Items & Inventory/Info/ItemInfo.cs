using Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Items & Inventory/Item")]
public class ItemInfo : ScriptableObject
{
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private string itemName;
    [SerializeField] private string itemDescription;
    [SerializeField] private ItemType itemType;

    public Sprite ItemSprite { get => itemSprite; }
    public string ItemName { get => itemName; }
    public string ItemDescription { get => itemDescription; }
    public ItemType ItemType { get => itemType; }
}
