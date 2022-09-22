using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class EntityFocusScript : MonoBehaviour
{
    public GameObject focusObject;
    public Slider entityBar;
    public TextMeshProUGUI entityText;
    public LayerMask entityLayer;
    public float checkRadius;
    public Camera cam;

    [Space]
    public GameObject entityFound;
    private void Update()
    {
        FocusEntity();
    }
    private void FocusEntity()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = cam.nearClipPlane;
        Vector3 worldPosition = cam.ScreenToWorldPoint(mousePosition);

        Collider2D entity = Physics2D.OverlapCircle(worldPosition, checkRadius, entityLayer);

        if (entity == null)
        {
            focusObject.SetActive(false);
            return;
        }
        
        focusObject.SetActive(true);
        entityFound = entity.transform.parent.gameObject;

        entityText.text = entityFound.name;
        entityBar.value = entityFound.GetComponent<EntityHealth>().Health;
    }
}
