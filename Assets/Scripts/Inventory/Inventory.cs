using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    #endregion

    public delegate void InventoryCallback();
    public InventoryCallback inventoryCallback;

    public List<ItemData> items = new List<ItemData>();

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    public void Add(ItemData item)
    {
        items.Add(item);

        if (inventoryCallback != null)
        {
            inventoryCallback.Invoke();
        }
    }
    public void Remove(ItemData item)
    {
        items.Remove(item);

        if (inventoryCallback != null)
        {
            inventoryCallback.Invoke();
        }
    }
    
}
