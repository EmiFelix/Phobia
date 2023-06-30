using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : MonoBehaviour
{
    public float speed = 0f;
    public float lifetime = 5f;

    private void Start()
    {

        Invoke("DestroyBullet", lifetime);
    }

    private void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void DestroyBullet()
    {

        Destroy(gameObject);
    }
}
