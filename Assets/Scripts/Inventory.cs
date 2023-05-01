using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;

    public EquipmentManager equipManager;

    private PlayerHUD hud;

    private void Start()
    {
        GetReferencesInventory();
        InitVariables();
    }

    public void AddItem(Weapon newItem)
    {
        int newItemIndex = (int)newItem.weaponStyle;

        if (weapons[newItemIndex] != null)
        {
            RemoveItem(newItemIndex);
        }
        weapons[newItemIndex] = newItem;

        

        if(!equipManager.currentWeaponObject)
        {
            equipManager.EquipWeapon(newItem);
            hud.UpdateWeaponUI(newItem);
        }

    }

    public void RemoveItem(int index)
    {
        weapons[index] = null;
    }

    public Weapon GetItem(int index)
    {
        return weapons[index];
    }

    private void InitVariables()
    {
        weapons = new Weapon[3];
    }

    private void GetReferencesInventory()
    {
        hud = GetComponent<PlayerHUD>();
        equipManager = GetComponent<EquipmentManager>();
    }

    public bool hasItemInList(Weapon _weapon)
    {
        bool temp = false;
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i] == _weapon)
                temp = true;
            else
                temp = false;
        }
        return temp;
    }

}
