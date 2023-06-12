using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamMovement : MonoBehaviour
{
    // Start is called before the first frame update


    public float mouseSensitivity = 80f;
    public Transform playerbody;
    float xRotation = 0;
    public Slider sliderMouse;

    private void Start()
    {
        mouseSensitivity = PlayerPrefs.GetFloat("currentSensitivity", 80f);
        sliderMouse.value = mouseSensitivity / 10;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerbody.Rotate(Vector3.up * mouseX);
    }

    public void AdjustSensitivity(float newSpeed)
    {
        mouseSensitivity = newSpeed * 10;
        PlayerPrefs.SetFloat("currentSensitivity", mouseSensitivity);
        sliderMouse.value = newSpeed;

    }
}
