using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public string name;
    public string description;
    public Sprite icon;

    public void Use()
    {
        Debug.Log(name + " was used");
    }
}
