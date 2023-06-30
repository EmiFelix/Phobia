using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Item/Weapon")]

public class Weapon : Item
{
    public GameObject prefab;
    public int magazineSize;
    public int magazineCount;
    public float range;
    public WeaponType weaponType;
    public WeaponStyle weaponStyle;
    public int id;
    public int magazineSizeINITIAL;
}

public enum WeaponType { Key, Usable, Hands, Fuse, Forms}
public enum WeaponStyle { Melee, Primary, Secondary, Tertiary}