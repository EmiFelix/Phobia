using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float pickupRange;
    [SerializeField] private LayerMask pickupLayer;
    [SerializeField] private LayerMask door;
    [SerializeField] private LayerMask lightBox;

    [SerializeField] private int minRequiredToInteract;

    private Camera cam;

    private Inventory inventory;

    [SerializeField] private PlayerHUD playerHUD;

    public EquipmentManager equipManager;

    

    private void Start()
    {
        GetReferences();
        minRequiredToInteract = 6;

    }

    private void Update()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, pickupRange, pickupLayer))
        {
            //TODO: Prender UI
        }
        else
        {
            //TODO: Apagar UI
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerActions();
        }
    }

    private void PlayerActions()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, pickupRange, pickupLayer))
        {
            Weapon newItem = hit.transform.GetComponent<ItemObject>().item as Weapon;
            if (inventory.hasItemInList(newItem))
            {
                newItem.magazineSize += 1;
                playerHUD.UpdateWeaponUI(newItem);
            }
            else
            {
                inventory.AddItem(newItem);
            }
            
            
            Destroy(hit.transform.gameObject);


        }
        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, pickupRange, door) && equipManager.currentWeapon.weaponType == WeaponType.Key)
        {
            hit.collider.transform.parent.Rotate(new Vector3(0, 90, 0));
            equipManager.DestroyWeapon();
        }

        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, pickupRange, lightBox) && equipManager.currentWeapon.weaponType == WeaponType.Fuse && equipManager.currentWeapon.magazineSize == minRequiredToInteract)
        {
            // TODO: DARLE TODOS LOS FUSIBLES A LA CAJA
            equipManager.DestroyWeapon();
        }

    }

    

    private void GetReferences()
    {
        cam = Camera.main;
        inventory = GetComponent<Inventory>();
    }
}
