using System.Collections.Generic;

public static class ItemsHandler 
{
    public static List<ItemEntity> GetPlayerInventory { get => Session.Instance.Player.Inventory.Inventory; }

    public static void AddItem(ItemInfo itemInfo, int amount, List<ItemEntity> to = null)
    {
        List<ItemEntity> inventory;

        if (to != null)
            inventory = to;
        else
            inventory = GetPlayerInventory;

        ItemEntity item = GetItemByInfo(itemInfo, inventory);

        if (item != null)
        {
            item.Amount += amount;
        }
        else
        {
            ItemEntity newItem = new ItemEntity(itemInfo, amount);
            inventory.Add(newItem);
        }
    }

    public static void AddItems(ItemWithAmount[] items, List<ItemEntity> to = null)
    {
        foreach (ItemWithAmount item in items)
        {
            AddItem(item.ItemInfo, item.Amount, to);
        }
    }

    public static bool TryRemoveItem(ItemInfo itemInfo, int amount, List<ItemEntity> inEntities = null)
    {
        List<ItemEntity> inventory;

        if (inEntities != null)
            inventory = inEntities;
        else
            inventory = GetPlayerInventory;

        ItemEntity item = GetItemByInfo(itemInfo, inventory);

        if (item != null)
        {
            int ost = item.Amount - amount;

            if (ost > 0)
            {
                item.Amount = ost;
                return true;
            }
        }

        return false;
    }

    public static bool RemoveItems(ItemWithAmount[] items, List<ItemEntity> inEntities = null)
    {
        foreach (ItemWithAmount item in items)
        {
            if (!TryRemoveItem(item.ItemInfo, item.Amount, inEntities))
            {
                return false;
            }
        }

        return true;
    }

    public static ItemEntity GetItemByInfo(ItemInfo itemInfo, List<ItemEntity> entities = null)
    {
        List<ItemEntity> inventory;

        if (entities != null)
            inventory = entities;
        else
            inventory = GetPlayerInventory;

        foreach (ItemEntity item in inventory)
        {
            if (item.ItemInfo == itemInfo)
            {
                return item;
            }
        }

        return null;
    }
}
