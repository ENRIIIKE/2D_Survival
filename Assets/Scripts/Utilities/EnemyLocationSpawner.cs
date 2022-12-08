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
    public float insideRadius = 6f;
    public bool showGizmos = false;

    private void Start()
    {
        SpawnEnemy();
    }
    private void SpawnEnemy()
    {
        var elementIndex = 0;

        foreach(var enemy in enemyData)
        {
            for(var j = 0; j < enemyData[elementIndex].enemyAmount; j++)
            {
                var spawnLocation = FindLocation();

                var instance = Instantiate(enemyData[elementIndex].enemyPrefab, spawnLocation, 
                    Quaternion.identity, transform);

                instance.name = enemyData[elementIndex].enemyPrefab.name;

                if (j <= 50) continue;
                Debug.LogWarning("Loop broke");
                break;
            }

            Debug.Log("<color=white>" + gameObject.name + "</color> Spawned: <color=white>" + 
                enemyData[elementIndex].enemyPrefab.name +
                "</color> Amount: <color=white>" + enemyData[elementIndex].enemyAmount + "</color>");

            elementIndex++;
        }
    }
    private Vector2 FindLocation()
    {
        var pos = transform.position;
        
        var newX = Random.Range(pos.x - insideRadius, pos.x + insideRadius);
        var newY = Random.Range(pos.y - insideRadius, pos.y + insideRadius);

        Vector2 foundLocation = new Vector2(newX, newY);
        return foundLocation;
    }

    private void OnDrawGizmos()
    {
        if (!showGizmos) return;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, insideRadius);
    }
}
