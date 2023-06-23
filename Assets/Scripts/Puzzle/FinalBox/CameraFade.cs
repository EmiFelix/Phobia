using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CameraFade : MonoBehaviour
{
    public Material initialColor;
    public float velocity = 0.1f;
    private float alpha = 0f;
    private bool fadeStarted = false;
    //public string menuSceneName;


    public void StartFade()
    {
        fadeStarted = true;
    }

    private void Update()
    {
        if (fadeStarted)
        {
            gameObject.GetComponent<Renderer>().material = initialColor;
            initialColor.color = new Color(0, 0, 0, alpha);
            alpha += velocity * Time.deltaTime;
            Debug.Log(alpha);

            if (alpha >= 1)
            {
                fadeStarted = false;
                Destroy(gameObject);
                SceneManager.LoadScene("Menu");
            }
        }

    }

  
}