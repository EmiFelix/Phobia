using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float pickupRange;
    [SerializeField] private LayerMask pickupLayer;
    [SerializeField] private LayerMask door;
    [SerializeField] private LayerMask door2;
    [SerializeField] private LayerMask door3;
    [SerializeField] private LayerMask door4;
    [SerializeField] private LayerMask door5;
    [SerializeField] private LayerMask door6;
    [SerializeField] private LayerMask lightBox;
    [SerializeField] private LayerMask lightPanel;
    [SerializeField] private int minRequiredToInteract;

    private Camera cam;

    private Inventory inventory;

    [SerializeField] private PlayerHUD playerHUD;

    public EquipmentManager equipManager;
    public FusiblesListUIManager fusiblesList;

    [SerializeField] private GameObject luz1;
    [SerializeField] private GameObject luz2;
    [SerializeField] private GameObject luz3;
    [SerializeField] private GameObject lever;
    private bool puzzle1Solved;

    [SerializeField] private GameObject fusiblesParent;

    [SerializeField] private GameObject unlockDoor;

    public Animator Door;
    public Animator Door2;
    public Animator Door3;
    public Animator Door4;
    public Animator Door5;
    public Animator Door6;

    public AudioSource audioSource;

    private void Start()
    {
        GetReferences();
        minRequiredToInteract = 6;
        puzzle1Solved = false;
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

                if(equipManager.currentWeapon == newItem)
                {
                    playerHUD.UpdateWeaponUI(newItem);
                }                      
            }
            else
            {
                inventory.AddItem(newItem);
            }

            if (newItem.weaponType == WeaponType.Fuse)
            {
                fusiblesList.ChangeColor(newItem.magazineSize);
            }

            Destroy(hit.transform.gameObject);
        }


        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, pickupRange, lightBox) && equipManager.currentWeapon.weaponType == WeaponType.Fuse && equipManager.currentWeapon.magazineSize == minRequiredToInteract)
        {
            
            equipManager.DestroyWeapon();
            luz1.SetActive(true);
            luz2.SetActive(true);
            luz3.SetActive(true);
            

            puzzle1Solved = true;
            Destroy(unlockDoor);
            Destroy(fusiblesParent);
        }

        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, pickupRange, lightPanel) && puzzle1Solved == true)
        {
            
            hit.collider.gameObject.GetComponent<LightRoomManager>().LightsInteract();
            

        }


        //TODO: EMPROLIJAR CODE DE PUERTAS
        //Door 1
        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, pickupRange, door) && equipManager.currentWeapon.weaponType == WeaponType.Key)
        {
            hit.collider.transform.parent.Rotate(new Vector3(0, 90, 0));
            audioSource.Play();
            Door.SetBool("Open", true);           
            equipManager.DestroyWeapon();
        }

        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, pickupRange, door2) && equipManager.currentWeapon.weaponType == WeaponType.Key)
        {
            hit.collider.transform.parent.Rotate(new Vector3(0, 90, 0)); 
            audioSource.Play();
            Door2.SetBool("Open2", true);
            equipManager.DestroyWeapon();
        }

        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, pickupRange, door3) && equipManager.currentWeapon.weaponType == WeaponType.Key)
        {
            hit.collider.transform.parent.Rotate(new Vector3(0, 90, 0));
            audioSource.Play();
            Door3.SetBool("Open", true);
            equipManager.DestroyWeapon();
        }

        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, pickupRange, door4) && equipManager.currentWeapon.weaponType == WeaponType.Key)
        {
            hit.collider.transform.parent.Rotate(new Vector3(0, 90, 0));
            audioSource.Play();
            Door4.SetBool("Open", true);
            equipManager.DestroyWeapon();
        }

        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, pickupRange, door5) && equipManager.currentWeapon.weaponType == WeaponType.Key)
        {
            hit.collider.transform.parent.Rotate(new Vector3(0, 90, 0));
            audioSource.Play();
            Door5.SetBool("Open", true);
            equipManager.DestroyWeapon();
        }

        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, pickupRange, door6) && equipManager.currentWeapon.weaponType == WeaponType.Key)
        {
            hit.collider.transform.parent.Rotate(new Vector3(0, 90, 0));
            audioSource.Play();
            Door6.SetBool("Open", true);
            equipManager.DestroyWeapon();
        }
    }

    

    private void GetReferences()
    {
        cam = Camera.main;
        inventory = GetComponent<Inventory>();
    }
}
