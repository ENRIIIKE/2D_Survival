using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlots : MonoBehaviour
{
    public Sprite itemSprite;
    public Image image;
    public GameObject removeButton;

    [SerializeField]
    private ItemData itemData;

    public void AddItem(ItemData item)
    {
        itemData = item;

        removeButton.GetComponent<Button>().interactable = true;
        removeButton.GetComponent<Image>().enabled = true;

        image.sprite = item.sprite;
        image.enabled = true;
    }
    public void RemoveItem()
    {
        itemData = null;

        removeButton.GetComponent<Button>().interactable = true;
        removeButton.GetComponent<Image>().enabled = false;

        image.sprite = null;
        image.enabled = false;

    }
    public void OnRemoveButton()
    {
        Inventory.instance.Remove(itemData);
    }
    public void UseItem()
    {
        if (itemData != null)
        {
            itemData.Use();
        }
    }
}
