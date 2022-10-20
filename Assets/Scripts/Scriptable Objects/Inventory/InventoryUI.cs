using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject panel;

    private void Start()
    {
        panel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            panel.SetActive(!panel.activeSelf);
        }
    }
}
