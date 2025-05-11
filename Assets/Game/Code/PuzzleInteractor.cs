using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRBaseInteractable))]
public class PuzzleInteractor : MonoBehaviour
{
    private XRBaseInteractable interactable;
    private PuzzleManager puzzleManager;

    private void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();
    }

    private void Start()
    {
        puzzleManager = FindObjectOfType<PuzzleManager>();

        interactable.selectEntered.AddListener(OnSelect);
    }

    private void OnSelect(SelectEnterEventArgs args)
    {
        if (puzzleManager != null)
        {
            puzzleManager.TryMovePiece(transform);
        }
    }

    private void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(OnSelect);
    }
}
