using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickable : MonoBehaviour, IInteractible
{
    public ItemData item;


    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Interact()
    {

        Destroy(gameObject);
    }
}
