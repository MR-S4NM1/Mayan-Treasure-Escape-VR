using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public Transform[] cellPositions;
    public Transform emptySlot;

    public float snapDistance = 0.3f;

    public void TryMovePiece(Transform piece)
    {
        float distance = Vector3.Distance(piece.position, emptySlot.position);

        if (distance < snapDistance)
        {
            Vector3 tempPosition = piece.position;
            piece.position = emptySlot.position;
            emptySlot.position = tempPosition;
        }
    }
}
