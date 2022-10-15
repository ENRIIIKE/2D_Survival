using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    //Script for interactions with interactibles

    public float radius;
    public LayerMask layerMask;
    public Camera cam;

    public bool showGizmos;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D collider = Physics2D.OverlapCircle(transform.position,
                radius, layerMask);

            Debug.Log("Found: " + collider.gameObject.name);

            if (collider != null)
            {
                IInteractible interactible = collider.GetComponent<IInteractible>();

                interactible.Interact();
                Debug.Log("Interacted with " + collider.name, collider.gameObject);
            }
        }
    }
    public void OnDrawGizmosSelected()
    {
        if (showGizmos)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
