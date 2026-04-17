using UnityEngine;

public class CatalogueUIController : MonoBehaviour
{
    [SerializeField] private GameObject cataloguePanel;
    [SerializeField] private KeyCode toggleKey = KeyCode.C;

    private void Start()
    {
        if (cataloguePanel != null)
            cataloguePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleCatalogue();
        }
    }

    public void ToggleCatalogue()
    {
        if (cataloguePanel == null)
            return;

        cataloguePanel.SetActive(!cataloguePanel.activeSelf);
    }

    public void CloseCatalogue()
    {
        if (cataloguePanel != null)
            cataloguePanel.SetActive(false);
    }
}