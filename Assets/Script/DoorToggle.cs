using System.Collections;
using UnityEngine;

public class SlidingDoorClickable : MonoBehaviour
{
    [SerializeField] private Vector3 openOffset = new Vector3(1.2f, 0f, 0f);
    [SerializeField] private float speed = 2f;

    private Vector3 closedLocalPosition;
    private Vector3 openLocalPosition;

    private bool isOpen = false;
    private bool isMoving = false;

    private void Awake()
    {
        closedLocalPosition = transform.localPosition;
        openLocalPosition = closedLocalPosition + openOffset;
    }

    private void OnMouseDown()
    {
        if (!isMoving)
            StartCoroutine(MoveDoor());
    }

    public void ToggleDoor()
    {
        if (!isMoving)
            StartCoroutine(MoveDoor());
    }

    private IEnumerator MoveDoor()
    {
        isMoving = true;

        Vector3 start = transform.localPosition;
        Vector3 target = isOpen ? closedLocalPosition : openLocalPosition;

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * speed;
            transform.localPosition = Vector3.Lerp(start, target, t);
            yield return null;
        }

        transform.localPosition = target;
        isOpen = !isOpen;
        isMoving = false;
    }
}