using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
[RequireComponent(typeof(Rigidbody))]
public class ManipulableObject : MonoBehaviour
{
    public static ManipulableObject CurrentHovered { get; private set; }

    public XRGrabInteractable GrabInteractable { get; private set; }
    public Rigidbody Body { get; private set; }

    public bool IsGrabbed => GrabInteractable != null && GrabInteractable.isSelected;
    public bool IsHovered => GrabInteractable != null && GrabInteractable.isHovered;

    private HoverHighlight hoverHighlight;

    private void Awake()
    {
        GrabInteractable = GetComponent<XRGrabInteractable>();
        Body = GetComponent<Rigidbody>();
        hoverHighlight = GetComponent<HoverHighlight>();
    }

    private void OnEnable()
    {
        GrabInteractable.hoverEntered.AddListener(OnHoverEntered);
        GrabInteractable.hoverExited.AddListener(OnHoverExited);
    }

    private void OnDisable()
    {
        GrabInteractable.hoverEntered.RemoveListener(OnHoverEntered);
        GrabInteractable.hoverExited.RemoveListener(OnHoverExited);
    }

    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        CurrentHovered = this;

        if (hoverHighlight != null)
            hoverHighlight.SetHighlighted(true);
    }

    private void OnHoverExited(HoverExitEventArgs args)
    {
        if (CurrentHovered == this)
            CurrentHovered = null;

        if (hoverHighlight != null)
            hoverHighlight.SetHighlighted(false);
    }
}