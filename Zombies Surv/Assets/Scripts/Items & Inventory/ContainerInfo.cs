using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Container Info")]
public class ContainerInfo : ScriptableObject
{
    [SerializeField] private string containerName;
    [SerializeField] private ItemWithAmount[] spawnItems;

    public string ContainerName { get => containerName; }
    public ItemWithAmount[] SpawnItems { get => spawnItems; }
}
