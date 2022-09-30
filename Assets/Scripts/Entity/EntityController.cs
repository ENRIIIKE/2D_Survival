using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public abstract class EntityController : MonoBehaviour
{
    public EntitySO entitySO;

    [Header("Pathfinder")]
    private AIPath aiPath;
    private AIDestinationSetter aiDestinationSetter;

    [Header("Target Finding")]
    public float radius;
    public float radiusWhenFound;
    private float basicRadius;
    public LayerMask targetLayer;
    public bool targetFound;

    [Header("Idle Movement")]
    public float idleCooldownMin;
    public float idleCooldownMax;
    private float idleTime;
    private float idleCooldown;
    private float idleMovementSpeed;
    private void Start()
    {
        basicRadius = radius;
        aiPath = GetComponent<AIPath>();
        aiDestinationSetter = GetComponent<AIDestinationSetter>();

        idleMovementSpeed = entitySO.movementSpeed / 1.7f;
    }
    private void Update()
    {
        FindTarget();
        IdleMove();
    }
    public abstract void Move();

    public abstract void Attack();

    public void FindTarget()
    {
        try 
        {
            Collider2D targetCollider = Physics2D.OverlapCircle(transform.position, 
                radius, targetLayer);

            if (targetCollider == null)
            {   
                aiPath.maxSpeed = idleMovementSpeed;
                StopPathfinding();
                RadiusChange(false);
            }

            if (targetCollider.gameObject.CompareTag("Player"))
            {
                GameObject target = targetCollider.gameObject;

                aiPath.maxSpeed = entitySO.movementSpeed;
                StartPathfinding(target);
                RadiusChange(true);
            }
        }
        catch
        {

        }
    }

    private void StartPathfinding(GameObject target)
    {
        aiDestinationSetter.target = target.transform;
        targetFound = true;
    }
    private void StopPathfinding()
    {
        aiDestinationSetter.target = null;
        targetFound = false;
    }

    public void SuspendAttack()
    {

    }

    public void IdleMove()
    {
        if (idleTime < Time.time && !targetFound)
        {
            float idleDistance = 4f;

            float xPos = transform.localPosition.x;
            float yPos = transform.localPosition.y;

            float minXPos = xPos - idleDistance;
            float maxXPos = xPos + idleDistance;

            float minYPos = yPos - idleDistance;
            float maxYPos = yPos + idleDistance;

            float newXPos = Random.Range(minXPos, maxXPos);
            float newYPos = Random.Range(minYPos, maxYPos);

            Vector2 newPos = new Vector2(newXPos, newYPos);

            GameObject newEmptyGameObject = new GameObject();

            GameObject newIdleLocation = Instantiate(newEmptyGameObject, newPos, Quaternion.identity);

            aiDestinationSetter.target = newIdleLocation.transform;

            idleCooldown = Random.Range(idleCooldownMin, idleCooldownMax);
            idleTime = Time.time + idleCooldown;
        }
    }
    private void RadiusChange(bool found)
    {
        if (found)
        {
            radius = radiusWhenFound;
        }
        else
        {
            radius = basicRadius;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusWhenFound);
    }
}
