using UnityEngine;
using Oculus.Interaction;

public class ObjectPlacer : MonoBehaviour
{
    [Header("Catalog")]
    public ObjectCatalog catalog;

    [Header("Placement")]
    public LayerMask placementLayerMask;        // Sur quelles surfaces poser
    public Material ghostMaterial;              // Matériau semi-transparent du fantôme
    public float maxRayDistance = 10f;

    [Header("References")]
    public Transform rightControllerTransform;  // Attach: OVRCameraRig > RightHandAnchor

    // -- État interne --
    private int _selectedIndex = -1;            // -1 = rien de sélectionné
    private GameObject _ghostObject;            // Preview fantôme
    private GameObject _selectedPrefab;

    // ── API appelée par l'UI ──────────────────────────────────────────
    public void SelectItem(int index)
    {
        if (index < 0 || index >= catalog.items.Count) return;

        _selectedIndex = index;
        _selectedPrefab = catalog.items[index].prefab;

        // Recrée le fantôme
        DestroyGhost();
        _ghostObject = Instantiate(_selectedPrefab);
        SetGhostMaterial(_ghostObject, ghostMaterial);
        // Désactive les colliders du fantôme pour ne pas bloquer le raycast
        foreach (var col in _ghostObject.GetComponentsInChildren<Collider>())
            col.enabled = false;
    }

    public void CancelSelection()
    {
        _selectedIndex = -1;
        _selectedPrefab = null;
        DestroyGhost();
    }

    // ── Chaque frame ─────────────────────────────────────────────────
    void Update()
    {
        if (_selectedIndex < 0) return;

        UpdateGhostPosition();

        // Bouton A (index 0) ou Trigger droit = confirmer le placement
        if (OVRInput.GetDown(OVRInput.Button.One) || OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
            PlaceObject();

        // Bouton B (index 1) = annuler
        if (OVRInput.GetDown(OVRInput.Button.Two))
            CancelSelection();
    }

    // ── Logique interne ───────────────────────────────────────────────
    private void UpdateGhostPosition()
    {
        if (_ghostObject == null) return;

        if (RaycastFromController(out RaycastHit hit))
        {
            _ghostObject.SetActive(true);
            _ghostObject.transform.position = hit.point;
            // Aligne sur la normale de la surface (ex : pente)
            _ghostObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }
        else
        {
            _ghostObject.SetActive(false);
        }
    }

    private void PlaceObject()
    {
        if (!RaycastFromController(out RaycastHit hit)) return;

        Instantiate(
            _selectedPrefab,
            hit.point,
            Quaternion.FromToRotation(Vector3.up, hit.normal)
        );

        // Optionnel : rester en mode placement pour poser plusieurs fois
        // Commenter la ligne suivante pour poser en continu
        CancelSelection();
    }

    private bool RaycastFromController(out RaycastHit hit)
    {
        Ray ray = new Ray(
            rightControllerTransform.position,
            rightControllerTransform.forward
        );
        return Physics.Raycast(ray, out hit, maxRayDistance, placementLayerMask);
    }

    private void SetGhostMaterial(GameObject go, Material mat)
    {
        foreach (var renderer in go.GetComponentsInChildren<Renderer>())
        {
            var mats = new Material[renderer.materials.Length];
            for (int i = 0; i < mats.Length; i++) mats[i] = mat;
            renderer.materials = mats;
        }
    }

    private void DestroyGhost()
    {
        if (_ghostObject != null) Destroy(_ghostObject);
        _ghostObject = null;
    }
}