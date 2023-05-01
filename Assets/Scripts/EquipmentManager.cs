using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public int currentEquip;
    public GameObject currentWeaponObject = null;
    public Weapon currentWeapon;

    private Inventory inventory;

    public Transform weaponHolder = null;
    public PlayerHUD hud;

    // [SerializeField] Weapon defaultMeleeWeapon = null;

    private void Start()
    {
        GetReferences3();
        InitVariables();

    }

    private void Update()
    {
        

        //if any key is equiped:
        if (Input.GetKeyDown(KeyCode.Alpha1) && currentEquip != 0 && inventory.GetItem(0))
        {
            UnequipWeapon();
            EquipWeapon(inventory.GetItem(0));
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && currentEquip != 1 && inventory.GetItem(1))
        {
            UnequipWeapon();
            EquipWeapon(inventory.GetItem(1));

        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && currentEquip != 2 && inventory.GetItem(2))
        {
            UnequipWeapon();
            EquipWeapon(inventory.GetItem(2));

        }

    }

    public void EquipWeapon(Weapon weapon)
    {
        currentEquip = (int)weapon.weaponStyle;
        //TODO: Anim
        currentWeaponObject = Instantiate(weapon.prefab, weaponHolder);
        currentWeapon = weapon;
        hud.UpdateWeaponUI(weapon);
    }
    
    public void UnequipWeapon()
    {
        //TODO: Anim
        Destroy(currentWeaponObject);
    }

    public void DestroyWeapon()
    {
        hud.Unequip();
        inventory.RemoveItem((int)currentWeapon.weaponStyle);
        currentWeapon = null;
        currentEquip = -1;
        Destroy(currentWeaponObject);

    }

    private void InitVariables()
    {
        //inventory.AddItem(defaultMeleeWeapon);
        //EquipWeapon(inventory.GetItem(2));
    }

    private void GetReferences3()
    {
        inventory = GetComponent<Inventory>();
    }
}
