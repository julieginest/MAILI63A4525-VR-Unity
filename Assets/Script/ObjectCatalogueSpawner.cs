using UnityEngine;

public class ObjectCatalogueSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject tablePrefab;
    [SerializeField] private GameObject chairPrefab;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject foodPrefab;


    [Header("Spawn")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float randomOffsetRadius = 0.5f;

    public void SpawnTable()
    {
        SpawnObject(tablePrefab);
    }

    public void SpawnChair()
    {
        SpawnObject(chairPrefab);
    }

    public void SpawnBall()
    {
        SpawnObject(ballPrefab);
    }
    public void SpawnFood()
    {
        SpawnObject(foodPrefab);
    }

    private void SpawnObject(GameObject prefab)
    {
        if (prefab == null || spawnPoint == null)
            return;

        Vector2 random2D = Random.insideUnitCircle * randomOffsetRadius;
        Vector3 spawnPos = spawnPoint.position + new Vector3(random2D.x, 0f, random2D.y);

        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}