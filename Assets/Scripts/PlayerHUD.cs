using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private Text currentHPtext;
    [SerializeField] private Text maxHPtext;

    [SerializeField] private WeaponUI weaponUI;

    [SerializeField] private Sprite genericSprite;

    

    public void UpdateHP(int currentHP, int maxHP)
    {
        currentHPtext.text = currentHP.ToString();
        maxHPtext.text = maxHP.ToString();

    }

    public void UpdateWeaponUI(Weapon newWeapon)
    {
        weaponUI.UpdateInfo(newWeapon.icon, newWeapon.magazineSize, newWeapon.magazineCount);
    }

    public void ReduceMagazine()
    {
        weaponUI.numberOfQuantity -= Time.deltaTime;
        weaponUI.updateMagazineInfo(weaponUI.numberOfQuantity);
    }

    public void Unequip()
    {
        weaponUI.UpdateInfo(genericSprite, 0, 0);
    }
}
