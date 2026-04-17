using UnityEngine;

public class XRObjectManipulationManager : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private float rotationStep = 45f;
    [SerializeField] private KeyCode rotateRightKey = KeyCode.E;
    [SerializeField] private KeyCode rotateLeftKey = KeyCode.Q;

    [Header("Delete")]
    [SerializeField] private float deleteHoldDuration = 1f;
    [SerializeField] private KeyCode deleteKey = KeyCode.Delete;

    private float deleteTimer;

    private void Update()
    {
        ManipulableObject target = GetCurrentTarget();

        HandleSnapRotation(target);
        HandleDeleteHold(target);
    }

    private ManipulableObject GetCurrentTarget()
    {
        ManipulableObject[] allObjects = FindObjectsByType<ManipulableObject>(FindObjectsSortMode.None);

        foreach (var obj in allObjects)
        {
            if (obj != null && obj.IsGrabbed)
                return obj;
        }

        return ManipulableObject.CurrentHovered;
    }

    private void HandleSnapRotation(ManipulableObject target)
    {
        if (target == null)
            return;

        if (Input.GetKeyDown(rotateRightKey))
        {
            RotateObject(target, rotationStep);
        }

        if (Input.GetKeyDown(rotateLeftKey))
        {
            RotateObject(target, -rotationStep);
        }
    }

    private void RotateObject(ManipulableObject target, float angle)
    {
        target.transform.Rotate(Vector3.up, angle, Space.World);
    }

    private void HandleDeleteHold(ManipulableObject target)
    {
        if (target == null)
        {
            deleteTimer = 0f;
            return;
        }

        if (Input.GetKey(deleteKey))
        {
            deleteTimer += Time.deltaTime;

            if (deleteTimer >= deleteHoldDuration)
            {
                Destroy(target.gameObject);
                deleteTimer = 0f;
            }
        }
        else
        {
            deleteTimer = 0f;
        }
    }
}