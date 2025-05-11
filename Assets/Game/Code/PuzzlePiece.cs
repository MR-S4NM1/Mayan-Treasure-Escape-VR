using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PuzzlePiece : MonoBehaviour
{
    private XRGrabInteractable grab;
    public int index; 

    private void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();
        grab.selectExited.AddListener(OnRelease);
    }

    void OnRelease(SelectExitEventArgs args)
    {
        if (PuzzleManager.Instance.CanMoveToEmpty(transform.position))
        {
            PuzzleManager.Instance.MoveToEmpty(transform);
        }
    }
}
