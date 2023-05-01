using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponResetOnPlay : MonoBehaviour
{

    public List<Weapon> listWeapons = new List<Weapon>();

    void Start()
    {
        for (int i = 0; i < listWeapons.Count; i++)
        {
            listWeapons[i].magazineSize = listWeapons[i].magazineSizeINITIAL;
        }
    }

}
