using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FusiblesListUIManager : MonoBehaviour
{
    public List<Image> fusiblesList = new List<Image>();
   
    public void ChangeColor(int max)
    {
        for (int i = 0; i < max; i++)
        {
            fusiblesList[i].color = Color.white;
        }
    }


}
