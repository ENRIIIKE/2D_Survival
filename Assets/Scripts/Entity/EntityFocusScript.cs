using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EntityFocusScript : MonoBehaviour
{
    public GameObject focusObject;
    public Slider entityBar;
    public TextMeshProUGUI entityText;
    public LayerMask focusLayer;
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
        var mousePosition = Input.mousePosition;
        mousePosition.z = cam.nearClipPlane;
        var worldPosition = cam.ScreenToWorldPoint(mousePosition);

        var entity = Physics2D.OverlapCircle(worldPosition, checkRadius, focusLayer);

        if (entity == null)
        {
            focusObject.SetActive(false);
            return;
        }
        
        focusObject.SetActive(true);
        entityFound = entity.transform.parent.gameObject;

        var entityHealthSystem = entityFound.GetComponent<EntityHealth>();

        entityText.text = entityFound.name;
        entityBar.value = entityHealthSystem.health;
        entityBar.maxValue = entityHealthSystem.maxHealth;
    }
}
