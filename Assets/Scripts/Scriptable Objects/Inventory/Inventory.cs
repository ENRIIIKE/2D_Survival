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

    private void Start()
    {
        inventoryCallback += UpdateUI;

    }

    [ExecuteInEditMode]
    public virtual void UpdateUI()
    {
        //Update Icons

    }
    public void Add(ItemData item)
    {
        items.Add(item);
    }
    public void Remove(ItemData item)
    {
        items.Remove(item);
    }
}
