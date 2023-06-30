using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mothTimer : MonoBehaviour
{
    float currentTime = 0;
    float startingTime = 300;

    [SerializeField] private Text countdownText;


    
    public bool lose = false;

    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if(currentTime <= 0)
        {
            currentTime = 0;
            lose = true;
        }
    }


}
