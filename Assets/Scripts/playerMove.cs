using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    //variables para movernos
    public CharacterController controler;
    public float speed = 10f;

    //variuables para detectar escalones
    public float gravity = -9.8f;
    public float jumpHeight = 3;

    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public AudioSource audioSource;
    private bool activeH;
    private bool activeV;

    private void Update()
    {
        // Crear la esfera
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float x = 0f;
        float z = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            z = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            z = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            x = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            x = 1f;
        }

        Vector3 move = transform.right * x + transform.forward * z;
        move.Normalize(); // Normalize the movement vector

        controler.Move(move * speed * Time.deltaTime);

        // Detectar el salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controler.Move(velocity * Time.deltaTime);

        // Sonido caminata
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            if (!activeV)
            {
                activeH = true;
                audioSource.Play();
            }

        }


        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            if (!activeH)
            {
                activeV = true;
                audioSource.Play();
            }
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            activeH = false;
            if (!activeV)
            {
                audioSource.Pause();
            }
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            activeV = false;
            if (!activeH)
            {
                audioSource.Pause();
            }
        }
    }
}
