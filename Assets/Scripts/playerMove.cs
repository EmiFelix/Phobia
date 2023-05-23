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




    void Start()
    {
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
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;

        //if (move.magnitude > 1)
        //{
        //    move.Normalize();
        //}

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

    


}
