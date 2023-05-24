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

    public AudioClip walkingSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //creamos la esfera
        isgrounded = Physics.CheckSphere(groundCheck.position, graundDistance, groundMasck);

        if (isgrounded && velocity.y < 0)
        {
            velocity.y = -3;
        }

        //Sonido caminata
        if (isgrounded && velocity.magnitude > 0.1f)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = walkingSound;
                audioSource.Play();
            }
            
        }
        else
        {
            audioSource.Stop();
        }
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
    }

    


}
