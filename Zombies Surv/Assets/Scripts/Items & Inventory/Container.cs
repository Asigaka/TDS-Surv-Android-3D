using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : Interactable
{
    [SerializeField] private ContainerInfo containerInfo;

    [SerializeField] private List<ItemEntity> containerItems;

    public List<ItemEntity> ContainerItems { get => containerItems; }

    private void Start()
    {
        ItemsHandler.AddItems(containerInfo.SpawnItems, containerItems);
    }

    public override void Interactive()
    {
        Session.Instance.UI.Container.OpenContainer(this);
    }
}
