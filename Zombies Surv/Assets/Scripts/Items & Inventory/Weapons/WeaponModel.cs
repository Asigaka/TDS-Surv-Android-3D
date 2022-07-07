using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModel : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private WeaponItemInfo weaponInfo;

    private bool readyForShot;
    private bool isReloaded;

    public WeaponItemInfo WeaponInfo { get => weaponInfo; }

    public void Equip()
    {
        readyForShot = true;
        enabled = true;
    }

    public void Unequip()
    {
        enabled = false;
    }

    public void TryShot()
    {
        if (readyForShot)
        {
            readyForShot = false;

            Invoke(nameof(ResetReadyForShot), weaponInfo.TimeBetweenAttack);
        }
    }

    private void ResetReadyForShot()
    {
        readyForShot = true;
    }
}
