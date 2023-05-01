using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    public Text quantityText;
    [SerializeField] private Text quantityCountText;
    public float numberOfQuantity;

    public void UpdateInfo(Sprite weaponIcon, int quantity, int quantityCount)
    {
        icon.sprite = weaponIcon;
        int quantityCountAmount = quantity * quantityCount;
        quantityCountText.text = quantityCount.ToString();

        updateMagazineInfo(quantity);

    }

    public void updateMagazineInfo(float _quantity)
    {

        numberOfQuantity = _quantity;
        quantityText.text = numberOfQuantity.ToString("F0");


    }
}
