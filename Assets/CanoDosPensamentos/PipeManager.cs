using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class PipeManager : MonoBehaviour
{
    public PipeRotator[,] grid; // Assign from your layout logic
    public Vector2Int startPipe;
    public Vector2Int endPipe;

    public Sprite cano3PontasAgua;
    public Sprite canoMaisAgua;
    public Sprite canoRetoAgua;
    public Sprite canoCurvadoAgua;
    public Sprite cano3Pontas;
    public Sprite canoMais;
    public Sprite canoReto;
    public Sprite canoCurvado;

    private void Awake()
    {
        // Initialize the grid here or assign it from the Inspector
        grid = new PipeRotator[4, 4];

        // Automatically fill the grid with Pipe components in children
        PipeRotator[] allPipes = GetComponentsInChildren<PipeRotator>();
        foreach (PipeRotator pipe in allPipes)
        {
            Vector2Int pos = pipe.gridPosition;
            grid[pos.x, pos.y] = pipe;
        }
    }

    public void CheckPath()
    {
        // Example: start from a known starting pipe (set via Inspector or code)
        PipeRotator startPipe = grid[0, 0]; // Example, make sure this isn't null

        if (startPipe == null)
        {
            Debug.LogWarning("No starting pipe found at grid[0,0]");
            return;
        }

        // Use BFS or DFS to traverse connected pipes
        HashSet<PipeRotator> visited = new HashSet<PipeRotator>();
        visited.Clear();
        Traverse(startPipe, visited);
        PaintVisitedPipes(visited);

        if (visited.Contains(grid[endPipe.x, endPipe.y]))
        {
            Debug.Log("Path complete!");
            GameManagerCanos.Instance.CompleteMinigame();
        }
        else
        {
            Debug.Log("Path incomplete.");
        }
    }

    private void PaintVisitedPipes(HashSet<PipeRotator> visited)
    {
        foreach (PipeRotator pipe in grid)
        {
            if (pipe == null) continue;

            if (pipe.name.Contains("3 pontas"))
            {
                pipe.GetComponent<Image>().sprite = visited.Contains(pipe) ? cano3PontasAgua : cano3Pontas;
            }
            else if (pipe.name.Contains("Mais"))
            {
                pipe.GetComponent<Image>().sprite = visited.Contains(pipe) ? canoMaisAgua : canoMais;
            }
            else if (pipe.name.Contains("Reto"))
            {
                pipe.GetComponent<Image>().sprite = visited.Contains(pipe) ? canoRetoAgua : canoReto;
            }
            else if (pipe.name.Contains("Curvado"))
            {
                pipe.GetComponent<Image>().sprite = visited.Contains(pipe) ? canoCurvadoAgua : canoCurvado;
            }
        }

    }

    private void Traverse(PipeRotator pipe, HashSet<PipeRotator> visited)
    {
        if (pipe == null || visited.Contains(pipe)) return;

        visited.Add(pipe);

        foreach (PipeRotator neighbor in GetConnectedNeighbors(pipe))
        {
            Traverse(neighbor, visited);
        }
    }

    private List<PipeRotator> GetConnectedNeighbors(PipeRotator pipe)
    {
        List<PipeRotator> neighbors = new List<PipeRotator>();

        Vector2Int pos = pipe.gridPosition;

        // Check each direction based on pipe's connections
        if (pipe.HasConnection(Direction.Up) && IsValid(pos.x, pos.y - 1))
        {
            PipeRotator up = grid[pos.x, pos.y - 1];
            if (up != null && up.HasConnection(Direction.Down))
                neighbors.Add(up);
        }

        // Repeat for other directions...
        if (pipe.HasConnection(Direction.Right) && IsValid(pos.x + 1, pos.y))
        {
            PipeRotator right = grid[pos.x + 1, pos.y];
            if (right != null && right.HasConnection(Direction.Left))
                neighbors.Add(right);
        }
        if (pipe.HasConnection(Direction.Down) && IsValid(pos.x, pos.y + 1))
        {
            PipeRotator down = grid[pos.x, pos.y + 1];
            if (down != null && down.HasConnection(Direction.Up))
                neighbors.Add(down);
        }
        if (pipe.HasConnection(Direction.Left) && IsValid(pos.x - 1, pos.y))
        {
            PipeRotator left = grid[pos.x - 1, pos.y];
            if (left != null && left.HasConnection(Direction.Right))
                neighbors.Add(left);
        }

        return neighbors;
    }

    private bool IsValid(int x, int y)
    {
        return x >= 0 && y >= 0 && x < grid.GetLength(0) && y < grid.GetLength(1);
    }
}
