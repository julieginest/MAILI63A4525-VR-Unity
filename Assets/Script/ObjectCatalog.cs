using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectCatalog", menuName = "VR/Object Catalog")]
public class ObjectCatalog : ScriptableObject
{
    [System.Serializable]
    public class CatalogItem
    {
        public string itemName;
        public GameObject prefab;
        public Sprite thumbnail;
    }

    public List<CatalogItem> items = new List<CatalogItem>();
}