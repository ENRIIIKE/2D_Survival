using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public abstract class EntityController : MonoBehaviour
{
    public EntitySO entitySO;
    [HideInInspector] 
    public EnemyLocationSpawner enemyLocationSpawner;
    public Transform temporaryObjects;

    [Header("Pathfinder")]
    private AIPath aiPath;
    private AIDestinationSetter aiDestinationSetter;

    [Header("Target Finding")]
    public float radius;
    public float radiusWhenFound;
    private float basicRadius;
    public LayerMask targetLayer;
    public bool targetFound;

    public bool showGizmos = false;

    [Header("Idle Movement")]
    public float idleCooldownMin;
    public float idleCooldownMax;
    private float idleTime;
    private float idleCooldown;
    private float idleMovementSpeed;

    [Header("Attack")]
    public float attackRadius;
    private void Start()
    {
        basicRadius = radius;
        aiPath = GetComponent<AIPath>();
        aiDestinationSetter = GetComponent<AIDestinationSetter>();

        idleMovementSpeed = entitySO.movementSpeed / 1.7f;

        enemyLocationSpawner = transform.parent.GetComponent<EnemyLocationSpawner>();

        temporaryObjects = GameObject.Find("--Temporary--").transform;
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
            Vector2 newPos;
            int numberOfAttempts = 0;
            do
            {
                float idleDistance = 5f;

                float xPos = transform.position.x;
                float yPos = transform.position.y;

                float minXPos = xPos - idleDistance;
                float maxXPos = xPos + idleDistance;

                float minYPos = yPos - idleDistance;
                float maxYPos = yPos + idleDistance;

                float newXPos = Random.Range(minXPos, maxXPos);
                float newYPos = Random.Range(minYPos, maxYPos);

                newPos = new Vector2(newXPos, newYPos);

                if (numberOfAttempts >= 5)
                {
                    newPos = enemyLocationSpawner.transform.position;
                    break;
                }
                numberOfAttempts++;

            } while (enemyLocationSpawner.RelocateEnemy(newPos));
            

            GameObject newEmptyGameObject = new GameObject();

            GameObject newIdleLocation = Instantiate(newEmptyGameObject, newPos, Quaternion.identity, temporaryObjects);


            newIdleLocation.name = "New Idle Position";

            aiDestinationSetter.target = newIdleLocation.transform;

            idleCooldown = Random.Range(idleCooldownMin, idleCooldownMax);
            idleTime = Time.time + idleCooldown;

            Destroy(newEmptyGameObject);
            Destroy(newIdleLocation, 5f);
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
        if (!showGizmos) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusWhenFound);
    }
}
