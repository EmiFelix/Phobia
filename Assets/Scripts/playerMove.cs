using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    // Start is called before the first frame update

    //variables para movernos
    public CharacterController controler;
    public float speed = 10f;

    //variuables para detectar escalones
    public float gravity = -9.8f;
    public float jumpHeight = 3;

    public Transform groundCheck;

    public float graundDistance = 0.3f;
    public LayerMask groundMasck;

    Vector3 velocity;

    bool isgraundead;

    //trigger
    [SerializeField] private LayerMask trigger;

    [SerializeField] private GameObject ghost;
    [SerializeField] private GameObject triggerEmpty;
    [SerializeField] private Transform ghostSpawn;
    public bool enemySpawned;

    void Start()
    {
        enemySpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        //creamos la esfera
        isgraundead = Physics.CheckSphere(groundCheck.position, graundDistance, groundMasck);

        if (isgraundead && velocity.y < 0)
        {
            velocity.y = -2;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;

        controler.Move(move * speed * Time.deltaTime);


        //detectamos el salto
        if (Input.GetButtonDown("Jump") && isgraundead)
            if (Input.GetButtonDown("Jump") && isgraundead)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }

        velocity.y += gravity * Time.deltaTime;

        controler.Move(velocity * Time.deltaTime);
    }

    

    private void OnTriggerEnter(Collider collider)
    {
        //TODO: Fantasma
        if (collider.transform.tag == "Trigger")
        {
            Instantiate(ghost, ghostSpawn.position, ghostSpawn.rotation);
            enemySpawned = true;
            ghostSpawn.position = new Vector3(14, 13, 41);
            
            //TODO: SWITCH para que cada vez que toca un trigger cambie a la siguiente posicion:
            //ghostSpawn.position = new Vector3(3, 11, 44);
            //ghostSpawn.position = new Vector3(-1, 11, 59);
            //ghostSpawn.position = new Vector3(10, 12, 64);
            Destroy(collider);
        }
    }
}
