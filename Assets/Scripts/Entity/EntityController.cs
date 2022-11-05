using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
    public EntitySO entitySO;
    public Transform temporaryObjects;
    public Behaviour behaviour;

    [Header("Target Finding")]
    public float radius;
    public float radiusWhenFound;
    public LayerMask targetLayer;
    public bool targetFound;

    public bool showGizmos = false;


    [Header("Attack")]
    public float attackRadius;
    private void Start()
    {
        temporaryObjects = GameObject.Find("--Temporary--").transform;
    }

    public abstract void Move();

    public abstract void Attack();

}
