using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectionMenuUI : MonoBehaviour
{
    [Header("References")]
    public ObjectPlacer placer;
    public ObjectCatalog catalog;

    [Header("UI")]
    public Transform buttonContainer;   // GridLayoutGroup ici
    public GameObject buttonPrefab;     // Prefab : Button + Image + TMP_Text
    public Transform leftHandAnchor;    // OVRCameraRig > LeftHandAnchor

    [Header("Menu Behavior")]
    public bool followLeftHand = true;
    public Vector3 offset = new Vector3(0, 0.1f, 0.2f);

    void Start()
    {
        BuildMenu();
    }

    void Update()
    {
        if (!followLeftHand) return;

        // Le menu suit la main gauche
        transform.position = leftHandAnchor.TransformPoint(offset);
        transform.rotation = leftHandAnchor.rotation;

        // Bouton Y = afficher/masquer le menu
        if (OVRInput.GetDown(OVRInput.Button.Four))
            gameObject.SetActive(!gameObject.activeSelf);
    }

    private void BuildMenu()
    {
        foreach (Transform child in buttonContainer) Destroy(child.gameObject);

        for (int i = 0; i < catalog.items.Count; i++)
        {
            int index = i; // capture pour le lambda
            var item = catalog.items[i];

            GameObject btn = Instantiate(buttonPrefab, buttonContainer);

            // Thumbnail
            btn.GetComponentInChildren<Image>().sprite = item.thumbnail;

            // Nom
            btn.GetComponentInChildren<TMP_Text>().text = item.itemName;

            // Click → sélectionner l'objet ET fermer le menu
            btn.GetComponent<Button>().onClick.AddListener(() =>
            {
                placer.SelectItem(index);
                gameObject.SetActive(false);
            });
        }
    }
}