using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;

    public Transform inventoryTransform;

    [SerializeField]
    private InventorySlots[] inventorySlots;

    public GameObject panel;



    private void Start()
    {
        inventory = Inventory.instance;
        inventory.inventoryCallback += UpdateUI;

        panel.SetActive(false);

        inventorySlots = inventoryTransform.GetComponentsInChildren<InventorySlots>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            panel.SetActive(!panel.activeSelf);
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                inventorySlots[i].AddItem(inventory.items[i]);
            }
            else
            {
                inventorySlots[i].RemoveItem();
            }
        }

    }
}
