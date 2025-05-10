using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PipeRotator : MonoBehaviour, IPointerClickHandler
{
    public Vector2Int gridPosition; // Set this from your grid script
    public List<Direction> connections = new List<Direction>(); // Current active directions
    private int rotationSteps = 0;

    public PipeManager pipeManager;

    private void Awake()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        rotationSteps = (rotationSteps + 1) % 4;
        transform.parent.Rotate(0f, 0f, -90f);

        // Rotate the connections
        for (int i = 0; i < connections.Count; i++)
        {
            connections[i] = RotateDirectionClockwise(connections[i]);
        }

        pipeManager.CheckPath(); // Check the path after rotation
    }

    private Direction RotateDirectionClockwise(Direction dir)
    {
        //Debug.Log($"Rotating {dir} clockwise to {(Direction)(((int)dir + 1) % 4)}");
        return (Direction)(((int)dir + 1) % 4);
    }

    public bool HasConnection(Direction dir)
    {
        return connections.Contains(dir);
    }
}
