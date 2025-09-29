using deVoid.Utils;
using Project.InputSignals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IsometricMovement : MonoBehaviour
{
    public Vector3 WorldSpaceToMove;
    public Vector3Int GridSpaceToMove;

    public int walkSpeed;
    bool isFacingUp, isFacingRight;
    bool isWalking;

    public Grid world;
    public Tilemap tilemap;

    Dictionary<Direction, Vector3Int> directionVectors = new Dictionary<Direction, Vector3Int>
      {
        { Direction.North, new Vector3Int(1, 1) },
        { Direction.South, new Vector3Int(-1, -1) },
        { Direction.East, new Vector3Int(1, -1) },
        { Direction.West, new Vector3Int(-1, 1) },
        { Direction.NorthEast, new Vector3Int(1, 0) },
        { Direction.NorthWest, new Vector3Int(0, 1) },
        { Direction.SouthEast, new Vector3Int(0, -1) },
        { Direction.SouthWest, new Vector3Int(-1, 0) },
    };
    private void Awake()
    {
        Signals.Get<InputDirectionSignal>().AddListener(OnReceiveInputDirection);
    }

    private void OnDestroy()
    {
        Signals.Get<InputDirectionSignal>().RemoveListener(OnReceiveInputDirection);
    }
    void Start()
    {
        if(tilemap == null)
        {
            tilemap = FindFirstObjectByType<Tilemap>();
            if(tilemap == null)
            {
                Debug.Log("No tilemap");
            }
        }
    }

    TileBase GetTile(Vector3Int coordinate)
    {
        BoundsInt bounds = tilemap.cellBounds;

        foreach(var pos in bounds.allPositionsWithin)
        {
            TileBase tile = tilemap.GetTile(pos);
            if(tile != null)
            {
                Debug.Log($"Tile found at {pos}: {tile.name}");
            }
            if(pos == coordinate)
            {
                return tile;
            }
        }
        return null;
    }

    IEnumerator LerpToLocation(Vector3Int coordinate)
    {
        Vector3 targetPosition = world.GetCellCenterWorld(coordinate);
        //var targetPosition = world.GetCellCenterLocal(coordinate);
        Vector3 startPosition = transform.position;

        if(startPosition == targetPosition)
        {
            yield return null;
        }

        float journeyLength = Vector2.Distance(startPosition, targetPosition);
        float startTime = Time.time;

        isWalking = true;
        while (transform.position != targetPosition)
        {
            float distCovered = (Time.time - startTime) * walkSpeed;
            float fractionOfJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
            yield return null; // Wait for the next frame
        }

        transform.position = targetPosition;
        isWalking = false;
    }

    private void OnReceiveInputDirection(Direction direction)
    {
        Vector3Int currentLoc = world.WorldToCell(transform.position);
        

        Debug.Log($"Currently at {currentLoc.x},{currentLoc.y},{currentLoc.z}");
        if(direction == Direction.None)
        {
            return;
        }
        //move one space in a direction
        Vector3Int dirVector = directionVectors[direction];
        GridSpaceToMove = currentLoc + dirVector;
        WorldSpaceToMove = world.CellToWorld(GridSpaceToMove);
        if(tilemap)
        {
            var result = tilemap.GetTile(GridSpaceToMove);
            Debug.Log($"Result is {result}");
        }
        //TileData data;
        //result.GetTileData(GridSpaceToMove, tilemap, data);


        if (!isWalking)
        {
            StartCoroutine(LerpToLocation(GridSpaceToMove));

        }

    }

}