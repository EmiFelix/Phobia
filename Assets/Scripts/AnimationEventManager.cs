using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventManager : MonoBehaviour
{
    private Inventory inventory;

    private EquipmentManager manager;

    private void Start()
    {
        getReferences();
    }

    public void destroyWeapon()
    {
        Destroy(manager.currentWeaponObject);
    }

    public void instantiateWeapon()
    {
        manager.currentWeaponObject = Instantiate(inventory.GetItem(manager.currentEquip).prefab, manager.weaponHolder);
    }

    private void getReferences()
    {
        inventory = GetComponentInParent<Inventory>();
        manager = GetComponentInParent<EquipmentManager>();
    }
}
