using deVoid.Utils;
using Project.InputSignals;
using UnityEngine;

public class DirectionDisplay : MonoBehaviour
{
    [SerializeField]
    private Transform arrow = null;
    [SerializeField]
    private TextMesh directionText = null;
    private Vector3 initialArrowPosition = Vector3.zero;
    private string defaultDirectionText = "";
    private bool inputActive;

    private void Start()
    {
        initialArrowPosition = arrow.position;
        defaultDirectionText = directionText.text;
    }

    private void OnEnable()
    {
        Signals.Get<InputDirectionSignal>().AddListener(onInputDirection);
        Signals.Get<InputAxisSignal>().AddListener(onInputAxis);
        Signals.Get<NoInputSignal>().AddListener(onNoInput);
    }

    private void OnDisable()
    {
        Signals.Get<InputDirectionSignal>().RemoveListener(onInputDirection);
        Signals.Get<InputAxisSignal>().RemoveListener(onInputAxis);
        Signals.Get<NoInputSignal>().RemoveListener(onNoInput);
    }

    float getSquareMagnitudeFromAxis(float vertical, float horizontal)
    {
        return new Vector3(horizontal, 0f, vertical).sqrMagnitude;
    }

    float getRotationFromAxis(float vertical, float horizontal, float minimum = 0.00001f)
    {
        float sqrMagnitude = getSquareMagnitudeFromAxis(vertical, horizontal);
        float offset = sqrMagnitude > minimum ? 90f : 0f;
        return Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg - offset;
    }

    string getDirectionString(Direction direction)
    {
        switch (direction)
        {
            case Direction.North : return "N";
            case Direction.South : return "S";
            case Direction.East  : return "E";
            case Direction.West  : return "W";
            case Direction.NorthEast : return "NE";
            case Direction.NorthWest : return "NW";
            case Direction.SouthEast : return "SE";
            case Direction.SouthWest : return "SW";
            case Direction.None:
            default: return "";
        }
    }

    void enableDisplay(bool activate=true)
    {
        inputActive = activate;
        arrow.gameObject.SetActive(activate);
        directionText.gameObject.SetActive(activate);
    }

    void resetDisplay()
    {
        arrow.position = initialArrowPosition;
        directionText.text = defaultDirectionText;
    }

    void onInputDirection(Direction direction) 
    {
        if (!inputActive) { enableDisplay(); }
        directionText.text = getDirectionString(direction);
    }

    void onInputAxis(float vertical, float horizontal) 
    {
        if (!inputActive) { enableDisplay(); }
        float inputRotation = getRotationFromAxis(vertical, horizontal);
        arrow.rotation = Quaternion.Euler(0f, 0f, inputRotation);
    }

    void onNoInput()
    {
        if (!inputActive) { return; }
        resetDisplay();
        enableDisplay(false);
    }
}
