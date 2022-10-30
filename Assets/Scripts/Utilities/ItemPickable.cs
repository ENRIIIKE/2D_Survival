using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickable : MonoBehaviour, IInteractible
{
    public ItemData item;
    public void Interact()
    {
        Inventory.instance.Add(item);

        Destroy(gameObject);
    }

    [ContextMenu("Update Object")]
    void UpdateObject()
    {
        GetComponent<SpriteRenderer>().sprite = item.sprite;
        name = "Pickable: " + item.itemName;
    }
}
