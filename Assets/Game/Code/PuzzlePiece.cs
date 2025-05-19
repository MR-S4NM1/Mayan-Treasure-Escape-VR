using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PuzzlePiece : MonoBehaviour
{
    public Vector2Int gridPos; 
    public int pieceID; 
    private XRBaseInteractable interactable;

    private void Start()
    {
        
        interactable = GetComponent<XRBaseInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnSelected);
        }

        
        PuzzleManager.Instance.grid[gridPos.x, gridPos.y] = this;

        
        transform.position = PuzzleManager.Instance.GetWorldPosition(gridPos);
    }

    private void OnSelected(SelectEnterEventArgs args)
    {
        PuzzleManager.Instance.MoveTile(this);
    }

    public void MoveTo(Vector3 targetPosition)
    {
        StartCoroutine(MoveSmoothly(targetPosition));
    }

    private IEnumerator MoveSmoothly(Vector3 target)
    {
        float duration = 0.2f;
        float time = 0;
        Vector3 startPos = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPos, target, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
    }
}