using System.Collections;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public PuzzlePiece[,] grid = new PuzzlePiece[3, 3];
    public Vector2Int emptyTilePos = new Vector2Int(2, 2); 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public bool IsAdjacent(Vector2Int pos)
    {
        int dirX = Mathf.Abs(pos.x - emptyTilePos.x);
        int dy = Mathf.Abs(pos.y - emptyTilePos.y);
        return (dirX + dy) == 1;
    }

    public void MoveTile(PuzzlePiece tile)
    {
        Vector2Int tilePos = tile.gridPos;
        if (!IsAdjacent(tilePos))
        {
            return;
        }

        grid[emptyTilePos.x, emptyTilePos.y] = tile;
        grid[tilePos.x, tilePos.y] = null;

       
        Vector3 targetPos = GetWorldPosition(emptyTilePos);
        tile.MoveTo(targetPos);

     
        tile.gridPos = emptyTilePos;
        emptyTilePos = tilePos;
    }

    public Vector3 GetWorldPosition(Vector2Int gridPos)
    {
        
        return new Vector3(gridPos.x, 0, -gridPos.y);
    }
}
