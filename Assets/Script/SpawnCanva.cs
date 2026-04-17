using UnityEngine;
using UnityEngine.UI;

public class CanvasSpawner : MonoBehaviour
{
    [Header("Références")]
    public GameObject canvasPrefab;

    [Header("Paramètres")]
    public float spawnDistance = 2f;
    public float heightOffset   = 1.5f;   // hauteur yeux
    public KeyCode spawnKey     = KeyCode.C;
    public bool spawnNewEachTime = false;

    [Header("Suivi en temps réel")]
    [Tooltip("Le Canvas suit le joueur tant qu'il est visible")]
    public bool followPlayer = true;
    [Tooltip("Vitesse de lissage (0 = instantané, 10 = très lent)")]
    public float followSmoothSpeed = 8f;

    private GameObject _currentCanvas;

    void Update()
    {
        if (Input.GetKeyDown(spawnKey))
        {
            if (spawnNewEachTime)
                SpawnCanvas();
            else
                ToggleCanvas();
        }

        // ── Suivi continu ──────────────────────────────────────────
        if (followPlayer && _currentCanvas != null && _currentCanvas.activeSelf)
            TrackPlayer();
    }

    // ── Déplace / oriente le Canvas vers le joueur chaque frame ──
    void TrackPlayer()
    {
        Vector3 targetPos = GetSpawnPosition();

        // Lerp pour un mouvement fluide (mets followSmoothSpeed = 0 pour instantané)
        _currentCanvas.transform.position = followSmoothSpeed > 0
            ? Vector3.Lerp(_currentCanvas.transform.position,
                           targetPos,
                           Time.deltaTime * followSmoothSpeed)
            : targetPos;

        // Toujours face à la caméra
        FaceCamera(_currentCanvas.transform);
    }

    void SpawnCanvas()
    {
        GameObject instance = Instantiate(canvasPrefab,
                                          GetSpawnPosition(),
                                          GetSpawnRotation());
        FaceCamera(instance.transform);
    }

    void ToggleCanvas()
    {
        if (_currentCanvas == null)
        {
            _currentCanvas = Instantiate(canvasPrefab,
                                         GetSpawnPosition(),
                                         GetSpawnRotation());
            FaceCamera(_currentCanvas.transform);
        }
        else
        {
            bool wasActive = _currentCanvas.activeSelf;

            if (!wasActive)
            {
                // Repositionne immédiatement avant d'afficher
                _currentCanvas.transform.position = GetSpawnPosition();
                FaceCamera(_currentCanvas.transform);
            }

            _currentCanvas.SetActive(!wasActive);
        }
    }

    // ── Helpers ───────────────────────────────────────────────────

    Vector3 GetSpawnPosition()
    {
        return transform.position
             + transform.forward * spawnDistance
             + Vector3.up * heightOffset;
    }

    Quaternion GetSpawnRotation()
    {
        return Quaternion.Euler(0, transform.eulerAngles.y, 0);
    }

    /// Fait regarder le transform vers la caméra (billboard)
    void FaceCamera(Transform t)
    {
        Transform cam = Camera.main.transform;
        t.LookAt(t.position + cam.rotation * Vector3.forward,
                 cam.rotation * Vector3.up);
    }
}