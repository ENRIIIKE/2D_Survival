using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EquipmentSlots : MonoBehaviour
{
    public ItemData itemData;
    public Image image;

    public void AddItem(ItemData item)
    {
        itemData = item;

        image.sprite = item.sprite;
        image.enabled = true;
    }
    public void RemoveItem()
    {
        itemData = null;

        image.sprite = null;
        image.enabled = false;

    }
}
