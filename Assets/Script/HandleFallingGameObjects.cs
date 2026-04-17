using Unity.VisualScripting;
using UnityEngine;

public class HandleFallingGameObjects : MonoBehaviour
{
    [SerializeField] private bool isPlayer = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            if (isPlayer)
            {
                transform.position = new Vector3(-56.9f, 5.19f, 227.9f);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
