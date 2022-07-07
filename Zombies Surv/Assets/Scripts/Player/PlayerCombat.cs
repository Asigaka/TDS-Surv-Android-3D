using Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform weaponsContent;

    private WeaponModel equipedWeapon;
    [SerializeField] private List<WeaponModel> weaponModels;

    public void Initialize()
    {
        FillWeaponsList();
        EquipWeapon(null);
    }

    private void FillWeaponsList()
    {
        weaponModels = new List<WeaponModel>();

        for (int i = 0; i < weaponsContent.childCount; i++)
        {
            WeaponModel weapon = weaponsContent.GetChild(i).GetComponent<WeaponModel>();

            if (weapon)
            {
                weaponModels.Add(weapon);
                weapon.gameObject.SetActive(false);
            }
        }
    }

    public WeaponModel EquipWeapon(WeaponItemInfo weaponInfo)
    {
        if (equipedWeapon)
        {
            equipedWeapon.gameObject.SetActive(false);
        }

        WeaponModel nextModel = GetWeaponModelByInfo(weaponInfo);

        if (nextModel)
        {
            if (equipedWeapon && nextModel == equipedWeapon)
            {
                equipedWeapon.gameObject.SetActive(false);
                equipedWeapon = null;
            }
            else
            {
                equipedWeapon = nextModel;
                equipedWeapon.gameObject.SetActive(true);
            }
        }

        return equipedWeapon;
    }

    private WeaponModel GetWeaponModelByInfo(WeaponItemInfo weaponInfo)
    {
        foreach (WeaponModel weapon in weaponModels)
        {
            if (weapon.WeaponInfo == weaponInfo)
            {
                return weapon;
            }
        }

        return null;
    }
}
