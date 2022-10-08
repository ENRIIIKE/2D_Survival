using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
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

            if (collider != null)
            {
                IInteractible interactible = collider.GetComponent<IInteractible>();

                interactible.Interact();
                Debug.Log("Interacted");
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
