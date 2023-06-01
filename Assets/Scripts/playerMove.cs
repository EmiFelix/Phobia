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

    bool isgrounded;

    public AudioSource audioSource;
    private bool activeH;
    private bool activeV;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //creamos la esfera
        isgrounded = Physics.CheckSphere(groundCheck.position, graundDistance, groundMasck);

        //if (isgrounded && velocity.y < 0)
        //{
        //    velocity.y = -2f;
        //}

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controler.Move(move * speed * Time.deltaTime);

        //detectamos el salto
        if (Input.GetButtonDown("Jump") && isgrounded)
            if (Input.GetButtonDown("Jump") && isgrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }

        velocity.y += gravity * Time.deltaTime;

        controler.Move(velocity * Time.deltaTime);

        //Sonido caminata
        if (Input.GetButtonDown("Horizontal"))
        {
            if(activeV == false)
            {
                activeH = true;
                audioSource.Play();
            }
            
        }
      
        
        if (Input.GetButtonDown("Vertical"))
        {
            if(activeH == false)
            {
                activeV = true;
                audioSource.Play();
            }            
        }

       if (Input.GetButtonUp("Horizontal"))
        {
            activeH = false;
            if(activeV == false)
            {
            audioSource.Pause();
            }
        }

        if (Input.GetButtonUp("Vertical"))
        {
            activeV = false;
            if (activeH == false)
            {
                audioSource.Pause();
            }
        }
    }
}
