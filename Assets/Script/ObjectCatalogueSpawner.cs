using UnityEngine;

public class ObjectCatalogueSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject tablePrefab;
    [SerializeField] private GameObject chairPrefab;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject foodPrefab;

    [Header("Spawn")]
    [SerializeField] private float spawnDistance = 2f;
    [SerializeField] private float randomOffsetRadius = 0.5f;

    private Transform playerCamera;

    private void Start()
    {
        playerCamera = Camera.main.transform;
    }

    public void SpawnTable() => SpawnObject(tablePrefab);
    public void SpawnChair() => SpawnObject(chairPrefab);
    public void SpawnBall() => SpawnObject(ballPrefab);
    public void SpawnFood() => SpawnObject(foodPrefab);

    private void SpawnObject(GameObject prefab)
    {
        if (prefab == null || playerCamera == null)
            return;

        // Base position: in front of player
        Vector3 forward = playerCamera.forward;
        forward.y = 0f; // keep objects on ground level
        forward.Normalize();

        Vector3 basePos = playerCamera.position + forward * spawnDistance;

        // Random offset so objects don’t stack
        Vector2 random2D = Random.insideUnitCircle * randomOffsetRadius;
        Vector3 offset = new Vector3(random2D.x, 0f, random2D.y);

        Vector3 spawnPos = basePos + offset;

        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}