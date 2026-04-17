using UnityEngine;

public class HoverHighlight : MonoBehaviour
{
    [SerializeField] private Renderer targetRenderer;
    [SerializeField] private Material highlightMaterial;

    private Material originalMaterial;

    private void Awake()
    {
        if (targetRenderer == null)
            targetRenderer = GetComponentInChildren<Renderer>();

        if (targetRenderer != null)
            originalMaterial = targetRenderer.material;
    }

    public void SetHighlighted(bool highlighted)
    {
        if (targetRenderer == null || highlightMaterial == null)
            return;

        targetRenderer.material = highlighted ? highlightMaterial : originalMaterial;
    }
}