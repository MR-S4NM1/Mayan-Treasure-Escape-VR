using System.Collections;
using UnityEngine;


public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;
    [SerializeField] GameObject missingPiece;

    public PuzzlePiece[,] grid = new PuzzlePiece[3, 3]; 
    public Vector2Int emptyTilePos = new Vector2Int(2, 2); 

    [Header("Posicionamiento")]
    public Transform gridPos; 
    public float spacing = 1.5f; 

    protected GameManager gameManager;

    
    private int[,] solutionGrid = new int[3, 3]
    {
        {1, 2, 3},
        {1, 2, 3},
        {1, 2, 0}
    };

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

    public Vector3 GetWorldPosition(Vector2Int gridPos)
    {
        return this.gridPos.position + new Vector3(
            gridPos.x * spacing,
            -gridPos.y * spacing,
            0
        );
    }

    public bool IsAdjacent(Vector2Int pos)
    {
        int dx = Mathf.Abs(pos.x - emptyTilePos.x);
        int dy = Mathf.Abs(pos.y - emptyTilePos.y);
        return (dx + dy) == 1;
    }

    public void MoveTile(PuzzlePiece tile)
    {
        Vector2Int tilePos = tile.gridPos;
        if (!IsAdjacent(tilePos)) return;

        grid[emptyTilePos.x, emptyTilePos.y] = tile;
        grid[tilePos.x, tilePos.y] = null;

        Vector3 targetPos = GetWorldPosition(emptyTilePos);
        tile.MoveTo(targetPos);

        tile.gridPos = emptyTilePos;
        emptyTilePos = tilePos;

        if (CheckPuzzleSolved())
        {
            missingPiece.gameObject.SetActive(true);
        }
    }

    private bool CheckPuzzleSolved()
    {
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                if (solutionGrid[x, y] != 0 && grid[x, y] == null)
                    return false;

                if (grid[x, y] != null && grid[x, y].pieceID != solutionGrid[x, y])
                    return false;
            }
        }
        return true;
    }
}