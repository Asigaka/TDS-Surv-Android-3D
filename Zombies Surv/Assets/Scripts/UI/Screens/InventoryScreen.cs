using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
using UnityEngine.UI;

public class InventoryScreen : UIScreen
{
    [SerializeField] private Transform itemsContent;
    [SerializeField] private ItemCell itemCellPrefab;

    [Space]
    [SerializeField] private Button closeInventoryBtn;

    private Session session;

    public override void Initialize()
    {
        base.Initialize();
        session = Session.Instance;
        closeInventoryBtn.onClick.AddListener(CloseInventory);
    }

    private void OnEnable()
    {
        if (initialized)
        {
            UpdateInventory();
        }
    }

    public void UpdateInventory()
    {
        manager.ClearTransformChildren(itemsContent);

        foreach (ItemEntity item in session.Player.Inventory.Inventory)
        {
            ItemCell newCell = Instantiate(itemCellPrefab, itemsContent);
            newCell.SetItem(item);
        }
    }

    private void CloseInventory()
    {
        manager.SwitchScreen(ScreenType.HUD);
    }
}
