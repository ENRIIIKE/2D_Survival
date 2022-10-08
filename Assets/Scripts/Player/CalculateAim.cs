using UnityEngine;

public class CalculateAim : MonoBehaviour
{
    public Camera cam;
    private Vector3 worldPosition;
    public float sphereRadius;

    void Update()
    {
        worldPosition = SendMousePosition();

        transform.position = worldPosition;

        Vector3 normalizedPosition = Vector3.Normalize(transform.localPosition);

        transform.localPosition = normalizedPosition;
    }
    public Vector3 SendMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = cam.nearClipPlane;
        worldPosition = cam.ScreenToWorldPoint(mousePosition);

        return worldPosition;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.parent.position, worldPosition);
        Gizmos.DrawWireSphere(transform.position, sphereRadius);
    }

}
