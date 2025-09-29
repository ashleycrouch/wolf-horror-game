using UnityEngine;
using deVoid.Utils;
using Project.InputSignals;

public class InputManager : MonoBehaviour
{
    private InputDirectionSignal inputDirectionSignal;
    private InputAxisSignal inputAxisSignal;
    private NoInputSignal noInputSignal;

    void Start()
    {
        inputDirectionSignal = Signals.Get<InputDirectionSignal>();
        inputAxisSignal = Signals.Get<InputAxisSignal>();
        noInputSignal = Signals.Get<NoInputSignal>();
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

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        string directionString = getDirectionString(vertical, horizontal);
        Debug.Log($"Going in {directionString} direction");
        Direction direction = getDirection(directionString);
        if (direction == Direction.None)
        {
            noInputSignal.Dispatch();
        } else
        {
            inputAxisSignal.Dispatch(vertical, horizontal);
            inputDirectionSignal.Dispatch(direction);
        }
    }
}
