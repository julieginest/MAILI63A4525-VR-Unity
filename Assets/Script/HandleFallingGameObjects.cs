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
     if(transform.position.y < -10)
        {
            if (isPlayer)
            {
                transform.position =new Vector3(0, 1, 0);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }   
    }
}
