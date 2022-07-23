using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Enums;

public class ContainerScreen : UIScreen
{
    [SerializeField] private Transform inventoryContent;
    [SerializeField] private Transform containerContent;
    [SerializeField] private ItemCell itemCellPrefab;

    [Space]
    [SerializeField] private Button closeContainerBtn;

    private Session session;

    public override void Initialize()
    {
        base.Initialize();
        session = Session.Instance;
        closeContainerBtn.onClick.AddListener(CloseInventory);
    }

    public void OpenContainer(Container container)
    {
        manager.ClearTransformChildren(inventoryContent);

        foreach (ItemEntity item in session.Player.Inventory.Inventory)
        {
            ItemCell newCell = Instantiate(itemCellPrefab, inventoryContent);
            newCell.SetItem(item);
        }

        manager.ClearTransformChildren(containerContent);

        foreach (ItemEntity item in container.ContainerItems)
        {
            ItemCell newCell = Instantiate(itemCellPrefab, containerContent);
            newCell.SetItem(item);
        }
    }

    private void CloseInventory()
    {
        manager.SwitchScreen(ScreenType.Container);
    }
}
