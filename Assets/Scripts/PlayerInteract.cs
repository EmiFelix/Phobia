using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float pickupRange;
    [SerializeField] private LayerMask pickupLayer;
    [SerializeField] private LayerMask obstacleLayer;
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
    [SerializeField] private GameObject spiders;

    public Animator Door;

    public AudioSource audioSource;

    public GameObject Fusibles;

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
            float magnitude = (hit.point - cam.transform.position).magnitude;
            if (!Physics.Raycast(cam.transform.position, cam.transform.forward, magnitude * 0.9f, obstacleLayer))
            {
                
                Weapon newItem = hit.transform.GetComponent<ItemObject>().item as Weapon;

                if (inventory.hasItemInList(newItem))
                {
                    newItem.magazineSize += 1;

                    if (equipManager.currentWeapon == newItem)
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
        }


        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, pickupRange, lightBox) && equipManager.currentWeapon.weaponType == WeaponType.Fuse && equipManager.currentWeapon.magazineSize == minRequiredToInteract)
        {

            equipManager.DestroyWeapon();
            luz1.SetActive(true);
            luz2.SetActive(true);
            luz3.SetActive(true);


            puzzle1Solved = true;
            Fusibles.SetActive(true);
            Animator animator = Fusibles.GetComponent<Animator>();           
            animator.SetBool("Open", true);
            Destroy(unlockDoor);
            spiders.SetActive(true);
            Destroy(fusiblesParent);
        }

        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, pickupRange, lightPanel) && puzzle1Solved == true)
        {
            hit.collider.gameObject.GetComponent<LightRoomManager>().LightsInteract();
        }


        //Door 1
        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, pickupRange, door) && equipManager.currentWeapon != null && equipManager.currentWeapon.weaponType == WeaponType.Key)
        {
            float magnitude = (hit.point - cam.transform.position).magnitude;

            if (!Physics.Raycast(cam.transform.position, cam.transform.forward, magnitude * 0.9f, obstacleLayer))
            {
                door actualdoor = hit.collider.GetComponentInParent<door>();

                if(actualdoor != null && equipManager.currentWeapon.id == actualdoor.id && !actualdoor.isOpen)
                {
                    actualdoor.animator.SetBool("Open", true);
                    audioSource.Play();
                    equipManager.DestroyWeapon();
                    actualdoor.isOpen = true;
                }
               
            }

        }
    }



    private void GetReferences()
    {
        cam = Camera.main;
        inventory = GetComponent<Inventory>();
    }
}
