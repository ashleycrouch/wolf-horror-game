using deVoid.Utils;
using Project.InputSignals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricMovement : MonoBehaviour
{
    public Vector3Int GridSpaceToMove;
    public int walkSpeed;
    bool isFacingUp, isFacingRight;
    bool isWalking;

    public Grid world;

    Dictionary<Direction, Vector2> directionVectors = new Dictionary<Direction, Vector2>
      {
        { Direction.North, new Vector2(1, 1) },
        { Direction.South, new Vector2(-1, -1) },
        { Direction.East, new Vector2(1, -1) },
        { Direction.West, new Vector2(-1, 1) },
        { Direction.NorthEast, new Vector2(1, 0) },
        { Direction.NorthWest, new Vector2(0, 1) },
        { Direction.SouthEast, new Vector2(0, -1) },
        { Direction.SouthWest, new Vector2(-1, 0) },
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

    }

    IEnumerator LerpToLocation(Vector3Int coordinate)
    {
        Vector3 targetPosition = world.GetCellCenterWorld(coordinate);
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
        if(direction == Direction.None)
        {
            return;
        }
        //move one space in a direction
        Vector2 dirVector = directionVectors[direction];
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);

        Vector3Int neighbor = world.WorldToCell(pos + dirVector);
        GridSpaceToMove = neighbor;
        if(!isWalking)
        {
            StartCoroutine(LerpToLocation(neighbor));

        }

    }

}