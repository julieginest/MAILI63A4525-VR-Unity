using UnityEngine;

public class CenterPourAnyTilt : MonoBehaviour
{
    [SerializeField] private ParticleSystem pourParticles;

    [Header("Tilt Settings")]
    [SerializeField] private float startPourAngle = 60f;
    [SerializeField] private float stopPourAngle = 50f;

    private bool isPouring;

    private void Update()
    {
        float tiltAngle = Vector3.Angle(transform.up, Vector3.up);

        bool shouldPour = tiltAngle >= startPourAngle;

        if (shouldPour && !isPouring)
        {
            StartPour();
        }
        else if (!shouldPour && isPouring && tiltAngle <= stopPourAngle)
        {
            StopPour();
        }
    }

    private void StartPour()
    {
        isPouring = true;
        pourParticles.Play();
    }

    private void StopPour()
    {
        isPouring = false;
        pourParticles.Stop();
    }
}