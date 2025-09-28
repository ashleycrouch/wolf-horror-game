using UnityEngine;
using deVoid.Utils;
using Project.InputSignals;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private Transform arrow = null;
    [SerializeField]
    //private TextMesh directionText = null;
    private InputDirectionSignal inputDirectionSignal;

    void Start()
    {
        inputDirectionSignal = Signals.Get<InputDirectionSignal>();
    }

    string getPolarity(float axis, string positive, string negative, float minimum=0.001f)
    {
        float sign = Mathf.Sign(axis);
        if ((axis * sign) < minimum) return "";
        return sign > 0  ? positive : negative;
    }

    string getDirectionString(float vertical, float horizontal)
    {
        return getPolarity(vertical, "N", "S") + getPolarity(horizontal, "E", "W");
    }

    Direction getDirection(string directionString) 
    {
        switch (directionString) 
        { 
            case "N": return Direction.North;
            case "S": return Direction.South;
            case "E": return Direction.East;
            case "W": return Direction.West;
            case "NE": return Direction.NorthEast;
            case "NW": return Direction.NorthWest;
            case "SE": return Direction.SouthEast;
            case "SW": return Direction.SouthWest;
            default: return Direction.None;
        }
    }

    float getSquareMagnitudeFromAxis(float vertical, float horizontal)
    {
        return new Vector3(horizontal, 0f, vertical).sqrMagnitude;
    }

    float getRotationFromAxis(float vertical, float horizontal, float minimum=0.00001f)
    {
        float sqrMagnitude = getSquareMagnitudeFromAxis(vertical, horizontal);
        float offset = sqrMagnitude > minimum ? 90f : 0f;
        return Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg - offset;
    }

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        float inputRotation = getRotationFromAxis(vertical, horizontal);
        arrow.rotation = Quaternion.Euler(0f, 0f, inputRotation);
        string directionString = getDirectionString(vertical, horizontal);
        //directionText.text = directionString;
        Debug.Log($"Going in {directionString} direction");
        Direction direction = getDirection(directionString);
        if (direction != Direction.None)
        {
            inputDirectionSignal.Dispatch(direction);
        }
    }
}
