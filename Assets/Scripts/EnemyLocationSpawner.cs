using Pathfinding.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyData
{
    public GameObject enemyPrefab;
    public int enemyAmount;
}
public class EnemyLocationSpawner : MonoBehaviour
{
    public EnemyData[] enemyData;
    public float insideRadius;
    public bool showGizmos = false;

    private void Start()
    {
        SpawnEnemy();
    }
    public void SpawnEnemy()
    {
        int elementIndex = 0;

        foreach(EnemyData enemy in enemyData)
        {
            for(int j = 0; j < enemyData[elementIndex].enemyAmount; j++)
            {
                Vector2 spawnLocation = FindLocation();

                GameObject instance = Instantiate(enemyData[elementIndex].enemyPrefab, spawnLocation, 
                    Quaternion.identity, transform);

                instance.name = enemyData[elementIndex].enemyPrefab.name;

                if(j > 50)
                {
                    Debug.LogWarning("Loop broke");
                    break;
                }
            }

            Debug.Log("<color=white>" + gameObject.name + "</color> Spawned: <color=white>" + 
                enemyData[elementIndex].enemyPrefab.name +
                "</color> Amount: <color=white>" + enemyData[elementIndex].enemyAmount + "</color>");

            elementIndex++;
        }
    }
    private Vector2 FindLocation()
    {
        float newX = Random.Range(transform.position.x - insideRadius, transform.position.x + insideRadius);
        float newY = Random.Range(transform.position.y - insideRadius, transform.position.y + insideRadius);

        Vector2 foundLocation = new Vector2(newX, newY);
        return foundLocation;
    }

    public bool RelocateEnemy(Vector2 generatedLocation)
    {
        float distanceOutside = Vector2.Distance(transform.position, generatedLocation);

        if (distanceOutside > insideRadius)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        if (!showGizmos) return;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, insideRadius);
    }
}
