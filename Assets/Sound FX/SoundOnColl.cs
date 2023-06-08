using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnColl : MonoBehaviour
{
    public GameObject soundSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource audioSource = soundSource.GetComponent<AudioSource>();

            audioSource.Play();
            Destroy(gameObject);
        }
    }
}
