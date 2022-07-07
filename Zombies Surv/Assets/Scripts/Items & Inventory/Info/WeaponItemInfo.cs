using Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items & Inventory/Weapon")]
public class WeaponItemInfo : ItemInfo
{
    [Space]
    [SerializeField] private WeaponMoveType holdType;
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private float timeBetweenAttack;
    [SerializeField] private ItemInfo ammoItem;

    public float Damage { get => damage; }
    public float Range { get => range; }
    public float TimeBetweenAttack { get => timeBetweenAttack; }
    public ItemInfo AmmoItem { get => ammoItem; }
    public WeaponMoveType HoldType { get => holdType; }
}
